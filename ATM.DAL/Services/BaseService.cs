using ATM.BL.Models;
using ATM.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Utils.Data;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;

namespace ATM.DAL.Services
{
    /// <summary>
    /// Base Service
    /// </summary>
    public class BaseService
    {
        private readonly ApplicationDbContext _dbContext;

        //todo: create multiple services by logic type Device, Customer etc.
        public BaseService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetUserByUsernameAsync(string userName)
        {
            var u = await (_dbContext.Users.Where(s => s.UserName == userName).FirstOrDefaultAsync<User>());

            return u;
        }

        public string ReadData()
        {
            JObject data = JObject.Parse(File.ReadAllText(@"./connection_info.json"));
            string connectioninfo = JsonConvert.SerializeObject(data);
            return connectioninfo;
        }

        public async Task<PairingToken> Ca(string token)
        {
            var u = await (_dbContext.PairingTokens.Where(x => x.Token == token).FirstOrDefaultAsync<PairingToken>());
            return u;
        }

        public async Task<List<User>> GetUsersListAsync()
        {
            var u = await (_dbContext.Users.ToListAsync<User>());

            return u;
        }

        public async Task<DataPagingUtils.PagedResult<Device>> GetDevicesPagedAsync(int page, int pageSize = 10)
        {
            var u = await (_dbContext.Devices).GetPagedResultAsync(page, pageSize);
            return u;
        }

        public async Task<List<Device>> GetDevicesListAsync()
        {
            var u = await (_dbContext.Devices).ToListAsync();
            return u;
        }

        public async Task<DataPagingUtils.PagedResult<PairingToken>> GetMachinesPagedAsync(int page, int pageSize = 10)
        {
            var u = await (_dbContext.PairingTokens).GetPagedResultAsync(page, pageSize);

            return u;
        }

        public async Task<Device> GetDeviceByIdAsync(int deviceId)
        {
            var u = await (_dbContext.Devices.Where(x => x.Id == deviceId).FirstOrDefaultAsync<Device>());

            return u;
        }

        public async Task<DataPagingUtils.PagedResult<Log>> GetLogsPagedAsync(int page, int pageSize = 10)
        {
            var u = await (_dbContext.Logs).GetPagedResultAsync(page, pageSize);

            return u;
        }

        public async Task<Device> AddDeviceAsync(Device d)
        {
            _dbContext.Devices.Add(d);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
            return d;
        }

        public async Task<Log> InsertLogAsync(string deviceId, string txt, string logLevel = "info")
        {
            var d = new Log
            {
                Id = Guid.NewGuid(),
                DeviceId = deviceId,
                LogLevel = logLevel,
                Message = txt,
                Serial = 0
            };

            try
            {
                _dbContext.Logs.Add(d);

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }

            return d;
        }

        public async Task<PairingToken> CreatePairingTotemAsync(string name)
        {
            var u = new BL.Models.PairingToken
            {
                Name = name,
                Token = RandomPassword()       //todo: protocol, host, port should be added to the token string (extracted from appSettings.json) example: https://www.xxx.com:443
            };

            try
            {
                _dbContext.PairingTokens.Add(u);

                await _dbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {

            }

            return u;
        }

        private string RandomPassword()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(35, true));
            builder.Append(RandomNumber(1000, 9999));
            builder.Append(RandomString(10, false));
            var totem = builder.ToString();
            return totem;
        }

        private int RandomNumber(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max);
        }

        private string RandomString(int size, bool lowerCase)
        {
            var builder = new StringBuilder();
            var random = new Random();
            char ch;

            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }

        public async Task<Device> PairDeviceAsync(string machineName, bool isPaired)
        {
            try
            {
                var u = await (_dbContext.Devices.Where(device => device.DeviceId == machineName).FirstOrDefaultAsync<Device>());
                u.Paired = isPaired;

                await _dbContext.SaveChangesAsync();

                return u;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
