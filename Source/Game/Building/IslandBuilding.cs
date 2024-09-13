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
    public class IslandBuilding : CarrierBuilding
    {

        public Item oldItem;

        public int[] neighborDirections = new int[4];

        public bool[] impossibleDirections = new bool[4];



        public int collCount;
        public int previousCollCount;
        public IslandBuilding(int ID, string NAME, Vector2 POS, int DIRECTION, float PRICE, string CATEG) : base(ID, NAME, POS, DIRECTION, PRICE, CATEG)
        {
            initialDirection = direction;
        }

        public override void Update()
        {
            sprite.UpdatePos(pos);
            if (!powered)
            {
                sprite.UpdateAnimation(animations[direction].animation);
            }
            else
            {
                sprite.UpdateAnimation(animations[direction + 4].animation);
                animationCounter++;

                if (animationCounter >= 20)
                {
                    powered = false;
                    animationCounter = 0;
                }
            }
            Move();

            sprite.Animate(400);

            speed = World.stats.carrierSpeed;
        }

        public override void Move()
        {
            foreach (Item item in World.entities.OfType<Item>())
            {
                Vector2 velocity = item.velocity;

                if (Helper.AreColliding(item.coll, this))
                {


                    if(item.velocity == new Vector2(-speed, 0))
                    {
                        velocity.X = -speed / 5;
                        velocity.Y = 0;
                    }

                    if (item.velocity == new Vector2(+speed, 0))
                    {
                        velocity.X = +speed / 5;
                        velocity.Y = 0;
                    }

                    if (item.velocity == new Vector2(0, -speed))
                    {
                        velocity.Y = -speed / 5;
                        velocity.X = 0;
                    }

                    if (item.velocity == new Vector2(0, +speed))
                    {
                        velocity.Y = +speed / 5;
                        velocity.X = 0;
                    }




                }


                item.velocity = velocity;

            }

        }

        public bool Opposite(int D1, int D2)
        {

            if(D1 >= 4)
            {
                D1 = 0;
            }

            return (D1 == 0 && D2 == 2) || (D1 == 1 && D2 == 3) || (D1 == 2 && D2 == 0) || (D1 == 3 && D2 == 1);
        }

    }
}
