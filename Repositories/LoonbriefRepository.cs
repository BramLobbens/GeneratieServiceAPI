using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeneratieServiceAPI.Models;

namespace GeneratieServiceAPI.Repositories
{
    public class LoonbriefRepository : ILoonbriefRepository
    {
        private IList<Loonbrief> _loonbrieven { get; set; }
        public LoonbriefRepository()
        {
            _loonbrieven = new List<Loonbrief>();
        }

        public void Add(Loonbrief loonbrief)
        {
            _loonbrieven.Add(loonbrief);
        }

        public Task<Loonbrief> GetAsync(Guid Id)
        {
            return Task.Run(() => _loonbrieven.FirstOrDefault(a => a.Id == Id));
        }

        public Task<IEnumerable<Loonbrief>> GetAsync()
        {
            return Task.Run(() => _loonbrieven.Where(a => a.Id != null));
        }
    }
}