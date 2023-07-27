using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentaCarApi.Models.Dtos
{
    public class ResponseMessage
    {
        public string Status { get; set; } 
        public string Message { get; set; }
        public string MessageReturned { get; set; }  
    }
}
