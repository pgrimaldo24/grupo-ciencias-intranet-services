﻿using GrupoCiencias.Intranet.Application.Interfaces.Intranet;
using GrupoCiencias.Intranet.CrossCutting.Common;
using GrupoCiencias.Intranet.CrossCutting.Dto.Common;
using GrupoCiencias.Intranet.CrossCutting.Dto.Master;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Application.Implementations.Intranet
{
    public class MasterApplication : IMasterApplication
    {

        public MasterApplication(IOptions<AppSetting> appSettings)
        {

        }

        public async Task<ResponseDto> MasterDropDownlistAsync(MasterDto masterDto)
        {
            throw new NotImplementedException();
        }
    }
}
