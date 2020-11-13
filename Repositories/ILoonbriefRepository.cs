using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GeneratieServiceAPI.Models;

namespace GeneratieServiceAPI.Repositories
{
    public interface ILoonbriefRepository
    {
        Task<IEnumerable<Loonbrief>> GetAsync();
        Task<Loonbrief> GetAsync(Guid Id);
        void Add(Loonbrief loonbrief);
    }
}