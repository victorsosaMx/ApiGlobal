using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGlobal.Models
{
    public class clsProxyRequest
    {
        public string? UrlApiGlobal { get; set; }
        public string? EndPointApiGlobal { get; set; }
        public string? Servidor { get; set; }
        public string? Opcion { get; set; }
        public string? Metodo { get; set; }
        public string? Usuario { get; set; }
        public string? Sistema { get; set; }
        public string? Funcion { get; set; }
        public string? Body { get; set; }
        public bool CorregirISO8859 { get; set; }
        public bool DescargaArchivoSwagger { get; set; }
        public bool LogSoloEnError { get; set; }
        public string? AuthorizationToken { get; set; }
        public string? BearerAuthorizationToken { get; set; }
        public Dictionary<string, string>? Parametros { get; set; }
    }
}
