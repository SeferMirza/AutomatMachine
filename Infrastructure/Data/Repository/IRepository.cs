using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IRepository
    {
        public void Add(Slot slot);
        public void Update();
        public void SatinAl();
        public void Iptal();
        public Slot GetSlotById(int id);
        public List<Slot> GetProducts();

    }
}
