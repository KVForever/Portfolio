using DataEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
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

        public async Task<IEnumerable<UserMessage>> GetAllMessages()
        {
            var allMessages = await _dbContext.UserMessages.Where(u => u.IsDeleted != true).ToListAsync();

            return allMessages;
        }

        public async Task<List<UserMessage>> GetMessagesByName(string lastName)
        {
            var messages = await _dbContext.UserMessages.Where(u => u.LastName.Contains(lastName) && u.IsDeleted == false).ToListAsync();
                
            return messages;
        }

        public async Task<UserMessage> GetMessageById(int id)
        {
            try
            {
                var message = await _dbContext.UserMessages.Where(u => u.Id == id && u.IsDeleted == false).FirstOrDefaultAsync();

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

        public async Task<UserMessage> AddMessage(UserMessage message)
        {
            message.DateCreated = DateTime.Now;
            message.DateModified = DateTime.Now;  

            _dbContext.Add(message);
            await _dbContext.SaveChangesAsync();

            return (message);
        }

        public async Task<bool> DeleteMessage(int id)
        {
            var message = await _dbContext.UserMessages.Where(u => u.Id == id).FirstOrDefaultAsync();

            if (message != null)
            {
                message.IsDeleted = true;
                await _dbContext.SaveChangesAsync();
            }

            return true;
        }

    }
}
