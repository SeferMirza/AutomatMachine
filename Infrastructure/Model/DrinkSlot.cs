using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DrinkSlot
    {
        public int SlotId { get; set; }
        public Drink Drink { get; set; }

        public DrinkSlot()
        {
            Drink = new Drink();
        }
    }
}
