using Cheese;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheesed
{
    public class GeneratorBuilding : Building
    {
        public GeneratorBuilding(int ID, string NAME, Vector2 POS, int DIRECTION, float PRICE, string CATEG) : base(ID, NAME, POS, DIRECTION, PRICE, CATEG)
        {
            animations = new Animation[8];

            animations[0] = new Animation(1, new Vector2(id, 0), dims);
            animations[1] = new Animation(1, new Vector2(id, 4), dims);
            animations[2] = new Animation(1, new Vector2(id, 8), dims);
            animations[3] = new Animation(1, new Vector2(id, 12), dims);

            animations[4] = new Animation(2, new Vector2(id, 0), dims);
            animations[5] = new Animation(2, new Vector2(id, 4), dims);
            animations[6] = new Animation(2, new Vector2(id, 8), dims);
            animations[7] = new Animation(2, new Vector2(id, 12), dims);

            sprite = new AnimatedSprite("buildings", pos, dims, animations[0].animation, 0, Helper.spriteScale);

        }
        double time = 0;

        public override void Update()
        {
            time += World.time;
            foreach (Building building in World.entities.OfType<Building>())
            {
                if (Helper.AreColliding(pos + new Vector2(0, 16), Helper.gridSize, building.pos, building.dims) && building.id != 4 && building.id != 5)
                {
                    return;

                }
            }
            if (time >= 5)
            {
                time = 0;
                GenerateItem();
            }
            base.Update();
        }


        public void GenerateItem()
        {
            Vector2 p = Helper.Snap(pos + new Vector2(0,16), 16);

            World.stats.madeItems[0] = true;
            World.AddItem(p, 0);
            World.ItemCount++;
            powered = true;
        }
    }
}
