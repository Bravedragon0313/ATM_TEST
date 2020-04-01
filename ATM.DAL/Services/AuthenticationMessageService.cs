using ATM.BL.Models;
using ATM.DAL.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace ATM.DAL.Services
{
    /// <summary>
    /// Authentication Message Service
    /// </summary>
    public class AuthenticationMessageService
    {
        private readonly ApplicationDbContext _dbContext;

        public AuthenticationMessageService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AuthenticationMessage> SendAuthenticationMessageAsync(string deviceId, Guid customerId, string phoneNumber, string messageText, bool isSms)
        {
            if (isSms)
            {
                // TODO : this should not be here !!!!!
                var config = new ConfigurationBuilder()
                    .AddJsonFile("appconfig.json")
                    .Build();

                //TODO: refactor 
                var accountSid = config["accountId"];
                var authToken = config["authToken"];
                var sendFrom = config["phonenumber"];

                TwilioClient.Init(accountSid, authToken);

                var message = await MessageResource.CreateAsync(
                    body: messageText,
                    from: new Twilio.Types.PhoneNumber(sendFrom),
                    to: new Twilio.Types.PhoneNumber(phoneNumber));

                var m = new AuthenticationMessage
                {
                    Customer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == customerId),
                    Data = messageText,
                    Device = await _dbContext.Devices.FirstOrDefaultAsync(x => x.DeviceId == deviceId),
                    DateCreated = DateTime.Now,
                    IsUsed = false
                };

                _dbContext.AuthenticationMessages.Add(m);

                await _dbContext.SaveChangesAsync();

                return m;
            }

            return null;
        }
    }
}
