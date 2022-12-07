using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Common.Models.Common;

public class ExceptionResponse
{
    public int StatusCode { get; set; }
    public string ExceptionMessage { get; set; }
    public string Route { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}
