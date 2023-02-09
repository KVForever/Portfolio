﻿using DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesLibrary
{
    public interface IMessageRepository
    {
        public List<UserMessage> GetMessageByName(string name);

        public List<UserMessage> GetAllMessages();

        public void AddMessage(UserMessage message);


        public void DeleteMessage(Guid id);
    }
}
