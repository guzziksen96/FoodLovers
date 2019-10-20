using System;
using FoodLovers.Domain.Entities;
using Microsoft.Extensions.Options;
using Nest;

namespace FoodLovers.Infrastructure.Elastic
{
    public class ElasticClientProvider
    {
        public ElasticClient Client { get; }
       // public string DefaultIndex { get; private set; }
        public ElasticClientProvider(IOptions<ElasticConnectionSettings> settings)
        {
            ConnectionSettings connectionSettings =
                new ConnectionSettings(new Uri(settings.Value.ClusterUrl))
                    .PrettyJson()
                    .EnableDebugMode();

            if (settings.Value.DefaultIndex != null)
            {
                connectionSettings.DefaultIndex(settings.Value.DefaultIndex);
            }

            Client = new ElasticClient(connectionSettings);
            //EnsureIndexWithMapping<Recipe>(settings.Value.DefaultIndex);

            //Client.Indices.Create("recipes", index => index
            //    .Mappings(mappings => mappings
            //        .Map<Recipe>(mapping => mapping.AutoMap())));
        }

        public void EnsureIndexWithMapping<T>(string indexName = null, Func<PutMappingDescriptor<T>, PutMappingDescriptor<T>> customMapping = null) where T : class
        {
            //if (String.IsNullOrEmpty(indexName)) indexName = DefaultIndex;

            // Map type T to that index
            Client.ConnectionSettings.DefaultIndices.Add(typeof(T), indexName);

            // Does the index exists?
            var indexExistsResponse = Client.Indices.Exists(new IndexExistsRequest(indexName));
            if (!indexExistsResponse.IsValid) throw new InvalidOperationException(indexExistsResponse.DebugInformation);

            // If exists, return
            if (indexExistsResponse.Exists) return;

            // Otherwise create the index and the type mapping
            var createIndexRes = Client.Indices.Create(indexName);
            if (!createIndexRes.IsValid) throw new InvalidOperationException(createIndexRes.DebugInformation);

            var res = this.Client.Map<T>(m =>
            {
                m.AutoMap().Index(indexName);
                if (customMapping != null) m = customMapping(m);
                return m;
            });

            if (!res.IsValid) throw new InvalidOperationException(res.DebugInformation);
        }

    }
}
