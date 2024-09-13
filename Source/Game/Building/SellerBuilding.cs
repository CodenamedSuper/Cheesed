using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cheesed
{
    public class SellerBuilding : Building
    {
        public SellerBuilding(int ID, string NAME, Vector2 POS, int DIRECTION, float PRICE, string CATEG) : base(ID, NAME, POS, DIRECTION, PRICE, CATEG)
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

        public override void Update()
        {
            base.Update();
            Sell();

            

        }

        public void Sell()
        {
            foreach (Item item in World.entities.OfType<Item>())
            {
                if (Helper.AreColliding(item.coll, this) && !item.isOnStand)
                {
                    World.stats.AddGold(item.value);
                    World.entities.Remove(item);
                    powered = true;
                    break;
                }
            }
        }
    }
}
