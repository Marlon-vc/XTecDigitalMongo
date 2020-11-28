using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XTecDigitalMongo.Models;

namespace XTecDigitalMongo.Services
{
    public class EstudianteService
    {
        public readonly IMongoCollection<Estudiante> _estudiantes;

        public EstudianteService(IXTecDigitalDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _estudiantes = database.GetCollection<Estudiante>(settings.Estudiantes);
        }

        public List<Estudiante> Get()
        {
            return _estudiantes.Find(estudiante => true).ToList();
        }

        public Estudiante Get(string carnet)
        {
            return _estudiantes.Find(estudiante => estudiante.Carnet == carnet).FirstOrDefault();
        }

        public Estudiante Create(Estudiante estudiante)
        {
            _estudiantes.InsertOne(estudiante);
            return estudiante;
        }

        public void Update(string carnet, Estudiante estudianteIn)
        {
            _estudiantes.ReplaceOne(estudiante => estudiante.Carnet == carnet, estudianteIn);
        }

        public void Remove(Estudiante estudianteIn)
        {
            _estudiantes.DeleteOne(estudiante => estudiante.Carnet == estudianteIn.Carnet);
        }

        public void Remove(string carnet)
        {
            _estudiantes.DeleteOne(estudiante => estudiante.Carnet == carnet);
        }
    }
}
