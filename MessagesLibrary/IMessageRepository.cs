using DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesLibrary
{
    public interface IMessageRepository
    {
        public List<UserMessages> GetMessageByName(string name);

        public UserMessages GetMessageById(Guid id);

        public List<UserMessages> GetAllMessages();

        public void AddMessage(UserMessages message);

        public void DeleteMessage(Guid id);
    }
}
