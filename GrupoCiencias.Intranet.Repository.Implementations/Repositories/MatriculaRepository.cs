﻿using GrupoCiencias.Intranet.CrossCutting.Dto.Matricula;
using GrupoCiencias.Intranet.CrossCutting.Dto.MercadoPago;
using GrupoCiencias.Intranet.Domain.Models.Entity;
using GrupoCiencias.Intranet.Repository.Implementations.Data;
using GrupoCiencias.Intranet.Repository.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Repository.Implementations.Repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {
        private readonly DataContext context;
        public MatriculaRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<ApoderadoDetalleDto> GetIdApoderadoAsync(string nroDocumento)
        {
            return await context.Apoderado
                    .Where(x => x.Dni == nroDocumento)
                    .OrderByDescending(x => x.Idapoderado)
                    .Take(1)
                    .Select(p => new ApoderadoDetalleDto { IdApoderado = p.Idapoderado }).FirstOrDefaultAsync();
        }

        public async Task<PreciosMatriculaDto> EnrollmentPricesListAsync(int IdPeriod, int IdPaymentType)
        {
            return await context.TipoPagoDetalle.Where(x => x.Idciclo == IdPeriod && x.Idtipopago == IdPaymentType)
                  .Select(precioMatricula => new PreciosMatriculaDto
                  {
                      id_detail_payment = precioMatricula.Idpagodetalle,
                      sub_total = precioMatricula.Subtotal,
                      discount = precioMatricula.Descuento,
                      final_price = precioMatricula.Preciofinal,
                  })
                  .FirstOrDefaultAsync();
        }

        public async Task<HistorialPagoSolicitudEntity> GetIdHistoryPaymentTransaction(int id_payment_transaction)
        {
            return await context.HistorialPagoSolicitudes.Where(x => x.IdTransaccionPago == id_payment_transaction)
              .Select(hpsd => new HistorialPagoSolicitudEntity
              {
                  IdHistorialPagoSolicitud = hpsd.IdHistorialPagoSolicitud,
                  IdTransaccionPago = hpsd.IdTransaccionPago,
                  Fechacreacion = hpsd.Fechacreacion 
              }).FirstOrDefaultAsync();
        }

        public async Task<SolicitudesEntityDto> GetIdEnrollmentByDocumentNumber(string nroDocumento)
        {
            return await context.Solicitudes
                   .Where(x => x.Dni == nroDocumento)
                   .OrderByDescending(x => x.Idsolicitud)
                   .Take(1)
                   .Select(p => new SolicitudesEntityDto { Idsolicitud = p.Idsolicitud }).FirstOrDefaultAsync();
        }
    }
}
