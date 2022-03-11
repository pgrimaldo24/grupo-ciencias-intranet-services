using Autofac;
using GrupoCiencias.Intranet.Application.Interfaces.Matricula;
using GrupoCiencias.Intranet.CrossCutting.Common;
using GrupoCiencias.Intranet.CrossCutting.IoC.Container;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Api.Controllers.Matricula
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : Controller
    { 
        private readonly Lazy<IProcesoMatricula> _procesoMatriculaApplication;

        public MatriculaController(IOptions<AppSetting> appSettings)
        {
            _procesoMatriculaApplication = new Lazy<IProcesoMatricula>(() => IoCAutofacContainer.Current.Resolve<IProcesoMatricula>()); 
        }



    }
}
