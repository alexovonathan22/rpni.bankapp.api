using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpnInnovation.Application.Features.Email
{
    public interface IEmailService
    {
        bool SendEmailAsync(EmailResponse email);
        Task<bool> SendEmailWithAttachmentAsync(string email);
    }
}
