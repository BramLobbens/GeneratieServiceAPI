using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GeneratieServiceAPI.Models;

namespace GeneratieServiceAPI.Repositories
{
    public interface ILoonbriefRepository
    {
        IEnumerable<Loonbrief> Get();
        Loonbrief Get(Guid Id);
        void Add(Loonbrief loonbrief);
    }
}