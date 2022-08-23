using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModLoader
{
    struct BlockData : IBlockData
    {
        public string Name { get ; set; }
        public string Description { get; set; }
        public List<DateTime> DateUpdate { get; set; }
        public string Link { get; set; }

    }
}
