using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Core.Dto
{
    public class ApiReponse
    {
        public object Data { get; set; }
        public string Exception { get; set; }
        public string ResultDescription { get; set; }
        public int Code { get; set; }
        public string Result { get; set; }

        public static ApiReponse Ok(object data)
        {
            ApiReponse response=new ApiReponse();
            response.Data = data;
            if(data is null) {
                response.Data = "OK";
            }
            response.Result = "OK";
            response.Code = 200;
            return response;
        }

       public static ApiReponse Error(string message)
        {
            ApiReponse response = new ApiReponse();
            response.Data = message;
            response.Code = 500;
            response.Result = "Error";
            return response;
        }
    }
}
