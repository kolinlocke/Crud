using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _Common
{
    public static class Parameters
    {
        [Serializable()]
        public class Key
        {
            public String Name { get; set; }
            public Int64 ID { get; set; }
        }

        [Serializable()]
        public class Keys : List<Key> { }
    }
}
