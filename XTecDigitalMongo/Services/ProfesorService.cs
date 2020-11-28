using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XTecDigitalMongo.Models;

namespace XTecDigitalMongo.Services
{
    public class ProfesorService
    {
        public readonly IMongoCollection<Profesor> _profesores;

        public ProfesorService(IXTecDigitalDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _profesores = database.GetCollection<Profesor>(settings.Profesores);
        }

        public List<Profesor> Get() 
        {
            return _profesores.Find(profesor => true).ToList(); 
        }

        public Profesor Get(string cedula)
        {
            return _profesores.Find(profesor => profesor.Cedula == cedula).FirstOrDefault();
        }

        public Profesor Create(Profesor profesor)
        {
            _profesores.InsertOne(profesor);
            return profesor;
        }

        public void Update(string cedula, Profesor profesorIn)
        {
            _profesores.ReplaceOne(profesor => profesor.Cedula == cedula, profesorIn);
        }

        public void Remove(Profesor profesorIn)
        {
            _profesores.DeleteOne(profesor => profesor.Cedula == profesorIn.Cedula);
        }

        public void Remove(string cedula)
        {
            _profesores.DeleteOne(profesor => profesor.Cedula == cedula);
        }
    }
}
