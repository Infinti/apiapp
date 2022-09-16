using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        
        public Result(bool success, string message):this(success)//this burada; eğer 2 parametreli gelirse alttaki de çalışır anlamına geliyor
        {
            Message = message;//get Read only'dir. ve Constructorde set edilebilirler set olmasa dahi
             
        }
        public Result(bool success)
        {            
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
