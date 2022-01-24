using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class Repository:IRepository
    {
        private List<Slot> Slots { get; set; }
        public Repository()
        {
            Slots = new List<Slot>();
        }
        public void Add(Slot slot)
        {
            Slots.Add(slot);
        }

        public List<Slot> GetProducts()
        {

            return Slots;
        }

        public void Iptal()
        {
            throw new NotImplementedException();
        }

        public void SatinAl()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public Slot GetSlotById(int id)
        {
            return Slots.Where(x => x.Foods.SlotId == id || x.Drinks.SlotId == id).FirstOrDefault();
        }
    }
}
