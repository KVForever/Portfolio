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

        public List<UserMessage> GetMessageByName(string name)
        {
            if(GetAllMessages().Any())
            {
                 var message = GetAllMessages().Where(x => x.LastName.Contains(name)).ToList();
                return message;
            }
            List<UserMessage> error = new List<UserMessage>(0);
            return error;
            
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
