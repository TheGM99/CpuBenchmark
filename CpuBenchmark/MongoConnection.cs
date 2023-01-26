using CpuBenchmark.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CpuBenchmark
{
    internal class MongoConnection
    {
        MongoClientSettings settings = MongoClientSettings.FromConnectionString("mongodb+srv://Matczak:benchmarkCPU@cpucluster.b276pfj.mongodb.net/?retryWrites=true&w=majority");
        MongoClient dbClient;
        public MongoConnection()
        {
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            dbClient = new MongoClient(settings);
        }
        
        

        public void AddEntry(Entry entry)
        {
            var database = dbClient.GetDatabase("CpuBenchmarkDB");
            var collection = database.GetCollection<BsonDocument>("Entries");
            var doc = new BsonDocument
            {
                {"entryId", entry.entryId },
                {"performDate", entry.performDate },
                {"timeScoreSingle", entry.timeScoreSingle },
                {"timeScoreMulti", entry.timeScoreMulti },
                {"machineId", entry.machineId }
            };
            collection.InsertOne(doc);
        }

        public List<BsonDocument> GetEntriesByMachine(int machineId)
        {
            var database = dbClient.GetDatabase("CpuBenchmarkDB");
            var collection = database.GetCollection<BsonDocument>("Entries");

            var filter = Builders<BsonDocument>.Filter.Eq("machineId", machineId);
            var sort = Builders<BsonDocument>.Sort.Ascending("performDate");
            var entryDocument = collection.Find(filter).Sort(sort).ToList();
            return entryDocument;
        }

        public List<BsonDocument> GetEntries()
        {
            var database = dbClient.GetDatabase("CpuBenchmarkDB");
            var collection = database.GetCollection<BsonDocument>("Entries");

            var sort = Builders<BsonDocument>.Sort.Ascending("performDate");
            var entryDocument = collection.Find(new BsonDocument()).Sort(sort).ToList();
            return entryDocument;
        }

        public int GetLastEntryId()
        {
            var database = dbClient.GetDatabase("CpuBenchmarkDB");
            var collection = database.GetCollection<BsonDocument>("Entries");
            var sort = Builders<BsonDocument>.Sort.Descending("entryId");

            var entryDoc = collection.Find(new BsonDocument()).Sort(sort).FirstOrDefault();
            if (entryDoc == null) return 0;
            return Convert.ToInt32(entryDoc.GetElement("entryId").Value);
        }

        public void AddMachine(Models.Machine machine)
        {
            var database = dbClient.GetDatabase("CpuBenchmarkDB");
            var collection = database.GetCollection<BsonDocument>("Machines");
            var doc = new BsonDocument
            {
                {"machineId", machine.machineId },
                {"machineName", machine.machineName },
                {"operatingSystem", machine.operatingSystem },
                {"CPU", machine.CPU },
                {"memSize", machine.memSize }
            };
            collection.InsertOne(doc);
        }

        public BsonDocument GetMachine(string name)
        {
            var database = dbClient.GetDatabase("CpuBenchmarkDB");
            var collection = database.GetCollection<BsonDocument>("Machines");

            var filter = Builders<BsonDocument>.Filter.Eq("machineName", name);
            var sort = Builders<BsonDocument>.Sort.Ascending("performDate");
            var machineDocument = collection.Find(filter).Sort(sort).FirstOrDefault();
            return machineDocument;
        }
        public int GetLastMachineId()
        {
            var database = dbClient.GetDatabase("CpuBenchmarkDB");
            var collection = database.GetCollection<BsonDocument>("Machines");
            var sort = Builders<BsonDocument>.Sort.Descending("machineId");

            var machDoc = collection.Find(new BsonDocument()).Sort(sort).FirstOrDefault();
            if (machDoc == null) return 0;
            return Convert.ToInt32(machDoc.GetElement("machineId").Value);
        }
    }
}
