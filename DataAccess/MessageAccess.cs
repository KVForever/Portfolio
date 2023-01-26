using DataEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MessageAccess : PortfolioMessagesContext
    {  
        public Message NewMessage(Message model)
        {
            Message message = new Message();
            message.Id = model.Id;
            message.FirstName = model.FirstName;
            message.LastName = model.LastName;
            message.Email = model.Email;
            message.Subject = model.Subject;
            message.Message1 = model.Message1;

            return message;
        }
    }
}
