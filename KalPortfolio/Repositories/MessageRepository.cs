using DataEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace MessagesLibrary
{
    public class MessageRepository : IMessageRepository
    {
        private readonly PortfolioContext _dbContext;

        public MessageRepository(PortfolioContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<UserMessage> GetAllMessages()
        {
            var allMessages = _dbContext.UserMessages.ToList();

            return allMessages;
        }

        public List<UserMessage> GetMessageByName(string name)
        {
            var message = GetAllMessages().Where(u => u.LastName.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return message;
        }

        public UserMessage GetMessageById(int id)
        {
            try
            {
                var message = GetAllMessages().FirstOrDefault(u => u.Id == id);

                if (message != null)
                {
                    return message;
                }
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException("This message can not be found in the database.");
            }

            UserMessage messages = new();

            return messages;

        }

        public void AddMessage(UserMessage message)
        {
            _dbContext.Add(message);
            _dbContext.SaveChanges();
        }

        public void DeleteMessage(int id)
        {
            var message = _dbContext.UserMessages.FirstOrDefault(u => u.Id == id);

            if (message != null)
            {
                _dbContext.UserMessages.Remove(message);
                _dbContext.SaveChanges();
            }

        }

    }
}
