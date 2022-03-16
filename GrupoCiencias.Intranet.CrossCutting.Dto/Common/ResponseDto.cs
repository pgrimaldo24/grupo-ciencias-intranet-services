using GrupoCiencias.Intranet.CrossCutting.Common.Constants;
using GrupoCiencias.Intranet.CrossCutting.Common.Resources;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace GrupoCiencias.Intranet.CrossCutting.Dto.Common
{
    public class ResponseDto
    {
        public ResponseDto()
        {
            Status = UtilConstants.CodigoEstado.Ok;
            TransactionId = DateTime.Now.ToString(UtilConstants.DateTimeFormats.DD_MM_YYYY_HH_MM_SS_FFF);
            Message = AlertResources.msg_correcto;
            Data = new Dynamic();
        }

        public string TransactionId { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }

    [Serializable]
    public class Dynamic : DynamicObject, ISerializable
    {
        private Dictionary<string, object> dynamic = new Dictionary<string, object>();

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return (dynamic.TryGetValue(binder.Name, out result));
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            dynamic.Add(binder.Name, value);
            return true;
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            foreach (KeyValuePair<string, object> kvp in dynamic)
            {
                info.AddValue(kvp.Key, kvp.Value);
            }
        }

        public Dynamic()
        {
        }

        protected Dynamic(SerializationInfo info, StreamingContext context)
        {
            foreach (SerializationEntry entry in info)
            {
                dynamic.Add(entry.Name, entry.Value);
            }
        }

    }
}
