using GrupoCiencias.Intranet.Api;
using GrupoCiencias.Intranet.Api.Controllers.MercadoPago;
using GrupoCiencias.Intranet.CrossCutting.Common;
using GrupoCiencias.Intranet.CrossCutting.Dto.MercadoPago;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using GrupoCiencias.Intranet.Application.Implementations.MercadoPago;
using Microsoft.AspNetCore.Mvc;

namespace GrupoCiencias.Intranet.Testing.Application.MercadoPago
{
    /// <summary>
    /// Unit test MercadoPago services
    /// </summary>
    [TestClass]
    public class MercadoPagoTest
    { 
        private readonly TestServer _server;
        private readonly HttpClient _client;
        private readonly MercadoPagoApplication _mercadoPagoApplication;
        private readonly AppSetting _appSettings;

        public MercadoPagoTest(IOptions<AppSetting> appSettings)
        {
            _appSettings = appSettings.Value;
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
            _mercadoPagoApplication = new MercadoPagoApplication(appSettings);
        }
         
        /// <summary>
        /// Create payment Mercado Pago
        /// </summary>
        /// <returns></returns>    
        [TestMethod]
        public void CreatePaymentAsync()
        { 
            var mercadoPagoController = new MercadoPagoController(); 
            var oCreatePayment = new StudentPaymentDto(); 
            oCreatePayment.additional_info = new AdditionalInfoPaymentDto();
            oCreatePayment.additional_info.items = new List<AdditionalInfoDto>();
             
            var oItems = new AdditionalInfoDto
            {
                id = "Mensualidad",
                title = "CICLO VERANO",
                description = "CICLO COMPLETO",
                picture_url = "",
                category_id = "ESTUDIOS",
                quantity = 1,
                unit_price = 90
            };

            oCreatePayment.additional_info.items.Add(oItems); 
            oCreatePayment.additional_info.payer = new PayerDto() 
            {
                first_name = "Pierr Antony",
                last_name = "Grimaldo Vidalon"
            };

            oCreatePayment.student = new StudentDto
            {
                student_document_number = "72192027"
            };
              
            oCreatePayment.binary_mode = true;
            oCreatePayment.capture = true;
            oCreatePayment.external_reference = "";
            oCreatePayment.installments = 1; 
            oCreatePayment.notification_url = "https://intranet.catalogobata.pe/CatalogoBata/Pedido/Lista";
            oCreatePayment.payer = new PayerRequestDto
            {
                email = "test_user_17191298@testuser.com",
                first_name = "Pierr Antony",
                last_name = "Grimaldo Vidalon"
            };

            oCreatePayment.payer.identification = new PayerIdentificationDto()
            {
                type = "DNI",
                number = "76567465"
            };

            oCreatePayment.payment_method_id = "visa";
            oCreatePayment.token = "f5154a53d1684114a66cc4d0fcb9afc0";
            oCreatePayment.transaction_amount = 90;
             
            var response = mercadoPagoController.CreatePayment(oCreatePayment).Result;
            Assert.IsInstanceOfType(response, typeof(BadRequestObjectResult));
            Assert.AreEqual(10, oCreatePayment);
        }
    }
}
