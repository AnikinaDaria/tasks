using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3.Models
{

    public class RootobjectValues
    {
        [JsonProperty("values")]
        public List<ValueV> values { get; set; }
    }

    public class ValueV
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("value")]
        public string value { get; set; }
    }

}
