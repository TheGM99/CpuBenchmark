using CpuBenchmark.Models;
using MongoDB.Bson;
using System.Text.Json;
using System.Collections.Generic;
using RestSharp;
using System;
using System.Text.Json.Serialization;

namespace CpuBenchmark
{
    internal class MongoConnection
    {
        RestClient post = new RestClient("https://eu-central-1.aws.data.mongodb-api.com/app/data-tlnvl/endpoint/data/v1/action/insertOne");
        RestClient get = new RestClient("https://eu-central-1.aws.data.mongodb-api.com/app/data-tlnvl/endpoint/data/v1/action/find");
        string apiKey = "YjuqZpIrjlsZryLeKbOtRAgIQ1KnfcMhHkI43woMf33V8ZEyZxWLWjv6cFSGc1I1";



        public MongoConnection()
        {
        }



        public async void AddEntry(Models.Entry entry)
        {
            RestRequest request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Access-Control-Request-Headers", "*");
            request.AddHeader("api-key", apiKey);

            string json = JsonSerializer.Serialize(entry);

            string body = $@"{{
                         ""collection"":""Entries"",
                         ""database"":""CpuBenchmarkDB"", 
                         ""dataSource"":""CpuCluster"", 
                         ""document"": {json}
                         }}";


            request.AddStringBody(body, DataFormat.Json);
            RestResponse response = await post.PostAsync(request);
        }

        public EntryDoc GetEntriesByMachine(int machineId)
        {
            RestRequest request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Access-Control-Request-Headers", "*");
            request.AddHeader("api-key", apiKey);

            string body = $@"{{
                        ""collection"":""Entries"",
                        ""database"":""CpuBenchmarkDB"",
                        ""dataSource"":""CpuCluster"",
                        ""filter"":{{ ""machineId"": {machineId} }},
                        ""sort"":{{ ""performDate"": 1 }}
                        }}";

            request.AddStringBody(body, DataFormat.Json);
            RestResponse response = get.Post(request);
            return JsonSerializer.Deserialize<EntryDoc>(response.Content) ?? new EntryDoc();

        }

        public EntryDoc GetEntries()
        {
            RestRequest request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Access-Control-Request-Headers", "*");
            request.AddHeader("api-key", apiKey);

            string body = $@"{{
                       ""collection"":""Entries"",
                       ""database"":""CpuBenchmarkDB"",
                       ""dataSource"":""CpuCluster"",
                       ""sort"":{{ ""performDate"": 1 }} 
                       }}";

            request.AddStringBody(body, DataFormat.Json);
            RestResponse response = get.Post(request);
            return JsonSerializer.Deserialize<EntryDoc>(response.Content) ?? new EntryDoc();
        }

        public int GetLastEntryId()
        {
            RestRequest request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Access-Control-Request-Headers", "*");
            request.AddHeader("api-key", apiKey);

            string body = $@"{{
                       ""collection"":""Entries"",
                       ""database"":""CpuBenchmarkDB"",
                       ""dataSource"":""CpuCluster"",
                       ""sort"":{{""performDate"": -1 }},
                       ""limit"": 1
                       }}";

            request.AddStringBody(body, DataFormat.Json);
            RestResponse response = get.Post(request);
            return JsonSerializer.Deserialize<EntryDoc>(response.Content).entries[0].entryId;
        }

        public async void AddMachine(Models.Machine machine)
        {
            RestRequest request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Access-Control-Request-Headers", "*");
            request.AddHeader("api-key", apiKey);

            string json = JsonSerializer.Serialize(machine);

            string body = $@"{{
                       ""collection"":""Machines"",
                       ""database"":""CpuBenchmarkDB"",
                       ""dataSource"":""CpuCluster"",
                       ""document"":{json}
                       }}";

            request.AddStringBody(body, DataFormat.Json);
            RestResponse response = await post.PostAsync(request);
        }

        public Machine GetMachine(string name)
        {
            RestRequest request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Access-Control-Request-Headers", "*");
            request.AddHeader("api-key", apiKey);

            string body = "{\"collection\":\"Machines\",\"database\":\"CpuBenchmarkDB\",\"dataSource\":\"CpuCluster\",\"filter\":{\"machineName\":\"DESKTOP-6CG1DB9\"}}";

            request.AddStringBody(body, DataFormat.Json);
            RestResponse response = get.Post(request);
            var test = JsonSerializer.Deserialize<MachineDoc>(response.Content);
            return JsonSerializer.Deserialize<MachineDoc>(response.Content).machines[0] ?? new Machine();

          
            
        }
        public int GetLastMachineId()
        {
            RestRequest request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Access-Control-Request-Headers", "*");
            request.AddHeader("api-key", apiKey);

            string body = $@"{{
                        ""collection"":""Machines"",
                        ""database"":""CpuBenchmarkDB"",
                        ""dataSource"":""CpuCluster"",
                        ""sort"":{{""performDate"": -1 }},
                        ""limit"": 1
                        }}";

            request.AddStringBody(body, DataFormat.Json);
            RestResponse response = get.Post(request);
            return JsonSerializer.Deserialize<MachineDoc>(response.Content).machines[0].machineId;
        }
    }
}
