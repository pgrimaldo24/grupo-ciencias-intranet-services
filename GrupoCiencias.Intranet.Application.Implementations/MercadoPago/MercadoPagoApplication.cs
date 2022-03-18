using GrupoCiencias.Intranet.Application.Interfaces.ConnectionBridge;
using GrupoCiencias.Intranet.Application.Interfaces.MercadoPago;
using GrupoCiencias.Intranet.CrossCutting.Common;
using GrupoCiencias.Intranet.CrossCutting.Common.Constants;
using GrupoCiencias.Intranet.CrossCutting.Dto.Common;
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
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Application.Implementations.MercadoPago
{
    public class MercadoPagoApplication : IMercadoPagoApplication
    {
        private readonly Lazy<IUnitOfWork> _unitOfWork;
        private readonly Lazy<IBridgeApplication> _bridgeApplication;
        private readonly Lazy<IRelationRepository> _relationApplication;
        private readonly AppSetting _appSettings;

        public MercadoPagoApplication(IOptions<AppSetting> appSettings)
        {
            _appSettings = appSettings.Value;
            _unitOfWork = new Lazy<IUnitOfWork>(() => IoCAutofacContainer.Current.Resolve<IUnitOfWork>());
            _bridgeApplication = new Lazy<IBridgeApplication>(() => IoCAutofacContainer.Current.Resolve<IBridgeApplication>());
            _relationApplication = new Lazy<IRelationRepository>(() => IoCAutofacContainer.Current.Resolve<IRelationRepository>());
        }

        private IUnitOfWork UnitOfWork => _unitOfWork.Value;

        private IMercadoPagoRepository MercadoPagoRepository => UnitOfWork.Repository<IMercadoPagoRepository>();

        private IBridgeApplication BridgeApplication => _bridgeApplication.Value;

        private IRelationRepository RelationRepository => UnitOfWork.Repository<IRelationRepository>();

        #region method async MercadoPagoServices
        public async Task<ResponseDto> CardTokenAsync(CardTokenDto cardTokenDto)
        {
            var response = new ResponseDto();
            var cardInformation = SetDataCardTokenInformation(cardTokenDto);
            var cardtoken = await BridgeApplication.PostInvoque<RequestCardTokenDto, ResponseCardTokenDto>(
                cardInformation, string.Concat(_appSettings.MercadoPagoServices.CardToken, UtilConstants.ContentService.PublicKey + cardTokenDto.token_public), cardTokenDto.token_public, PropiedadesConstants.TypeRequest.POST);
            response.Data = cardtoken;
            return response;
        }

        public async Task<ResponseDto> CreatePaymentAsync(PaymentDto paymentDto)
        {
            var response = new ResponseDto();
            //var codpaymentreference = await GetCodePaymentReference();
            var payment_received = new PaymentReceivedDto();
            var paymentTransactionEntity = new TransaccionPagoEntity();
            var process_payment = RecordPaymentInformation(paymentDto);

            if(process_payment != null)
                paymentTransactionEntity = await SetRecordPaymentTransaction(process_payment);
             
            UnitOfWork.Set<TransaccionPagoEntity>().Add(paymentTransactionEntity);
            UnitOfWork.SaveChanges();
             
            //falta logica
            var create_payment = await BridgeApplication.PostInvoque<PaymentCreateRequest, PaymentReceivedDto>(
               process_payment, string.Concat(_appSettings.MercadoPagoServices.CreatePayment, UtilConstants.ContentService.InitialAccessToken + _appSettings.MercadoPagoCredentials.AccessToken), _appSettings.MercadoPagoCredentials.AccessToken, PropiedadesConstants.TypeRequest.POST);
             

            return response;
        }

        public async Task<ResponseDto> PaymentMethodAsync(string binCard)
        {
            var response = new ResponseDto();
            var bincardDto = new RequestPaymentMethodDto() { bin_card = binCard };
            var result = await BridgeApplication.GetInvoque<RequestPaymentMethodDto, List<ResponsePaymentMethodDto>>(bincardDto, string.Concat(_appSettings.MercadoPagoServices.PaymentMethods, UtilConstants.ContentService.Bin + bincardDto.bin_card + UtilConstants.ContentService.AccessToken + _appSettings.MercadoPagoCredentials.AccessToken),
                _appSettings.MercadoPagoCredentials.AccessToken, PropiedadesConstants.TypeRequest.GET);
            response.Data = result;
            return response;
        }
        #endregion
         
        #region Method private MercadoPago
        private RequestCardTokenDto SetDataCardTokenInformation(CardTokenDto cardtokendto)
        {
            var cardRequest = new RequestCardTokenDto();
            cardRequest.device = new Device(); 
            cardRequest.device.fingerprint.vendor_ids = new List<VendorId>();
            
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

        private PaymentCreateRequest RecordPaymentInformation(PaymentDto payment)
        {
            MercadoPagoConfig.AccessToken = _appSettings.MercadoPagoCredentials.AccessToken;

            var payment_additional_info = new PaymentAdditionalInfoRequest();
            var payment_create = new PaymentCreateRequest(); 
            var payment_request = new PaymentDto();
            var additiona_info_dto = new AdditionalInfoPaymentDto();
            var additional_info_items = new List<AdditionalInfoDto>(); 
            payment_request = payment;
            additiona_info_dto = payment.additional_info; 
            additional_info_items = payment.additional_info.items;
            payment_create.AdditionalInfo = payment_additional_info;
            payment_create.AdditionalInfo.Items = new List<PaymentItemRequest>(); 
            payment_create.AdditionalInfo.Shipments = new PaymentShipmentsRequest(); 
            payment_create.Order = new PaymentOrderRequest();
             
            foreach (var items in additional_info_items)
            {
                var paymentItem = new PaymentItemRequest()
                {
                    Id = items.id.ToString(),
                    Title = items.title.ToString(),
                    Description = items.description.ToString(),
                    PictureUrl = items.picture_url.ToString(),
                    CategoryId = items.category_id.ToString(),
                    Quantity = items.quantity,
                    UnitPrice = items.unit_price
                }; 
                payment_create.AdditionalInfo.Items.Add(paymentItem); 
            }

            payment_create.AdditionalInfo.Payer = new PaymentAdditionalInfoPayerRequest()
            {
                FirstName = payment.additional_info.payer.first_name.ToString().Trim(),
                LastName = payment.additional_info.payer.last_name.ToString().Trim()
            };

            payment_create.AdditionalInfo.Payer.Phone = new PhoneRequest()
            {
                AreaCode = payment.additional_info.payer.phone.area_code,
                Number = payment.additional_info.payer.phone.number
            };

            payment_create.AdditionalInfo.Payer.Address = new AddressRequest()
            {
                ZipCode = payment.additional_info.payer.address.zip_code,
                StreetName = payment.additional_info.payer.address.street_name,
                StreetNumber = payment.additional_info.payer.address.street_number
            };

            payment_create.AdditionalInfo.Shipments.ReceiverAddress = new PaymentReceiverAddressRequest()
            {
                ZipCode = payment.additional_info.shipments.receiver_address.zip_code,
                StateName = payment.additional_info.shipments.receiver_address.state_name,
                CityName = payment.additional_info.shipments.receiver_address.city_name,
                StreetName = payment.additional_info.shipments.receiver_address.street_name,
                StreetNumber = payment.additional_info.shipments.receiver_address.street_number
            };

            payment_create.Payer = new PaymentPayerRequest()
            {
                Email = payment.payer.email.ToString().Trim(),
                FirstName = payment.additional_info.payer.first_name.ToString().Trim(),
                LastName = payment.additional_info.payer.last_name.ToString().Trim()
            };

            payment_create.Payer.Identification = new IdentificationRequest()
            {
                Type = payment.payer.identification.type,
                Number = payment.payer.identification.number
            };
              
            payment_create.BinaryMode = payment.binary_mode;
            payment_create.Capture = payment.capture;
            payment_create.ExternalReference = payment.external_reference;
            payment_create.Installments = payment.installments;
            payment_create.NotificationUrl = payment.notification_url;  
            payment_create.PaymentMethodId = payment.payment_method_id;
            payment_create.Token = payment.token;
            payment_create.TransactionAmount = payment.transaction_amount;
 
            return payment_create;
        }

        private async Task<TransaccionPagoEntity> SetRecordPaymentTransaction(PaymentCreateRequest createRequest)
        {
            var payment_transaction_entity = new TransaccionPagoEntity()
            { 
                CuotasPago = createRequest.Installments,
                NotificacionUrl = createRequest.NotificationUrl,
                NombreTitular = createRequest.Payer.FirstName,
                ApellidoTitular = createRequest.Payer.LastName,
                EmailTitular = createRequest.Payer.Email,
                NumeroDocumentoTitular = createRequest.Payer.Identification.Number,
                TipoDocumentoTitularId = await RelationRepository.GetDocumentTypeXId(createRequest.Payer.Identification.Type),
                MetodoPagoId = createRequest.PaymentMethodId,
                TokenCard = createRequest.Token,
                MontoTransaccion = createRequest.TransactionAmount 
            };

            return payment_transaction_entity; 
        }
        #endregion
    }
}
