using System;
using MhorMail.Model;
using MhorMail.Services;
using MhorMail.Services.Abstract;
using NUnit.Framework;

namespace MhorMail.Integration.Tests
{
    [TestFixture]
    public class ConnectionTests
    {
        private readonly ServerConfiguration _serverDetails = new ServerConfiguration {ServerName = "mail.duncanlundie.co.uk",ServerPort = 143};
        private readonly string _password;
        public ConnectionTests()
        {
            _password = Environment.GetEnvironmentVariable("EmailPassword", EnvironmentVariableTarget.User);
        }

        [Test]
        public void CanConnect()
        {
            IAccountService accountService = new AccountService();
            var result = accountService.CanConnectToIMAPAccount(new IMAPAccountSettings
            {
                ServerDetails = _serverDetails,
               
                Username = "duncan@duncanlundie.co.uk",
                Password = _password
            });

            Assert.That(result.IsConnected,Is.True);
        }

        [Test]
        public void CanAuthenticate()
        {
            IAccountService accountService = new AccountService();
            var result = accountService.CanConnectToIMAPAccount(new IMAPAccountSettings
            {
                ServerDetails = _serverDetails,
                Username = "duncan@duncanlundie.co.uk",
                Password = _password
            });

            Assert.That(result.IsAuthenticated, Is.True);
        }

        [Test]
        public void WhenConnectedAndAuthenticatedSuccessReturnsTrue()
        {
            IAccountService accountService = new AccountService();
            var result = accountService.CanConnectToIMAPAccount(new IMAPAccountSettings
            {
                ServerDetails = _serverDetails,
                Username = "duncan@duncanlundie.co.uk",
                Password = _password
            });

            Assert.That(result.IsConnected, Is.True);
            Assert.That(result.IsAuthenticated, Is.True);
            Assert.That(result.Success, Is.True);
        }

        [Test]
        public void WhenConnectedAndAuthenticatedSuccessMessageIsSet()
        {
            IAccountService accountService = new AccountService();
            var result = accountService.CanConnectToIMAPAccount(new IMAPAccountSettings
            {
                ServerDetails = _serverDetails,
                Username = "duncan@duncanlundie.co.uk",
                Password = _password
            });

            Assert.That(result.IsConnected, Is.True);
            Assert.That(result.IsAuthenticated, Is.True);
            Assert.That(result.Success, Is.True);
            Assert.That(result.Message,Is.EqualTo("Connection Successfull"));
        }

        [Test]
        public void WhenAuthenticationFailsCorrectErrorIsReceived()
        {
            IAccountService accountService = new AccountService();
            var result = accountService.CanConnectToIMAPAccount(new IMAPAccountSettings
            {
                ServerDetails = _serverDetails,
                Username = "duncan@duncanlundie.co.uk",
                Password = "notMyPassword"
            });

            Assert.That(result.IsAuthenticated, Is.False);
            Assert.That(result.Success, Is.False);
            Assert.That(result.Message, Is.EqualTo("Unable to authenticate user"));
        }

        [Test]
        public void WhenConnectionFailsCorrectErrorMessageIsReceived()
        {
            IAccountService accountService = new AccountService();
            var result = accountService.CanConnectToIMAPAccount(new IMAPAccountSettings
            {
                ServerDetails = new ServerConfiguration() {ServerName = "oopsie.duncanlundie.co.uk",ServerPort = 143},
                Username = "duncan@duncanlundie.co.uk",
                Password = _password
            });

            Assert.That(result.IsConnected, Is.False);
            Assert.That(result.Success, Is.False);
            Assert.That(result.Message, Is.EqualTo("Unable to connect to server"));
        }
    }
}
