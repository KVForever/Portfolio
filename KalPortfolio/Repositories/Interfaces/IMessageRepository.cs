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
        public Task<IEnumerable<UserMessage>> GetMessagesByName(string name);

        public Task<UserMessage> GetMessageById(int id);

        public Task<IEnumerable<UserMessage>> GetAllMessages();

        public Task<UserMessage> AddMessage(UserMessage message);

        public Task<bool> DeleteMessage(int id);
    }
}
