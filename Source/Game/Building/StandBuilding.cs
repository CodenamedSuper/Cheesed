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
    public class StandBuilding : Building
    {
        public int index;
        public Vector2 itemPos;

        public StandBuilding(int ID, string NAME, Vector2 POS, int DIRECTION, float PRICE, string CATEG, int CURRENTITEM) : base(ID, NAME, POS, DIRECTION, PRICE, CATEG)
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

            currentItem = CURRENTITEM;

            if (CURRENTITEM != -1)
            {
                World.AddItem(new Vector2(pos.X, pos.Y - 3), currentItem);
                index = World.entities.Count - 1;
                itemPos = new Vector2(pos.X, pos.Y - 3);

            }

            sprite = new AnimatedSprite("buildings", pos, dims, animations[0].animation, 0, Helper.spriteScale);

        }

        public override void Update()
        {
            base.Update();
            Display();


            foreach (Item item in World.entities.OfType<Item>())
            {
                if(World.entities.IndexOf(item) == index)
                {
                    item.pos = new Vector2(pos.X, pos.Y - 3);
                    item.sprite.SetScale(Helper.spriteScale);
                }
            }

        }

        public void Display()
        {
            foreach (Item item in World.entities.OfType<Item>())
            {
                if (Helper.AreColliding(item.coll, this) && !item.isOnStand)
                {
                    item.isOnStand = true;
                    currentItem = item.id;
                    index = World.entities.IndexOf(item);
                    item.pos = new Vector2(pos.X, pos.Y - 3);
                    break;
                }

            }
        }

    }
}
