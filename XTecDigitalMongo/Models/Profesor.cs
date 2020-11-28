using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XTecDigitalMongo.Models
{
    public class Profesor
    {
        [BsonId]
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Pass { get; set; }
    }
}
