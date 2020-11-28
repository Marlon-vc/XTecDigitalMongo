using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XTecDigitalMongo.Models
{
    public class XTecDigitalDbSettings: IXTecDigitalDbSettings
    {
        public string Profesores { get; set; }
        public string Estudiantes { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IXTecDigitalDbSettings
    {
        string Profesores { get; set; }
        string Estudiantes { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
