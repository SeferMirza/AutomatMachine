using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class JsonMessage
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public bool Result { get; set; }
        public Object Data { get; set; }
        public string Icon { get; set; }
    }
}
