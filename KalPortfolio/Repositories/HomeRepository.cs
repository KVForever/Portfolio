using DataEntities;
using KalPortfolio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace MessagesLibrary
{
    public class HomeRepository : IHomeRepository
    {
        private readonly PortfolioContext dbContext;

        public HomeRepository(PortfolioContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<UserMessage>> GetAllMessages()
        {
            var allMessages = await dbContext.UserMessages.Where(u => u.IsDeleted != true).ToListAsync();

            return allMessages;
        }

        public async Task<IEnumerable<UserMessage>> GetMessagesByName(string lastName)
        {

            var messages = await dbContext.UserMessages.Where(u =>  EF.Functions.Like(u.LastName, lastName + "%") && u.IsDeleted == false).ToListAsync();

            if(lastName == null)
            {
                var allMessages = await dbContext.UserMessages.Where(u => u.IsDeleted != true).ToListAsync();
                return allMessages;
            }    
            return messages;
        }

        public async Task<UserMessage> GetMessageById(int id)
        {
            
            var message = await dbContext.UserMessages.Where(u => u.Id == id && u.IsDeleted == false).FirstOrDefaultAsync();

            if (message != null)
            {
                return message;
            }
            return null;

        }

        public async Task<UserMessage> AddMessage(UserMessage message)
        {
            message.DateCreated = DateTime.Now;
            message.DateModified = DateTime.Now;  

            dbContext.Add(message);
            await dbContext.SaveChangesAsync();

            return (message);
        }

        public async Task<bool> DeleteMessage(int id)
        {
            var message = await dbContext.UserMessages.Where(u => u.Id == id).FirstOrDefaultAsync();

            if (message != null)
            {
                message.IsDeleted = true;
                await dbContext.SaveChangesAsync();
            }

            return true;
        }

        public async Task<bool> AddRating(StarRating starRating)
        {
            starRating.DateRated = DateTime.Now;

            dbContext.Add(starRating);
            await dbContext.SaveChangesAsync();
            
            return true;
        }

    }
}
