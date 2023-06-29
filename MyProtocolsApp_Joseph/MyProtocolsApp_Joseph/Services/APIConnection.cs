using System;
using System.Collections.Generic;
using System.Text;

namespace MyProtocolsApp_Joseph.Services
{
    public static class APIConnection
    {
        //aqui definimos la direccion url (ya sea una ip o un nombre de dominio)
        //a la que el app debe apuntar.
        //por comodidad la ruta url completa para consumir los recursos del api
        //se hara en formato "prefijo"+"sufijo"
        //donde el prefijo sera la parte del url que nunca cambiara y el sufgijo sera
        //la parte variable (nombre del controlador y sus parametros)

        public static string ProductionPrefixURL = "http://192.168.0.6:45455/api/";

        public static string ApikeyName = "Progra6Apikey";
        public static string ApikeyValue = "JosephProgra6AsdZxc12345";


    }
}
