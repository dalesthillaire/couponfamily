using System.Collections.Generic;
using app.Models;
using Microsoft.AspNetCore.Authentication;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace app.Services
{
    public class NotificationService : INotificationService
    {
        private readonly string _accountSid;
        private readonly string _authenticationToken;
        private readonly string _accountPhone;

        public NotificationService(string accountSid, string authenticationToken, string accountPhone)
        {
            _accountSid = accountSid;
            _authenticationToken = authenticationToken;
            _accountPhone = accountPhone;

            TwilioClient.Init(accountSid, authenticationToken);
        }

        public bool  SendMessage(List<string> phoneNumbers, Deal deal)
        {
            //build the message body based on the deal
            var messageBody = $"{deal.Detail}";

            //for each subscriber create the message sent via sms
            foreach (var subScriberPhone in phoneNumbers)
            {
                var message = MessageResource.Create(
                    to: new PhoneNumber("+${subScriberPhone}"),
                    from: new PhoneNumber("+${_accountPhone}"),
                    body: messageBody);
            }
            return true;
        }
    }
}