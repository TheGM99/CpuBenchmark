using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CpuBenchmark.Models
{
    internal class EntryDoc
    {
        [JsonPropertyName("documents")]
        public List<Entry> entries { get; set; }
    }
}
