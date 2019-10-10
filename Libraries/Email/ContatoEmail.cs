using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Email
{
    public class ContatoEmail
    {
        public static void EnviarContatoPorEmail(Contato contato)
        {
            // SMTP - Para enviar mensagens
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("daisymonte@gmail.com", "");
            smtp.EnableSsl = true;

            string corpoMensagem = string.Format("<h2> Contato - Loja Virtual </h2>" +
                "<b> Nome: {0} </b><br/> " +
                "<b> Email: {1} </b><br/>" +
                "<b> Texto: {2} </b><br/>" +
                "Email enviado automaticamente do site loja virtual. <br/>",
                contato.Nome,
                contato.Email,
                contato.Texto);
            // MailMessage - Para construir mensagens
            MailMessage mensagem = new MailMessage();
            mensagem.From = new MailAddress("daisymonte@gmail.com");
            mensagem.To.Add("daisymonte@gmail.com");
            mensagem.Subject = "Contato - Loja Virtual";
            mensagem.Body = corpoMensagem;
            mensagem.IsBodyHtml = true;

            smtp.Send(mensagem);

        }
    }
}
