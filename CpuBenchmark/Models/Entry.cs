using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace CpuBenchmark.Models
{
    internal class Entry
    {
        [JsonPropertyName("entryId")]
        public int entryId { get; set; }

        [JsonPropertyName("performDate")]
        public DateTime performDate { get; set; }

        [JsonPropertyName("timeScoreSingle")]
        public int timeScoreSingle { get; set; }

        [JsonPropertyName("timeScoreMulti")]
        public int timeScoreMulti { get; set; }

        [JsonPropertyName("machineId")]
        public int machineId { get; set; }
    }
}
