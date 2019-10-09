
namespace FoodLovers.Infrastructure.Elastic
{
    public class ElasticConnectionSettings
    {
        public string ClusterUrl { get; set; }
        private string _defaultIndex;

        public string DefaultIndex
        {
            get => _defaultIndex;
            set => _defaultIndex = value.ToLower();
        }

        
    }
}
