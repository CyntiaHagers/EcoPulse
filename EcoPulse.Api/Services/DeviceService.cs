using EcoPulse.Api.Models;
using MongoDB.Driver;

namespace EcoPulse.Api.Services
{
    public class DeviceService
    {
        private readonly IMongoCollection<Device> _devices;

        public DeviceService(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("ecopulse_esg");
            _devices = database.GetCollection<Device>("devices");
        }

        public List<Device> Get()
        {
            return _devices.Find(_ => true).ToList();
        }
    }
}