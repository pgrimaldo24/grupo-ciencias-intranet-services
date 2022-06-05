using GrupoCiencias.Intranet.Application.Interfaces.MailManager;
using GrupoCiencias.Intranet.CrossCutting.Common;
using GrupoCiencias.Intranet.CrossCutting.Common.Constants;
using GrupoCiencias.Intranet.CrossCutting.Common.Resources;
using GrupoCiencias.Intranet.CrossCutting.Dto.Common;
using GrupoCiencias.Intranet.CrossCutting.Dto.MailManager;
using GrupoCiencias.Intranet.CrossCutting.Dto.MailManager.User;
using GrupoCiencias.Intranet.CrossCutting.IoC.Container;
using GrupoCiencias.Intranet.Domain.Models.Entity;
using GrupoCiencias.Intranet.Repository.Interfaces.Data;
using GrupoCiencias.Intranet.Repository.Interfaces.Repositories.MailManager;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Application.Implementations.MailManager
{
    public class MailManagerApplication : IMailManagerApplication
    { 
        private readonly MailManagers _appMailManagers;
        private readonly Lazy<IUnitOfWork> _unitOfWork;

        public MailManagerApplication(IOptions<MailManagers> appMailManagers)
        { 
            _appMailManagers = appMailManagers.Value;
            _unitOfWork = new Lazy<IUnitOfWork>(() => IoCAutofacContainer.Current.Resolve<IUnitOfWork>());
        }
         
        private IUnitOfWork UnitOfWork => _unitOfWork.Value;
        private IMailManagerRepository MailManagerRepository => UnitOfWork.Repository<IMailManagerRepository>();

        public async Task<ResponseDto> SendEmailAsync(UserRequestDto userRequest)
        {
            var response = new ResponseDto(); 
            var oStudent = MailManagerRepository.GetStudentAsync(userRequest.id_student_request, userRequest.document_number).Result;
            var oMailBox = MailManagerRepository.GetMailBoxAsync(userRequest.notification_type).Result;
            var oKeyapp = MailManagerRepository.GetCredentialAsync(oMailBox.TipoNotificacion).Result;
            var email_domain = oStudent.email.Split('@')[1].ToString();

            var omailBoxDto = new SendInformationMail()
            {
                outbox = oMailBox.Buzonsalida.ToString(),
                outbox_key = oKeyapp.Clave.ToString(),
                outbox_receiver = oStudent.email.ToString().Trim(),
                asunto = oMailBox.Asunto.ToString(),
                body = oMailBox.Cuerpocorreo.ToString()
            };

            var data = await ValidateEmailDomainAsync(omailBoxDto, email_domain);

            if (!string.IsNullOrEmpty(data))
            {
                if (data.Equals(UtilConstants.CodigoEstado.Ok.ToString()))
                {
                    response.Status = UtilConstants.CodigoEstado.Ok;
                    response.Message = AlertResources.msg_alerta_envio_correo.ToString(); 
                }
                else
                {
                    response.Status = UtilConstants.CodigoEstado.InternalServerError;
                    response.Message = data.ToUpper().ToString();
                }
            } 

            return response; 
        } 

        private async Task<string> ValidateEmailDomainAsync(SendInformationMail mailbox, string email_domain)
        {
            var response = string.Empty;
            var oMail = new MailBoxDto();
            var omailDto = new MailBoxDto();
           
            try
            { 
                switch (email_domain)
                {
                    case UtilConstants.EmailDomain.HOTMAIL:
                        #region HOTMAIL
                        oMail.host = _appMailManagers.MSN.host_hotmail;
                        oMail.port = int.Parse(_appMailManagers.MSN.port_hotmail);
                        oMail.ssl = bool.Parse(_appMailManagers.MSN.ssl_hotmail);
                        oMail.default_credentials = bool.Parse(_appMailManagers.MSN.defaultcredentials_hotmail);
                        omailDto = await SetInformationMail(mailbox, oMail);
                        await SendMailAsync(omailDto); 
                        break;
                        #endregion
                    case UtilConstants.EmailDomain.GMAIL:
                        #region GMAIL
                        oMail.host = _appMailManagers.Gmail.host_gmail;
                        oMail.port = int.Parse(_appMailManagers.Gmail.port_gmail);
                        oMail.ssl = bool.Parse(_appMailManagers.Gmail.ssl_gmail);
                        oMail.default_credentials = bool.Parse(_appMailManagers.Gmail.defaultcredentials_gmail);
                        omailDto = await SetInformationMail(mailbox, oMail);
                        await SendMailAsync(omailDto);
                        break;
                        #endregion
                    case UtilConstants.EmailDomain.OUTLOOK:
                        #region OUTLOOK
                        oMail.host = _appMailManagers.Outlook.host_outlook;
                        oMail.port = int.Parse(_appMailManagers.Outlook.port_outlook);
                        oMail.ssl = bool.Parse(_appMailManagers.Outlook.ssl_outlook);
                        oMail.default_credentials = bool.Parse(_appMailManagers.Outlook.defaultcredentials_outlook);
                        omailDto = await SetInformationMail(mailbox, oMail);
                        await SendMailAsync(omailDto);
                        break;
                        #endregion
                    default:
                        #region Default
                        oMail.host = _appMailManagers.Outlook.host_outlook;
                        oMail.port = int.Parse(_appMailManagers.Outlook.port_outlook);
                        oMail.ssl = bool.Parse(_appMailManagers.Outlook.ssl_outlook);
                        oMail.default_credentials = bool.Parse(_appMailManagers.Outlook.defaultcredentials_outlook);
                        omailDto = await SetInformationMail(mailbox, oMail);
                        await SendMailAsync(omailDto);
                        break;
                        #endregion
                } 
                response = UtilConstants.CodigoEstado.Ok.ToString();
            }
            catch (Exception ex)
            {
                response = UtilConstants.CodigoEstado.InternalServerError.ToString() + " " + ex.Message; 
            }
            
            return response;
        }

        private async Task<MailBoxDto> SetInformationMail(SendInformationMail mailbox, MailBoxDto mailBox)
        {
            var mailboxDto = new MailBoxDto();
            mailboxDto.send_information_mail = new SendInformationMail(); 
            mailboxDto.send_information_mail.outbox = mailbox.outbox;
            mailboxDto.send_information_mail.outbox_key = mailbox.outbox_key;
            mailboxDto.send_information_mail.outbox_receiver = mailbox.outbox_receiver;
            mailboxDto.send_information_mail.asunto = mailbox.asunto;
            mailboxDto.send_information_mail.body = mailbox.body;
            mailboxDto.host = mailBox.host;
            mailboxDto.port = mailBox.port;
            mailboxDto.ssl = mailBox.ssl;
            mailboxDto.default_credentials = mailBox.default_credentials; 
            return mailboxDto;
        }

        private async Task SendMailAsync(MailBoxDto mailBoxDto)
        {
            var mailMessage = new MailMessage(); 
             
            var usermail = mailBoxDto.send_information_mail.outbox.ToString();
            var userkey = mailBoxDto.send_information_mail.outbox_key.ToString();

            mailMessage.From = new MailAddress(usermail);
            mailMessage.To.Add(new MailAddress(mailBoxDto.send_information_mail.outbox_receiver));
            mailMessage.Subject = mailBoxDto.send_information_mail.asunto.ToString().ToUpper();
            mailMessage.Body = mailBoxDto.send_information_mail.body;
            mailMessage.IsBodyHtml = true;
            mailMessage.Priority = MailPriority.Normal;

            var oSmtpServer = mailBoxDto.host;
            var port = mailBoxDto.port;
            var ssl = mailBoxDto.ssl;
            var defaultCredentials = mailBoxDto.default_credentials;

            var smtpClient = new SmtpClient(); 
            smtpClient.Host = oSmtpServer;
            smtpClient.Port = port;
            smtpClient.EnableSsl = ssl;
            smtpClient.UseDefaultCredentials = defaultCredentials;

            NetworkCredential networkCredential = new NetworkCredential(usermail, userkey);

            smtpClient.Credentials = networkCredential;
            smtpClient.Send(mailMessage); 
        }  
    }
}
