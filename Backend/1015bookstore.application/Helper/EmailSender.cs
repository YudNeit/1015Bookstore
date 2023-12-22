using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using _1015bookstore.utility.Exceptions;

namespace _1015bookstore.application.Helper
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configguration;

        public EmailSender(IConfiguration configuration) 
        {
            _configguration = configuration;
        }
        public async Task SendEmailForgotPassword(string emailTo, string code)
        {

            var smtpsetting = _configguration.GetSection("SMTPConfig");

            MailMessage mail = new MailMessage()
            {
                From = new MailAddress(smtpsetting.GetSection("smtp_username").Value),
                IsBodyHtml = true,
                Subject = "Mã xác nhận cấp lại mật khẩu",
                Body = $"<h1>Mã xác nhận của bạn là</h1><br><b>{code}</b>",
            };
            mail.To.Add(new MailAddress(emailTo));

            SmtpClient smtp = new SmtpClient()
            {
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(smtpsetting.GetSection("smtp_username").Value, smtpsetting.GetSection("smtp_password").Value),
                Host = "smtp.gmail.com",
            };

            try
            {
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                throw new _1015Exception(ex.Message);
            }
        }
    }
}
