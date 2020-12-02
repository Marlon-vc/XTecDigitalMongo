using System.Collections.Generic;
using MongoDB.Driver;
using XTecDigitalMongo.Models;

namespace XTecDigitalMongo.Services
{
    public class AdminService
    {
        public readonly IMongoCollection<Admin> _admins;

        public AdminService(IXTecDigitalDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _admins = database.GetCollection<Admin>(settings.Admins);
        }

        public List<Admin> Get()
        {
            return _admins.Find(admin => true).ToList();
        }

        public Admin Get(string user)
        {
            return _admins.Find(admin => admin.User == user).FirstOrDefault();
        }

        public Admin Create(Admin admin)
        {
            _admins.InsertOne(admin);
            return admin;
        }

        public List<Admin> Create(List<Admin> admins)
        {
            _admins.InsertMany(admins);
            return admins;
        }

        public void Update(string user, Admin estudianteIn)
        {
            _admins.ReplaceOne(admin => admin.User == user, estudianteIn);
        }

        public void Remove(Admin estudianteIn)
        {
            _admins.DeleteOne(admin => admin.User == estudianteIn.User);
        }

        public void Remove(string user)
        {
            _admins.DeleteOne(admin => admin.User == user);
        }
    }
}