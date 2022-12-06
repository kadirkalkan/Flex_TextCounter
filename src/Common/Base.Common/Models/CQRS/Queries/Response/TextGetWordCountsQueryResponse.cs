using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Common.Models.CQRS.Queries.Response;

public class TextGetWordCountsQueryResponse
{
    public string Word { get; set; }
    public int Count { get; set; }
    public string Format => $"{Word} ({Count})";
}
