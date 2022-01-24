using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class FoodSlot
    {
        public int SlotId { get; set; }

        public Food Food { get; set; }

        public FoodSlot()
        {
            Food = new Food();
        }
        
    }
}
