using System.Collections.Generic;

namespace FoodLovers.Infrastructure
{
    public class ValidationResponseModel
    {
        public string Status { get; set; }

        public List<string> Errors { get; set; }
    }
}
