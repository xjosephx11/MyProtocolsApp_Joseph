using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyProtocolsApp_Joseph.Models
{
    public class UserDTO
    {
        [JsonIgnore]
        public RestRequest Request { get; set; }
        public int IDUsuario { get; set; }
        public string Correo { get; set; } = null!;
        public string Contrasenia { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string CorreoRespaldo { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string? Direccion { get; set; }
        public bool? Activo { get; set; }
        public bool? EstaBloqueado { get; set; }
        public int IdRol { get; set; }
        public string DescripcionRol { get; set; } = null!;

        //funciones
        public async Task<UserDTO> GetUserInfo(string pEmail) 
        {
            try
            {
                string RouteSufix = string.Format("Users/GetUserInfoByEmail?Pemail={0}",pEmail);
                //armamos la ruta completa al endpoint en el api
                string URL = Services.APIConnection.ProductionPrefixURL + RouteSufix;
                RestClient client = new RestClient(URL);
                Request = new RestRequest(URL, Method.Get);
                //agregamos mecanismo de seguridad, en este caso apikey
                Request.AddHeader(Services.APIConnection.ApikeyName, Services.APIConnection.ApikeyValue);
                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);
                //ejecutar la llamada al api
                RestResponse response = await client.ExecuteAsync(Request);
                //saber si las cosas salieron bien
                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    var list = JsonConvert.DeserializeObject<List<UserDTO>>(response.Content);
                    var item = list[0];
                    return item;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
        }











    }
}
