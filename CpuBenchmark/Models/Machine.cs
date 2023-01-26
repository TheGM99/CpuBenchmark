using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CpuBenchmark.Models
{
    internal class Machine
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int machineId { get; set; }
        public string machineName { get; set; }
        public string operatingSystem { get; set; }
        public string CPU { get; set; }
        public int memSize { get; set; }
    }
}
