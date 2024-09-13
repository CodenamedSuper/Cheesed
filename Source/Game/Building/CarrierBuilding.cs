using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheesed
{
    public class CarrierBuilding : Building
    {
        public float speed = 1;
        public CarrierBuilding(int ID, string NAME, Vector2 POS, int DIRECTION, float PRICE, string CATEG) : base(ID, NAME, POS, DIRECTION, PRICE, CATEG)
        {
            animations = new Animation[4];

            animations[0] = new Animation(4, new Vector2(id, 0), dims);
            animations[1] = new Animation(4, new Vector2(id, 4), dims);
            animations[2] = new Animation(4, new Vector2(id, 8), dims);
            animations[3] = new Animation(4, new Vector2(id, 12), dims);


            sprite = new AnimatedSprite("buildings", pos, dims, animations[0].animation, 0, Helper.spriteScale);

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

            sprite.Animate(Helper.animationSpeed);

            speed = World.stats.carrierSpeed;

        }

        public virtual void Move()
        {
            foreach (Item item in World.entities.OfType<Item>())
            {
                Vector2 velocity = item.velocity;

                if (Helper.AreColliding(item.coll, this))
                {
                    if(item.nextDirection == item.direction)
                    {
                        if (item.direction == (int)directions.north)
                        {
                            velocity.Y = -speed / 5;
                            velocity.X = 0;
                        }
                        else if(item.direction == (int)directions.south)
                        {
                            velocity.Y = +speed / 5;
                            velocity.X = 0;


                        }
                        else if (item.direction == (int)directions.east)
                        {
                            velocity.X = +speed / 5;
                            velocity.Y = 0;


                        }
                        else if (item.direction == (int)directions.west)
                        {
                            velocity.X = -speed / 5;
                            velocity.Y = 0;


                        }
                    }
                    else if(item.nextDirection != item.direction)
                    {

                        if (new Vector2(item.coll.X, item.coll.Y) == pos)
                        {
                            item.direction = item.nextDirection;
                        }
                        else
                        {
                            if (item.direction == (int)directions.north)
                            {
                                velocity.Y = -speed / 5;
                                velocity.X = 0;
                            }
                           else if (item.direction == (int)directions.south)
                            {
                                velocity.Y = +speed / 5;
                                velocity.X = 0;

                            }
                            else if (item.direction == (int)directions.east)
                            {
                                velocity.X = +speed / 5;
                                velocity.Y = 0;


                            }
                            else if (item.direction == (int)directions.west)
                            {
                                velocity.X = -speed / 5;
                                velocity.Y = 0;

                            }
                        }
                    }

                    item.nextDirection = direction;



                }
                int c1 = 0;
                int c2 = 0;

                foreach (CarrierBuilding b in World.entities.OfType<CarrierBuilding>())
                {
                    c2++;
                    if (!Helper.AreColliding(b, item))
                    {
                        c1++;
                    }

                }

                if (c1 == c2)
                {
                    velocity = Vector2.Zero;
                }



                item.velocity = velocity;

            }

        }



    }
}
