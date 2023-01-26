using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntities;
using DataAccess;

namespace DataLogic
{
    public class MessageLogic
    {
        MessageAccess dao = new MessageAccess();

        public Message NewMessage(Message model)
        {
            Message message = new Message();

            message = dao.NewMessage(model);

            return message;
        }
    }
}
