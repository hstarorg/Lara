using System.Net;
using System.Net.Mail;
using System.Text;

namespace Hstar.Lara.Mail
{
    public class Class1
    {
        public async void XXX()
        {
            SmtpClient smtpClient = new SmtpClient("smtp.163.com");
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("hm910705@163.com", "tempfile");
            var message = new MailMessage(new MailAddress("hm910705@163.com", "发件人", Encoding.UTF8), new MailAddress("1028332273@qq.com", "收件人", Encoding.UTF8))
            {
                Subject = "这是邮件标题",
                Body = "<p style=\"color:red;\">这是邮件内容</p>",
                IsBodyHtml = true
            };
            await smtpClient.SendMailAsync(message);
        }
    }
}