using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace Negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient();
            //server.Credentials = new NetworkCredential("juancruzrey1@hotmail.com", "");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.live.com";
        }

        public void armarCorreo(string emailDestino, string asunto, string cuerpo)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@ecommerceprogramacioniii.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            email.Body = "<h1>Hola, recibiste un mail exitoso!!</h1>";
            //email.Body = cuerpo;

        }


        public void armarCorreoSimple(string emailDestino)
        {
            email = new MailMessage();
            //quien envia el correo, en este caso el usuario
            email.From = new MailAddress(emailDestino); 
            //quien recibe (consultar maxi)
            email.To.Add("juancruzrey1@hotmail.com");

            email.Subject = "Reset Password";
            email.IsBodyHtml = true;
            email.Body = "<h1>Solicitud de Reseteo de Password</h1> <br> Requiero una nueva Clave. Saludos cordiales!";
            //email.Body = cuerpo;
        }

        public void enviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
