using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Models
{
    public class Response<T> where T : BaseModel
    {
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }
        public T? Result { get; set; }
    }
}
