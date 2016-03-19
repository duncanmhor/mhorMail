using System;
using MailKit.Net.Imap;
using MhorMail.Model;
using MhorMail.Services.Abstract;

namespace MhorMail.Services
{
    public class AccountService : IAccountService
    {
        public ConnectionResult CanConnectToIMAPAccount(IMAPAccountSettings userImapAccountSettings)
        {
            var result = new ConnectionResult();

            using (var client = new ImapClient())
            {
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                try
                {
                    client.Connect(userImapAccountSettings.ServerDetails.ServerName, userImapAccountSettings.ServerDetails.ServerPort);
                    result.IsConnected = client.IsConnected;
                    if(result.IsConnected)
                    {
                        try
                        {
                            client.Authenticate(userImapAccountSettings.Username, userImapAccountSettings.Password);
                            result.IsAuthenticated = client.IsAuthenticated;
                            result.Message = "Connection Successfull";
                        }
                        catch (Exception)
                        {
                            var unableToAuthenticateUser = "Unable to authenticate user";
                            result.Message = unableToAuthenticateUser; 
                            Console.WriteLine(unableToAuthenticateUser);
                        }
                    }
                }
                catch (Exception)
                {
                    var unableToConnectToServer = "Unable to connect to server";
                    result.Message = unableToConnectToServer;
                    Console.WriteLine(unableToConnectToServer);
                }
            }

            return result;
        }
    }
}
