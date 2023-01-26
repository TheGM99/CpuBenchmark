using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CpuBenchmark.Models
{
    internal class Entry
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int entryId { get; set; }
        public DateTime performDate { get; set; }
        public int timeScoreSingle { get; set; }
        public int timeScoreMulti { get; set; }
        public int machineId { get; set; }
    }
}
