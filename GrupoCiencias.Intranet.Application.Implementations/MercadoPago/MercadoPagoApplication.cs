using GrupoCiencias.Intranet.Application.Interfaces.ConnectionBridge;
using GrupoCiencias.Intranet.Application.Interfaces.MercadoPago;
using GrupoCiencias.Intranet.CrossCutting.Common;
using GrupoCiencias.Intranet.CrossCutting.Common.Constants;
using GrupoCiencias.Intranet.CrossCutting.Dto.Common;
using GrupoCiencias.Intranet.CrossCutting.Dto.MercadoPago;
using GrupoCiencias.Intranet.CrossCutting.IoC.Container;
using GrupoCiencias.Intranet.Repository.Interfaces.Data;
using GrupoCiencias.Intranet.Repository.Interfaces.Repositories;
using MercadoPago.Resource.Common;
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
        private readonly AppSetting _appSettings;

        public MercadoPagoApplication(IOptions<AppSetting> appSettings)
        {
            _appSettings = appSettings.Value;
            _unitOfWork = new Lazy<IUnitOfWork>(() => IoCAutofacContainer.Current.Resolve<IUnitOfWork>());
            _bridgeApplication = new Lazy<IBridgeApplication>(() => IoCAutofacContainer.Current.Resolve<IBridgeApplication>());
        }

        private IUnitOfWork UnitOfWork => _unitOfWork.Value;

        private IMercadoPagoRepository MercadoPagoRepository => UnitOfWork.Repository<IMercadoPagoRepository>();

        private IBridgeApplication BridgeApplication => _bridgeApplication.Value;


        public async Task<ResponseDto> CardTokenAsync(CardTokenDto cardTokenDto)
        {
            var response = new ResponseDto();
            var cardInformation = SetDataCardInformation(cardTokenDto);
            var cardtoken = await BridgeApplication.PostInvoque<RequestCardTokenDto, ResponseCardTokenDto>(
                cardInformation, string.Concat(_appSettings.MercadoPagoServices.CardToken, UtilConstants.ContentService.PublicKey + cardTokenDto.token_public + ""), cardTokenDto.token_public, PropiedadesConstants.TypeRequest.POST);
            response.Data = cardtoken;
            return response;
        }

        public async Task<ResponseDto> PaymentMethodAsync(string binCard)
        {
            var response = new ResponseDto();
            var bincardDto = new RequestPaymentMethodDto() { bin_card = binCard };
            var result = await BridgeApplication.GetInvoque<RequestPaymentMethodDto, List<ResponsePaymentMethodDto>> (bincardDto, string.Concat(_appSettings.MercadoPagoServices.PaymentMethods, UtilConstants.ContentService.Bin + bincardDto.bin_card + UtilConstants.ContentService.AccessToken + _appSettings.MercadoPagoCredentials.AccessToken),
                _appSettings.MercadoPagoCredentials.AccessToken, PropiedadesConstants.TypeRequest.GET);
            response.Data = result;
            return response;
        }

        #region Method private MercadoPago
        private RequestCardTokenDto SetDataCardInformation(CardTokenDto cardtokendto)
        {
            var cardRequest = new RequestCardTokenDto();
            cardRequest.device = new Device();
            cardRequest.device.fingerprint = new Fingerprint();
            cardRequest.device.fingerprint.vendor_ids = new List<VendorId>();
            cardRequest.device.fingerprint.vendor_specific_attributes = new VendorSpecificAttributes();
            cardRequest.cardholder = new CardHolder();
            cardRequest.cardholder.identification = new Indetification();

            cardRequest.card_number = cardtokendto.card_number;
            cardRequest.security_code = cardtokendto.security_code;
            cardRequest.expiration_month = cardtokendto.expiration_month;
            cardRequest.expiration_year = cardtokendto.expiration_year;
            cardRequest.cardholder.name = cardtokendto.cardholder.name;
            cardRequest.cardholder.identification.number = cardtokendto.cardholder.identification.number;
            cardRequest.cardholder.identification.type = cardtokendto.cardholder.identification.type;
            cardRequest.device.fingerprint.os = cardtokendto.device.fingerprint.os;
            cardRequest.device.fingerprint.system_version = cardtokendto.device.fingerprint.system_version;
            cardRequest.device.fingerprint.ram = cardtokendto.device.fingerprint.ram;
            cardRequest.device.fingerprint.disk_space = cardtokendto.device.fingerprint.disk_space;
            cardRequest.device.fingerprint.model = cardtokendto.device.fingerprint.model;
            cardRequest.device.fingerprint.free_disk_space = cardtokendto.device.fingerprint.free_disk_space;

            cardtokendto.device.fingerprint.vendor_ids.ForEach(x =>
            {
                var vendor = new VendorId();
                vendor.name = x.name;
                vendor.value = x.value;
                cardRequest.device.fingerprint.vendor_ids.Add(vendor);
            });

            cardRequest.device.fingerprint.vendor_specific_attributes.feature_flash = cardtokendto.device.fingerprint.vendor_specific_attributes.feature_flash;
            cardRequest.device.fingerprint.vendor_specific_attributes.can_make_phone_calls = cardtokendto.device.fingerprint.vendor_specific_attributes.can_make_phone_calls;
            cardRequest.device.fingerprint.vendor_specific_attributes.can_send_sms = cardtokendto.device.fingerprint.vendor_specific_attributes.can_send_sms;
            cardRequest.device.fingerprint.vendor_specific_attributes.video_camera_available = cardtokendto.device.fingerprint.vendor_specific_attributes.video_camera_available;
            cardRequest.device.fingerprint.vendor_specific_attributes.cpu_count = cardtokendto.device.fingerprint.vendor_specific_attributes.cpu_count;
            cardRequest.device.fingerprint.vendor_specific_attributes.simulator = cardtokendto.device.fingerprint.vendor_specific_attributes.simulator;
            cardRequest.device.fingerprint.vendor_specific_attributes.device_languaje = cardtokendto.device.fingerprint.vendor_specific_attributes.device_languaje;
            cardRequest.device.fingerprint.vendor_specific_attributes.device_idiom = cardtokendto.device.fingerprint.vendor_specific_attributes.device_idiom;
            cardRequest.device.fingerprint.vendor_specific_attributes.platform = cardtokendto.device.fingerprint.vendor_specific_attributes.platform;
            cardRequest.device.fingerprint.vendor_specific_attributes.device_name = cardtokendto.device.fingerprint.vendor_specific_attributes.device_name;
            cardRequest.device.fingerprint.vendor_specific_attributes.device_family = cardtokendto.device.fingerprint.vendor_specific_attributes.device_family;
            cardRequest.device.fingerprint.vendor_specific_attributes.retina_display_capable = cardtokendto.device.fingerprint.vendor_specific_attributes.retina_display_capable;
            cardRequest.device.fingerprint.vendor_specific_attributes.feature_camera = cardtokendto.device.fingerprint.vendor_specific_attributes.feature_camera;
            cardRequest.device.fingerprint.vendor_specific_attributes.device_model = cardtokendto.device.fingerprint.vendor_specific_attributes.device_model;
            cardRequest.device.fingerprint.vendor_specific_attributes.feature_front_camera = cardtokendto.device.fingerprint.vendor_specific_attributes.feature_front_camera;
            cardRequest.device.fingerprint.resolution = cardtokendto.device.fingerprint.resolution; 
            return cardRequest;
        }
        #endregion
    }
}
