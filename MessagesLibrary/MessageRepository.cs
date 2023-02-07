using DataEntities;


namespace MessagesLibrary
{
    public class MessageRepository: IMessageRepository
    {
        private readonly PortfolioMessagesContext _dbContext;

        public MessageRepository(PortfolioMessagesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<UserMessage> GetAllMessages()
        {
            var allMessages = _dbContext.UserMessages.ToList();
            return allMessages;
        }

        public UserMessage GetMessageByName(string name)
        {
            var message = _dbContext.UserMessages.FirstOrDefault(x => x.LastName == name);
            return message;
        }

        public void AddMessage(UserMessage message)
        {
            _dbContext.Add(message);
            _dbContext.SaveChanges();
        }

        public void DeleteMessage(Guid id)
        {
            var message = _dbContext.UserMessages.FirstOrDefault(x => x.Id == id);
            _dbContext.UserMessages.Remove(message);
            _dbContext.SaveChanges();
        }


    }
}
