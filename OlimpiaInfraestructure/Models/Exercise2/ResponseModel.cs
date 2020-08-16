using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlimpiaInfraestructure.Models
{
    public class ResponseModel
    {
        public ResponseModel(string message, bool error) {
            Error = error;
            Message = message;
        }
        public string Message;
        public bool Error;
    }
}
