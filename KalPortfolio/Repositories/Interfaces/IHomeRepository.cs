using DataEntities;
using KalPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesLibrary
{
    public interface IHomeRepository
    {
        public Task<IEnumerable<UserMessage>> GetMessagesByName(string name);

        public Task<UserMessage> GetMessageById(int id);

        public Task<IEnumerable<UserMessage>> GetAllMessages();

        public Task AddMessage(UserMessage message);

        public Task<bool> DeleteMessage(int id);

        public Task AddRating(StarRating starRating);
    }
}
