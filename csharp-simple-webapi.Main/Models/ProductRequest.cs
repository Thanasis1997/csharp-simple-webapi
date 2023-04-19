using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace csharp_simple_webapi.Main.Models
{
    public class ProductRequest
    {
        [FromQuery(Name = "limit")]
        public int Limit { get; set; } = 15;

        [FromQuery(Name = "offset")]
        public int Offset { get; set; }
    }
}
