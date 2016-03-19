using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MhorMail.Model;

namespace MhorMail.Services.Abstract
{
    public interface IAccountService
    {
        ConnectionResult CanConnectToIMAPAccount(IMAPAccountSettings userImapAccountSettings);

    }
}
