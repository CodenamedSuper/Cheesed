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
    public class CrateBuilding : Building
    {
        public int spitTimer = 30;
        public CrateBuilding(int ID, string NAME, Vector2 POS, int DIRECTION, float PRICE, string CATEG) : base(ID, NAME, POS, DIRECTION, PRICE, CATEG)
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
            GetItem();
            SpitItem();



        }

        public void GetItem()
        {
            foreach (Item item in World.entities.OfType<Item>())
            {
                if (Helper.AreColliding(item.coll, this) && !item.isOnStand && Cursor.isHolding == false && (currentItem == -1 || item.id == currentItem) && currentItemCount < 9)
                {
                    currentItem = item.id;
                    currentItemCount++;
                    World.entities.Remove(item);
                    powered = true;
                    break;
                }
            }
        }

        public void SpitItem()
        {
            spitTimer++;
            if(spitTimer > 30)
            {
                spitTimer = 30;
            }
            if (currentItemCount > 0)
            {
                if (World.Up(this) != null)
                {
                    if (World.Up(this).powered && spitTimer >= 20)
                    {
                        Vector2 p = Helper.Snap(pos + new Vector2(0, 16), 16);
                        World.AddItem(p, currentItem);
                        currentItemCount--;
                        spitTimer = 0;
                        powered = true;

                        if (currentItemCount <= 0)
                        {
                            currentItem = -1;
                        }
                    }
                }
                if (World.Right(this) != null)
                {
                    if (World.Right(this).powered && spitTimer >= 20)
                    {
                        Vector2 p = Helper.Snap(pos + new Vector2(0, 16), 16);
                        World.AddItem(p, currentItem);
                        currentItemCount--;
                        spitTimer = 0;
                        powered = true;


                        if (currentItemCount <= 0)
                        {
                            currentItem = -1;
                        }
                    }
                }
                if (World.Left(this) != null)
                {
                    if (World.Left(this).powered && spitTimer >= 20)
                    {
                        Vector2 p = Helper.Snap(pos + new Vector2(0, 16), 16);
                        World.AddItem(p, currentItem);
                        currentItemCount--;
                        spitTimer = 0;
                        powered = true;


                        if (currentItemCount <= 0)
                        {
                            currentItem = -1;
                        }
                    }
                }
                if (World.Down(this) != null)
                {
                    if (World.Down(this).powered && spitTimer >= 20)
                    {
                        Vector2 p = Helper.Snap(pos + new Vector2(0, 16), 16);
                        World.AddItem(p, currentItem);
                        currentItemCount--;
                        spitTimer = 0;
                        powered = true;


                        if (currentItemCount <= 0)
                        {
                            currentItem = -1;
                        }
                    }
                }
            }
        }
    }
}

