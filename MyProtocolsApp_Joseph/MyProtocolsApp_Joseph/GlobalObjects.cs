using MyProtocolsApp_Joseph.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProtocolsApp_Joseph
{
    public static class GlobalObjects
    {
        //definimos las propiedades de codificacion de los json
        //que usares en los modelos
        public static string MimeType = "application/json";
        public static string ContentType = "Content-Type";

        //crear el objeto local (global) de usuario
        public static UserDTO MyLocalUser = new UserDTO();  


    }
}
