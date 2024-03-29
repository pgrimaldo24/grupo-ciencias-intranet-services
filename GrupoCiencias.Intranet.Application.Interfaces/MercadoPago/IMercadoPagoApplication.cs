﻿using GrupoCiencias.Intranet.CrossCutting.Dto.Common;
using GrupoCiencias.Intranet.CrossCutting.Dto.MercadoPago;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Application.Interfaces.MercadoPago
{
    public interface IMercadoPagoApplication
    {
        Task<ResponseDto> CardTokenAsync(CardTokenDto cardTokenDto);
        Task<ResponseDto> PaymentMethodAsync(string binCard);
        Task<ResponseDto> CreatePaymentAsync(StudentPaymentDto studentPaymentDto);
        Task<ResponseDto> IdentificationTypesAsync();
        Task<ResponseDto> CardValidationAsync();
        Task<ResponseDto> NotificationWebhooksAsync(string notificaction_url);
    }
}
