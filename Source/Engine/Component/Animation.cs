using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheesed { 
    public class Animation
    {
        public Vector2[] animation { get; set; }
        public Vector2 cords;
        public Vector2 dims { get; set; }
        int count { get; set; }

        public Animation (int COUNT, Vector2 CORDS, Vector2 DIMS)
        {
            cords = CORDS;

            count = COUNT;
            dims = DIMS;

            animation = new Vector2[COUNT];

            for(int i = 0; i < COUNT; i++)
            {
                animation[i] = new Vector2(cords.X, cords.Y + (DIMS.Y * i) / 16);
            }
        }
    }
}
