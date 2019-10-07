using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLovers.Infrastructure
{
    public class ValidationResponseModel
    {
        public string Status { get; set; }

        public List<string> Errors { get; set; }
    }
}
