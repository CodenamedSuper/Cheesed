using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheesed
{
    public class EntityInfo
    {
        public float x { get; set; }
        public float y { get; set; }

        public int id { get; set; }


        public float Y()
        {
            return this.y;
        }
        public float C()
        {
            return this.x;
        }

        public int GetId()
        {
            return id;
        }

    }
}
