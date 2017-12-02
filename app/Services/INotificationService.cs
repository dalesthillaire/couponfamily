using System.Collections.Generic;
using app.Models;

namespace app.Services
{
    public interface INotificationService
    {
        bool SendMessage(List<string> phoneNumbers, Deal deal);
    }
}