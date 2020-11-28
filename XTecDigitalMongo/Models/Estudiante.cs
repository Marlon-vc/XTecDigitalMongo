using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XTecDigitalMongo.Models
{
    public class Estudiante
    {
        [BsonId]
        public string Carnet { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Pass { get; set; }
    }
}
