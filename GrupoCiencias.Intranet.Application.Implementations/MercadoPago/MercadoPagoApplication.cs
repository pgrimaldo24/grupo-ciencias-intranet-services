using GrupoCiencias.Intranet.Application.Interfaces.ConnectionBridge;
using GrupoCiencias.Intranet.Application.Interfaces.Intranet;
using GrupoCiencias.Intranet.Application.Interfaces.MercadoPago;
using GrupoCiencias.Intranet.CrossCutting.Common;
using GrupoCiencias.Intranet.CrossCutting.Common.Constants;
using GrupoCiencias.Intranet.CrossCutting.Common.Resources;
using GrupoCiencias.Intranet.CrossCutting.Dto.Common;
using GrupoCiencias.Intranet.CrossCutting.Dto.Matricula;
using GrupoCiencias.Intranet.CrossCutting.Dto.MercadoPago;
using GrupoCiencias.Intranet.CrossCutting.IoC.Container;
using GrupoCiencias.Intranet.Domain.Models.Entity;
using GrupoCiencias.Intranet.Domain.Models.MercadoPago;
using GrupoCiencias.Intranet.Repository.Interfaces.Data;
using GrupoCiencias.Intranet.Repository.Interfaces.Repositories;
using MercadoPago.Client.Common;
using MercadoPago.Client.Payment;
using MercadoPago.Config;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Application.Implementations.MercadoPago
{
    public class MercadoPagoApplication : IMercadoPagoApplication
    {
        private readonly Lazy<IUnitOfWork> _unitOfWork;
        private readonly Lazy<IBridgeApplication> _bridgeApplication;
        private readonly Lazy<IRelationRepository> _relationApplication;
        private readonly Lazy<IEncryptionApplication> _encryptionApplication;
        private readonly AppSetting _appSettings;

        public MercadoPagoApplication(IOptions<AppSetting> appSettings)
        {
            _appSettings = appSettings.Value;
            _unitOfWork = new Lazy<IUnitOfWork>(() => IoCAutofacContainer.Current.Resolve<IUnitOfWork>());
            _bridgeApplication = new Lazy<IBridgeApplication>(() => IoCAutofacContainer.Current.Resolve<IBridgeApplication>());
            _relationApplication = new Lazy<IRelationRepository>(() => IoCAutofacContainer.Current.Resolve<IRelationRepository>());
            _encryptionApplication = new Lazy<IEncryptionApplication>(() => IoCAutofacContainer.Current.Resolve<IEncryptionApplication>());
        }

        private IUnitOfWork UnitOfWork => _unitOfWork.Value;

        private IMercadoPagoRepository MercadoPagoRepository => UnitOfWork.Repository<IMercadoPagoRepository>();

        private IBridgeApplication BridgeApplication => _bridgeApplication.Value;

        private IRelationRepository RelationRepository => UnitOfWork.Repository<IRelationRepository>();

        private IEncryptionApplication EncryptionApplication => _encryptionApplication.Value;

        #region method async MercadoPagoServices
        public async Task<ResponseDto> CardTokenAsync(CardTokenDto cardTokenDto)
        {
            var response = new ResponseDto();
            var cardInformation = SetRequestDataCardToken(cardTokenDto);

            var cardtoken = await BridgeApplication.PostInvoque<RequestCardTokenDto, ResponseCardTokenDto>(
                cardInformation, string.Concat(_appSettings.MercadoPagoServices.CardToken, UtilConstants.ContentService.PublicKey + cardTokenDto.token_public),
                cardTokenDto.token_public, PropiedadesConstants.TypeRequest.POST);
             
            if (cardtoken.validations.Equals(null))
            {
                var result_card_token = await SetResponseCardToken(cardtoken);
                response.Data = result_card_token; 
            }
            else
            {
                cardtoken.validations.ForEach(x =>
                {
                    response.Status = x.status_code;
                    response.Message = x.message.ToString();
                });
            } 
            return response;
        }

      

        public async Task<ResponseDto> CreatePaymentAsync(StudentPaymentDto studentPaymentDto)
        {
            var response = new ResponseDto(); 
            var payment_received = new PaymentReceivedDto();  
            var codpaymentreference = await GetPaymentReference(); 
            var payment_request = await RecordPaymentInformation(studentPaymentDto);

            payment_request.external_reference = codpaymentreference.cod_pago_referencia.ToString(); 
            var paymentTransactionEntity = await InitialRegistrationPaymentTransaction(payment_request, codpaymentreference.codpagorefindex, studentPaymentDto.student.student_document_number);
            UnitOfWork.Set<TransaccionPagoEntity>().Add(paymentTransactionEntity);
            UnitOfWork.SaveChanges();
             
            var create_payment = await BridgeApplication.PostInvoque<PaymentDto, PaymentReceivedDto>(payment_request, 
                string.Concat(_appSettings.MercadoPagoServices.CreatePayment, UtilConstants.ContentService.InitialAccessToken + _appSettings.MercadoPagoCredentials.AccessToken),
                _appSettings.MercadoPagoCredentials.AccessToken, PropiedadesConstants.TypeRequest.POST);

            paymentTransactionEntity = await TransactionProcessCompleted(create_payment);
            UnitOfWork.Set<TransaccionPagoEntity>().Update(paymentTransactionEntity);
            UnitOfWork.SaveChanges();

            if (!string.IsNullOrEmpty(studentPaymentDto.student.student_document_number.ToString()))
            {
                var oPaymentTransaction = await MercadoPagoRepository.GetIdPaymentTransactionXDocument(studentPaymentDto.student.student_document_number.ToString().Trim());
                var historyPaymentTransaction = new HistorialPagoSolicitudEntity()
                {
                    IdTransaccionPago = oPaymentTransaction.id_payment_transaction
                };
                UnitOfWork.Set<HistorialPagoSolicitudEntity>().Add(historyPaymentTransaction);
                UnitOfWork.SaveChanges();
            } 

            var url_response_notification = new NotificationUrl();
            create_payment.validations = new List<ValidationResponseDto>();

            if (create_payment.validations is null)
            { 
                create_payment.validations.ForEach(x =>
                {
                    response.Status = x.status_code;
                    response.Message = x.message.ToString(); 
                });

                var urlBad = new NotificationUrl
                {
                    payment_notification_url = await GetUrlNotificationResult(create_payment.validations)
                };
                url_response_notification = urlBad; 
                response.Data = url_response_notification; 
                return response;
            } 

            var oExceptionOk = new ValidationResponseDto()
            {
                status_code = UtilConstants.CodigoEstado.Ok,
                message = AlertResources.msg_correcto
            };
             
            create_payment.validations.Add(oExceptionOk);

            var urlOk = new NotificationUrl
            {
                payment_notification_url = await GetUrlNotificationResult(create_payment.validations)
            };

            url_response_notification = urlOk;
              
            var status = await MercadoPagoRepository.GetAllPaymentStatuses();
            var result = new Payment_ResponseDto
            {
                id_voucher = create_payment.id.ToString(),
                payment_status = status.Where(x => x.status_index.ToString().Contains(create_payment.status))
                                   .Select(psm => new Payment_StatusDto
                                   {
                                       status_index = psm.status_index.ToString(),
                                       payment_status_description = status.Select(psd => new StatusDescriptionDto
                                       {
                                           status_detail = psm.status_detail.ToString(),
                                           description = psm.description.ToString()
                                       }).FirstOrDefault()
                                   }).FirstOrDefault(),
                payment_status_detail = status.Where(x => x.status_index.ToString().Contains(create_payment.status_detail))
                                .Select(o => new Payment_StatusDto
                                {
                                    status_index = o.status_index.ToString(),
                                    payment_status_description = status.Select(sd => new StatusDescriptionDto
                                    {
                                        status_detail = o.status_detail.ToString(),
                                        description = o.description.ToString()
                                    }).FirstOrDefault()
                                }).FirstOrDefault(),
                payment_date_created = create_payment.date_created.ToString(),
                payment_date_approved = create_payment.date_approved.ToString(),
                payment_money_release_date = create_payment.money_release_date.ToString(),
                payment_notification_url = url_response_notification.payment_notification_url
            };

            response.Status = UtilConstants.CodigoEstado.Ok;
            response.Message = AlertResources.msg_correcto;
            response.Data = result;
            return response;
        }

        public async Task<ResponseDto> PaymentMethodAsync(string binCard)
        {
            var response = new ResponseDto();
            var bincardDto = new RequestPaymentMethodDto() { bin_card = binCard };
            var result = await BridgeApplication.GetInvoque<List<ResponsePaymentMethodDto>>( 
                string.Concat(_appSettings.MercadoPagoServices.PaymentMethods, UtilConstants.ContentService.Bin + bincardDto.bin_card + UtilConstants.ContentService.AccessToken + _appSettings.MercadoPagoCredentials.AccessToken),
                _appSettings.MercadoPagoCredentials.AccessToken, PropiedadesConstants.TypeRequest.GET);

           
            foreach (var rst in result)
            {
                if (rst.validations is null)
                {
                    var result_card_token = await SetResponsePaymentMethod(result);
                    response.Data = result_card_token; 
                }else{
                    rst.validations.ForEach(x =>
                    {
                        response.Status = x.status_code;
                        response.Message = x.message.ToString();
                    });
                }
            }

            return response;
        }
          
        public async Task<ResponseDto> IdentificationTypesAsync()
        { 
            var response = new ResponseDto();
            var result = await BridgeApplication.GetInvoque<List<IdentificationTypeDto>>(
                string.Concat(_appSettings.MercadoPagoServices.IdentificationTypes, UtilConstants.ContentService.InitialAccessToken + _appSettings.MercadoPagoCredentials.AccessToken),
                _appSettings.MercadoPagoCredentials.AccessToken, PropiedadesConstants.TypeRequest.GET); 
            response.Data = result;
            return response;
        }

        public async Task<ResponseDto> CardValidationAsync()
        {
            var response = new ResponseDto();
            var result = await BridgeApplication.GetInvoque<List<CardValidationDto>>(
                string.Concat(_appSettings.MercadoPagoServices.CardValidation, UtilConstants.ContentService.InitialAccessToken + _appSettings.MercadoPagoCredentials.AccessToken),
                _appSettings.MercadoPagoCredentials.AccessToken, PropiedadesConstants.TypeRequest.GET);
            response.Data = result;
            return response;
        }
        #endregion

        #region Method private MercadoPago
        private RequestCardTokenDto SetRequestDataCardToken(CardTokenDto cardtokendto)
        {
            var cardRequest = new RequestCardTokenDto(); 

            cardRequest.cardholder = new CardHolder()
            {
                name = cardtokendto.cardholder.name
            };

            cardRequest.cardholder.identification = new Indetification() 
            {
                number = cardtokendto.cardholder.identification.number,
                type = cardtokendto.cardholder.identification.type
            };
             
            cardRequest.card_number = cardtokendto.card_number;
            cardRequest.security_code = cardtokendto.security_code;
            cardRequest.expiration_month = cardtokendto.expiration_month;
            cardRequest.expiration_year = cardtokendto.expiration_year;

            cardRequest.device = new Device();

            cardRequest.device.fingerprint = new Fingerprint()
            {
                os = cardtokendto.device.fingerprint.os,
                system_version = cardtokendto.device.fingerprint.system_version,
                ram = cardtokendto.device.fingerprint.ram,
                disk_space = cardtokendto.device.fingerprint.disk_space,
                model = cardtokendto.device.fingerprint.model,
                free_disk_space = cardtokendto.device.fingerprint.free_disk_space,
                resolution = cardtokendto.device.fingerprint.resolution
            };

            cardRequest.device.fingerprint.vendor_ids = new List<VendorId>();

            foreach (var item in cardtokendto.device.fingerprint.vendor_ids)
            {
                var vendor = new VendorId()
                {
                    name = item.name,
                    value = item.value
                };
                cardRequest.device.fingerprint.vendor_ids.Add(vendor);
            }

            cardRequest.device.fingerprint.vendor_specific_attributes = new VendorSpecificAttributes()
            {
                feature_flash = cardtokendto.device.fingerprint.vendor_specific_attributes.feature_flash,
                can_make_phone_calls = cardtokendto.device.fingerprint.vendor_specific_attributes.can_make_phone_calls,
                can_send_sms = cardtokendto.device.fingerprint.vendor_specific_attributes.can_send_sms,
                video_camera_available = cardtokendto.device.fingerprint.vendor_specific_attributes.video_camera_available,
                cpu_count = cardtokendto.device.fingerprint.vendor_specific_attributes.cpu_count,
                simulator = cardtokendto.device.fingerprint.vendor_specific_attributes.simulator,
                device_languaje = cardtokendto.device.fingerprint.vendor_specific_attributes.device_languaje,
                device_idiom = cardtokendto.device.fingerprint.vendor_specific_attributes.device_idiom,
                platform = cardtokendto.device.fingerprint.vendor_specific_attributes.platform,
                device_name = cardtokendto.device.fingerprint.vendor_specific_attributes.device_name,
                device_family = cardtokendto.device.fingerprint.vendor_specific_attributes.device_family,
                retina_display_capable = cardtokendto.device.fingerprint.vendor_specific_attributes.retina_display_capable,
                feature_camera = cardtokendto.device.fingerprint.vendor_specific_attributes.feature_camera,
                device_model = cardtokendto.device.fingerprint.vendor_specific_attributes.device_model,
                feature_front_camera = cardtokendto.device.fingerprint.vendor_specific_attributes.feature_front_camera
            }; 

            return cardRequest;
        }

        private async Task<PaymentDto> RecordPaymentInformation(StudentPaymentDto studentPaymentDto)
        {
            MercadoPagoConfig.AccessToken = _appSettings.MercadoPagoCredentials.AccessToken; 
            var payment_response = new PaymentDto();
            var student_payment = new StudentPaymentDto();
            var additional_info_items = new List<AdditionalInfoDto>();
            var additiona_info_dto = new AdditionalInfoPaymentDto(); 
            student_payment = studentPaymentDto;
            additiona_info_dto = student_payment.additional_info;
            additional_info_items = student_payment.additional_info.items; 
            payment_response.additional_info = new AdditionalInfoPaymentDto();
            payment_response.additional_info.items = new List<AdditionalInfoDto>();

            foreach (var items in additional_info_items)
            {
                var paymentItem = new AdditionalInfoDto()
                {
                    id = items.id.ToString(),
                    title = items.title.ToString(),
                    description = items.description.ToString(),
                    picture_url = items.picture_url.ToString(),
                    category_id = items.category_id.ToString(),
                    quantity = items.quantity,
                    unit_price = items.unit_price
                };
                payment_response.additional_info.items.Add(paymentItem); 
            }

            payment_response.additional_info.payer = new PayerDto()
            {
                first_name = student_payment.additional_info.payer.first_name.ToString().Trim(),
                last_name = student_payment.additional_info.payer.last_name.ToString().Trim()
            };
             
            payment_response.payer = new PayerRequestDto()
            {
                email = student_payment.payer.email.ToString().Trim(),
                first_name = student_payment.additional_info.payer.first_name.ToString().Trim(),
                last_name = student_payment.additional_info.payer.last_name.ToString().Trim()
            };

            payment_response.payer.identification = new PayerIdentificationDto()
            {
                type = student_payment.payer.identification.type,
                number = student_payment.payer.identification.number
            };

            payment_response.binary_mode = student_payment.binary_mode;
            payment_response.capture = student_payment.capture;
            payment_response.external_reference = student_payment.external_reference;
            payment_response.installments = student_payment.installments;
            payment_response.notification_url = student_payment.notification_url;
            payment_response.payment_method_id = student_payment.payment_method_id;
            payment_response.token = student_payment.token;
            payment_response.transaction_amount = student_payment.transaction_amount; 
            return payment_response;
        }

        private async Task<TransaccionPagoEntity> InitialRegistrationPaymentTransaction(PaymentDto createRequest, int cod_pago_ref_index, string student_document_number)
        {
            var payment_transaction_entity = new TransaccionPagoEntity()
            { 
                CodPagoReferencia = createRequest.external_reference,
                CuotasPago = await EncryptionApplication.EncryptString(createRequest.installments.ToString()),
                NotificacionUrl = await EncryptionApplication.EncryptString(createRequest.notification_url.ToString()),
                NombreTitular = await EncryptionApplication.EncryptString(createRequest.payer.first_name.ToString()),
                ApellidoTitular = await EncryptionApplication.EncryptString(createRequest.payer.last_name.ToString()),
                EmailTitular = await EncryptionApplication.EncryptString(createRequest.payer.email.ToString()),
                NumeroDocumentoTitular = await EncryptionApplication.EncryptString(createRequest.payer.identification.number.ToString()),
                TipoDocumentoTitularId = await RelationRepository.GetDocumentTypeXId(createRequest.payer.identification.type.ToString()),
                MetodoPagoId = await EncryptionApplication.EncryptString(createRequest.payment_method_id.ToString()),
                TokenCard = await EncryptionApplication.EncryptString(createRequest.token.ToString()),
                MontoTransaccion = await EncryptionApplication.EncryptString(createRequest.transaction_amount.ToString()),
                CodPagoRefIndex = cod_pago_ref_index,
                NumeroDocumentoEstudiante = student_document_number.ToString()
            };  
            return payment_transaction_entity; 
        }

        private async Task<TransaccionPagoEntity> TransactionProcessCompleted(PaymentReceivedDto paymentReceived)
        { 
            var payment_information = new TransaccionPagoEntity(); 
            payment_information = await MercadoPagoRepository.GetRegisteredPaymentInformationAsync(paymentReceived.external_reference);

            if (!ReferenceEquals(null, paymentReceived))
            { 
                payment_information.IdComprobantePago = await EncryptionApplication.EncryptString(paymentReceived.id.ToString());
                payment_information.FechaCreadaPago = await EncryptionApplication.EncryptString(paymentReceived.date_created.ToString());
                payment_information.FechaAprovadaPago = await EncryptionApplication.EncryptString(paymentReceived.date_approved.ToString());
                payment_information.FechaUltimaActualizacion = await EncryptionApplication.EncryptString(paymentReceived.date_last_updated.ToString());
                payment_information.FechaLiberacionDinero = await EncryptionApplication.EncryptString(paymentReceived.money_release_date.ToString());
                payment_information.IdTipoTarjeta = await EncryptionApplication.EncryptString(paymentReceived.payment_type_id.ToString());
                payment_information.EstadoPago = await EncryptionApplication.EncryptString(paymentReceived.status.ToString());
                payment_information.EstadoPagoDetalle = await EncryptionApplication.EncryptString(paymentReceived.status_detail.ToString());
                payment_information.TipoMoneda = await EncryptionApplication.EncryptString(paymentReceived.currency_id.ToString());
                payment_information.Proveedor = paymentReceived.statement_descriptor.ToString(); 
            }  
            return payment_information;
        }

        private async Task<ResultCardTokenDto> SetResponseCardToken(ResponseCardTokenDto responseCard)
        {
            responseCard.validations = new List<ValidationResponseDto>();
            var oExceptionOk = new ValidationResponseDto()
            {
                status_code = UtilConstants.CodigoEstado.Ok,
                message = AlertResources.msg_correcto
            };

            responseCard.validations.Add(oExceptionOk);

            var result = new ResultCardTokenDto()
            {
                id = responseCard.id,
                public_key = responseCard.public_key,
                expiration_month = responseCard.expiration_month,
                expiration_year = responseCard.expiration_year,
                last_four_digits = responseCard.last_four_digits,
                status = responseCard.status,
                date_created = responseCard.date_created,
                date_last_updated = responseCard.date_last_updated,
                date_due = responseCard.date_due,
                luhn_validation = responseCard.luhn_validation,
                live_mode = responseCard.live_mode,
                require_esc = responseCard.require_esc,
                security_code_length = responseCard.security_code_length
            };

            result.cardholder = new CardHolder
            {
                name = responseCard.cardholder.name
            };

            result.cardholder.identification = new Indetification
            {
                type = responseCard.cardholder.identification.type,
                number = responseCard.cardholder.identification.number
            };

            return result;
        }

        private async Task<string> GetUrlNotificationResult(List<ValidationResponseDto> result)
        {
            var response = string.Empty;
            foreach (var item in result)
            {
                var url_response_notification = _appSettings.MercadoPagoServices.NoificationWebhook + UtilConstants.ContentService.StatusCode + item.status_code + UtilConstants.ContentService.Message + item.message.ToString();
                response = url_response_notification;
            }   
            return response;
        }

        private async Task<List<ResulPaymentMethodDto>> SetResponsePaymentMethod(List<ResponsePaymentMethodDto> responsePaymentMethods)
        {
            var result = new List<ResulPaymentMethodDto>();

            foreach (var item in responsePaymentMethods)
            {
                var result_payment = new ResulPaymentMethodDto
                {
                    payment_method_id = item.payment_method_id,
                    payment_type_id = item.payment_type_id,
                    processing_mode = item.processing_mode,
                    merchant_account_id = item.merchant_account_id,
                    agreements = item.agreements
                };

                result_payment.issuer = new Issuer
                {
                    id = item.issuer.id,
                    name = item.issuer.name,
                    secure_thumbnail = item.issuer.secure_thumbnail,
                    thumbnail = item.issuer.thumbnail
                };

                var listPayerCosts = new List<PayerCost>();

                foreach (var payercosts in item.payer_costs)
                {
                    var oPayerCost = new PayerCost
                    {
                        installments = payercosts.installments,
                        installment_rate = payercosts.installment_rate,
                        discount_rate = payercosts.discount_rate,
                        reimbursement_rate = payercosts.reimbursement_rate,
                        labels = payercosts.labels.ToList(),
                        installment_rate_collector = payercosts.installment_rate_collector.ToList(),
                        min_allowed_amount = payercosts.min_allowed_amount,
                        max_allowed_amount = payercosts.max_allowed_amount,
                        recommended_message = payercosts.recommended_message,
                        installment_amount = payercosts.installment_amount,
                        total_amount = payercosts.total_amount,
                        payment_method_option_id = payercosts.payment_method_option_id
                    };
                    listPayerCosts.Add(oPayerCost);
                }

                result_payment.payer_costs = listPayerCosts.ToList();
                result.Add(result_payment);
            }
            return result;
        }

        private async Task<ResponseReferenciaDto> GetPaymentReference()
        {
            var infoTransaccionPago = await MercadoPagoRepository.GetMaxIdExternalReference();
            int codPagoRefIndex = infoTransaccionPago != null ? infoTransaccionPago.codpagorefindex + 1 : 1;
            var cod_pago_referencia = UtilConstants.ContentService.Prefix_GrupoCiencias + codPagoRefIndex.ToString().PadLeft(8, char.Parse("0"));
            var response = new ResponseReferenciaDto
            {
                cod_pago_referencia = cod_pago_referencia,
                codpagorefindex = codPagoRefIndex,
            };
            return response;
        }
         
        #endregion
    }
}
