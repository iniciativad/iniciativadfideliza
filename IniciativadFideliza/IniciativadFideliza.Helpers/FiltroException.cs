using System;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace IniciativadFideliza.Helpers
{
    public class FiltroException
    {
        public static string TrataErro(Exception error)
        {
            StackTrace trace = new StackTrace(error, true);
            string erroGerado = error.Message;
            int idNomeArquivo = trace.GetFrame(trace.FrameCount - 1).GetFileName().LastIndexOf('\\') + 1;
            string arquivo = trace.GetFrame(trace.FrameCount - 1).GetFileName().Substring(idNomeArquivo).ToString();
            string metodo = trace.GetFrame(trace.FrameCount - 1).GetMethod().Name;
            string linha = trace.GetFrame(trace.FrameCount - 1).GetFileLineNumber().ToString();

            string mensagem = "<b>Erro Gerado: </b>" + erroGerado + "<br/>" +
                "<b>Origem: </b>" + arquivo + "<br/>" +
                "<b>Método: </b>" + metodo + "<br/>" +
                "<b>Linha: </b>" + linha + "</br>";

            SendEmailErro("iniciativad@gmail.com", mensagem);
            return mensagem;


        }

        private static void SendEmailErro(string destinatario, string msg)
        {



            //crio objeto responsável pela mensagem de emai
            var objEmail = new MailMessage();
            //rementente do email
            objEmail.From = new MailAddress("contatoviasite@plennusconsultoria.com.br", "Morar Bem Brasil");

            //email para resposta(quando o destinatário receber e clicar em responder, vai para:)
            //objEmail.ReplyTo = new MailAddress("email@seusite.com.br");

            //destinatário(s) do email(s). Obs. pode ser mais de um, pra isso basta repetir a linha
            //abaixo com outro endereço
            objEmail.To.Add(destinatario);

            //se quiser enviar uma cópia oculta pra alguém, utilize a linha abaixo:            
            //objEmail.Bcc.Add("aldenorleal@plennusconsultoria.com.br");
            //objEmail.Bcc.Add("draluciane@plennusconsultoria.com.br");
            //objEmail.Bcc.Add("drarose@plennusconsultoria.com.br");
            //objEmail.Bcc.Add("marcio@plennusconsultoria.com.br");
            //objEmail.Bcc.Add("plennusconsultoria@gmail.com");
            //objEmail.Bcc.Add("iniciativad@gmail.com");

            //prioridade do email
            objEmail.Priority = MailPriority.Normal;

            //utilize true pra ativar html no conteúdo do email, ou false, para somente texto
            objEmail.IsBodyHtml = true;

            //Assunto do email
            objEmail.Subject = "Erro no sistema -  Data: " + DateTime.Now;

            //corpo do email a ser enviado

            objEmail.Body = msg;

            //codificação do assunto do email para que os caracteres acentuados serem reconhecidos.
            objEmail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");

            //codificação do corpo do emailpara que os caracteres acentuados serem reconhecidos.
            objEmail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");

            //cria o objeto responsável pelo envio do email
            SmtpClient objSmtp = new SmtpClient();

            //Porta
            objSmtp.Port = 587;

            //endereço do servidor SMTP(para mais detalhes leia abaixo do código)
            objSmtp.Host = "smtpi.plennusconsultoria.com.br";


            //para envio de email autenticado, coloque login e senha de seu servidor de email
            //para detalhes leia abaixo do código
            objSmtp.Credentials = new NetworkCredential("contatoviasite@plennusconsultoria.com.br", "gdc2014");
            //envia o email
            objSmtp.Send(objEmail);


        }
    }
}
