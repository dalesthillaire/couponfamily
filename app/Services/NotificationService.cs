using System.Collections.Generic;
using app.Models;

namespace app.Services
{
    public class NotificationService
    {
        public bool  SendMessage(List<string> phoneNumbers, Deal deal)
        {
            var message = $"{deal.Detail}";
            foreach (var phone in phoneNumbers)
            {
                //call the twilio function here with the phone number and message here
            }
            return true;
        }
    }
}