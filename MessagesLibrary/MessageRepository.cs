using DataEntities;
using Microsoft.EntityFrameworkCore;
using System.CodeDom;

namespace MessagesLibrary
{
    public class MessageRepository: IMessageRepository
    {
        private readonly PortfolioContext _dbContext;

        public MessageRepository(PortfolioContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<UserMessages> GetAllMessages()
        {
            var allMessages = _dbContext.UserMessages.ToList();

            return allMessages;
        }

        public List<UserMessages> GetMessageByName(string name)
        { 
            var message = GetAllMessages().Where(x => x.LastName.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();

            return message;
        }

        public UserMessages GetMessageById(Guid id)
        { 
            try
            {
                var message = GetAllMessages().FirstOrDefault(x => x.Id == id);

                if(message != null)
                {
                    return message;
                }
            }
            catch(KeyNotFoundException)
            {
                throw new KeyNotFoundException("This message can not be found in the database.");
            }
            
           UserMessages messages = new();

            return messages;
                
        }

        public void AddMessage(UserMessages message)
        {
            _dbContext.Add(message);
            _dbContext.SaveChanges();
        }

        public void DeleteMessage(Guid id)
        {
            var message = _dbContext.UserMessages.FirstOrDefault(x => x.Id == id);
            if(message != null)
            {
                _dbContext.UserMessages.Remove(message);
                _dbContext.SaveChanges();
            }
           
        }

    }
}
