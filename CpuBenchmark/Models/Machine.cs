using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace CpuBenchmark.Models
{
    internal class Machine
    {
        [JsonPropertyName("machineId")]
        public int machineId { get; set; }

        [JsonPropertyName("machineName")]
        public string machineName { get; set; }

        [JsonPropertyName("operatingSystem")]
        public string operatingSystem { get; set; }

        [JsonPropertyName("CPU")]
        public string CPU { get; set; }

        [JsonPropertyName("memSize")]
        public int memSize { get; set; }
    }
}
