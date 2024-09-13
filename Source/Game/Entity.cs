using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheesed
{
    public class Entity
    {

        public string name { get; set; }
        public Vector2 pos;

        public Vector2 Pos
        {
            get { return pos; }
            set { pos = value; }
        }
        public Vector2 dims { get; set; }
        public  Sprite sprite { get; set; }
        public Animation[] animations { get; set; }

        public int id { get; set; }

        public string header { get; set; }


        public virtual void Update()
        {
            sprite.UpdatePos(pos);
        }

        public virtual void Draw()
        {

            sprite.Draw();
        }
    }
}
