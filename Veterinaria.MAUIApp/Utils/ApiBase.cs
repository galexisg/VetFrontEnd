using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.MAUIApp.Utils
{
    public static class ApiBase
    {
        public static string Get()
        {
            #if ANDROID
                        return "http://10.0.2.2:8080/api/";
            #elif WINDOWS
                        return "http://localhost:8080/api/";
            #else
                        return "http://localhost:8080/api/";
            #endif
        }
    }
}
