using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace MyProtocolsApp_Joseph.Models
{
    public class User
    {
        public RestRequest Request { get; set; }    

        //en este ejemplo se usaran los mismos atributos que en el modelo del api
        //posteriormente en otra clase se usaran el DTO del usuario para simplificar
        //el json que se envia y recibe desde el api

        public int UserId { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string BackUpEmail { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Address { get; set; }
        public bool? Active { get; set; }
        public bool? IsBlocked { get; set; }
        public int UserRoleId { get; set; }

        public virtual UserRole? UserRole { get; set; }

        public User()
        {

        }

        //funciones especificas de llamada a end points del api

        //funcion que me permite validar que los datos digitados en la pagina
        //de applogin sean correctos o no 

        public async Task<bool> ValidateUserLogin()
        {
            try
            {
                //se usara el prefijo de la ruta url del api que se indica
                //en Services\APIConnetion para agregar el sufijo y lograr la ruta
                //completa de consumo del end point que se quiere usar

                string RouteSufix = string.Format
                    ("Users/ValidateLogin?username={0}&password={1}",
                    this.Email,this.Password);
                //armamos la ruta completa al endpoint en el api
                //Users/ValidateLogin?username=test1%40gmail.com&password=123
                string URL = Services.APIConnection.ProductionPrefixURL + RouteSufix;
                RestClient client = new RestClient(URL);
                Request = new RestRequest(URL, Method.Get);
                //agregamos mecanismo de seguridad, en este caso apikey
                Request.AddHeader(Services.APIConnection.ApikeyName, Services.APIConnection.ApikeyValue);
                //ejecutar la llamada al api
                RestResponse response = await client.ExecuteAsync(Request);
                //saber si las cosas salieron bien
                HttpStatusCode statusCode = response.StatusCode;
                if (statusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message; 
                throw;
            }
        }

        public async Task<bool> AddUserAsync()
        {
            try
            {

                string RouteSufix = string.Format("Users");
                //armamos la ruta completa al endpoint en el api
                string URL = Services.APIConnection.ProductionPrefixURL + RouteSufix;
                RestClient client = new RestClient(URL);
                Request = new RestRequest(URL, Method.Post);
                //agregamos mecanismo de seguridad, en este caso apikey
                Request.AddHeader(Services.APIConnection.ApikeyName, Services.APIConnection.ApikeyValue);
                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);
                //en  el caso de una operacion post debemos serializar
                //el objeto para pasarlo como json al api
                string SerializedModelObject = JsonConvert.SerializeObject(this);
                //agregamos el objeto serializado en el cuerpo del request
                Request.AddBody(SerializedModelObject, GlobalObjects.MimeType);
                
                //ejecutar la llamada al api
                RestResponse response = await client.ExecuteAsync(Request);
                //saber si las cosas salieron bien
                HttpStatusCode statusCode = response.StatusCode;
                if (statusCode == HttpStatusCode.Created)
                {
                    return true;
                }
                else
                {
                    return false;
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
