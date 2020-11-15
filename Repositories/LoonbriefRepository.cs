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

        public Loonbrief Get(Guid Id)
        {
            return _loonbrieven.FirstOrDefault(a => a.Id == Id);
        }

        public IEnumerable<Loonbrief> Get() => _loonbrieven;
    }
}