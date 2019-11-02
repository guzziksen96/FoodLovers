using System;
using FoodLovers.Domain.Entities;
using Microsoft.Extensions.Options;
using Nest;

namespace FoodLovers.Infrastructure.Elastic
{
    public class ElasticClientProvider
    {
        public ElasticClient Client { get; }
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

        }
    }
}
