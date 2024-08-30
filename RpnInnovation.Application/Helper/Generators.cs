using RpnInnovation.Application.Features.Email;
using RpnInnovation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpnInnovation.Domain.Helper
{
    public static class Generators
    {
        public static EmailResponse CreateWelcomeEmail(CustomerAccount createCst, Account createAccount)
        {
            try
            {
                var sb = new StringBuilder();
                sb.AppendLine($"<h3>Hello {createCst.FirstName},</h3>");
                sb.AppendLine($"<p>Thank you for choosing to bank with us, here is your newly created account number:</p>");
                sb.AppendLine($"<p><b>{createAccount.AccountNumber}</b></p>");

                sb.AppendLine($"<p>Warm Regards,</p>");

                var message = sb.ToString();
                var subject = $"Welcome to RpniBank";
                var response = EmailResponse.Copy(message,subject, createAccount, createCst);
                return response;
            }
            catch (Exception ex){
                return new EmailResponse();
            }
        }

        public static string GenerateAccountNumber(int length = 10)
        {
            const string chars = "0123456789";
            StringBuilder result = new StringBuilder(length);
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }

            return result.ToString();
        }
    }
}
