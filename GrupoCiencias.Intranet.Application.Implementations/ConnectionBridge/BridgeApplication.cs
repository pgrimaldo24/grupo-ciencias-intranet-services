﻿using GrupoCiencias.Intranet.Application.Interfaces.ConnectionBridge;
using GrupoCiencias.Intranet.CrossCutting.Common;
using GrupoCiencias.Intranet.CrossCutting.Common.Constants;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Application.Implementations.ConnectionBridge
{
    public class BridgeApplication : IBridgeApplication
    { 
        private readonly AppSetting _appSettings;

        public BridgeApplication(IOptions<AppSetting> appSettings)
        { 
            _appSettings = appSettings.Value;
        }
         
        public async Task<TResult> PostInvoque<T, TResult>(T obj, string detailUrlKey, string token, string typeRequest)
        {
            TResult result;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)(0xc0 | 0x300 | 0xc00);
            var request = HttpWebRequest.Create(detailUrlKey) as HttpWebRequest;
            request.Method = typeRequest;
            request.Headers = await GetHeaders(false ? ParameterHeaderOsb(obj, token) : ParameterHeader(obj, token));
            var data = JsonConvert.SerializeObject(obj);
            byte[] byteArray = Encoding.UTF8.GetBytes(data);
            request.ContentType = UtilConstants.ContentService.ContentTypeApplicationJson;
            request.ContentLength = byteArray.Length;
            request.Expect = UtilConstants.ContentService.ContentTypeApplicationJson;
            request.Accept = UtilConstants.ContentService.ContentTypeApplicationJson;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                    var responseString = reader.ReadToEnd();
                    result = JsonConvert.DeserializeObject<TResult>(responseString);
                }
            } 
            return result; 
        }

        public async Task<TResult> GetInvoque<T, TResult>(T obj, string detailUrlKey, string token, string typeRequest)
        {
            TResult result;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)(0xc0 | 0x300 | 0xc00);
            var request = (HttpWebRequest)WebRequest.Create(detailUrlKey);
            request.Method = typeRequest;
            Header(ref request, typeRequest);
            using (WebResponse response = request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                    var responseString = reader.ReadToEnd();
                    result = JsonConvert.DeserializeObject<TResult>(responseString);
                }
            } 
            return result;
        }

        #region Method private Headers
        private async Task<WebHeaderCollection> GetHeaders(Hashtable table)
        {
            WebHeaderCollection Headers = new WebHeaderCollection();
            foreach (DictionaryEntry entry in table)
            {
                Headers.Add(entry.Key.ToString(), entry.Value != null ? entry.Value.ToString() : null);
            }
            return Headers;
        }

        private Hashtable ParameterHeaderOsb(object Obj, string Token)
        {
            var paramHeaders = new Hashtable();
            paramHeaders.Add(UtilConstants.ContentService.Authorization, 
                UtilConstants.ContentService.Bearer + Token);
            return paramHeaders;
        }

        private Hashtable ParameterHeader(object Obj, string Token)
        {
            var paramHeaders = new Hashtable();
            string data = JsonConvert.SerializeObject(Obj);
            paramHeaders.Add(UtilConstants.ContentService.Authorization, 
                UtilConstants.ContentService.Bearer + Token);
            return paramHeaders;
        }

        private void Header(ref HttpWebRequest p_request, string p_Method)
        {
            p_request.ContentType = UtilConstants.ContentService.ContentType;
            p_request.Method = p_Method;
            p_request.Accept = UtilConstants.ContentService.Accept;
            p_request.Headers.Add(UtilConstants.ContentService.AcceptLanguage, "en-us\r\n");
            p_request.Headers.Add(UtilConstants.ContentService.UACPU, "x86 \r\n");
            p_request.Headers.Add(UtilConstants.ContentService.CacheControl, "no-cache\r\n");
            p_request.KeepAlive = true;
        }

        #endregion
    }
}