using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodLovers.Elastic.Sync.Services
{
    public interface ISyncService
    {
        Task SyncData();
    }
}
