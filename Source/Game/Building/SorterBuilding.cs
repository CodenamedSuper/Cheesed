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
    public class SorterBuilding : CarrierBuilding
    {
        public Item oldItem;

        public int[] neighborDirections = new int[4];

        public bool[] impossibleDirections = new bool[4];



        public int collCount;
        public int previousCollCount;
        public SorterBuilding(int ID, string NAME, Vector2 POS, int DIRECTION, int INITIAL_DIRECTION, float PRICE, string CATEG) : base(ID, NAME, POS, DIRECTION, PRICE, CATEG)
        {
            Debug.WriteLine(DIRECTION);
            if(initialDirection == -1)
            {
                initialDirection = DIRECTION;
            }
            else
            {
                initialDirection = INITIAL_DIRECTION;

            }

            direction = DIRECTION;
        }


        public override void Update()
        {

            ChangeDirection();
            base.Update();


        }

        public bool Opposite(int D1, int D2)
        {

            if (D1 >= 4)
            {
                D1 = 0;
            }

            return (D1 == 0 && D2 == 2) || (D1 == 1 && D2 == 3) || (D1 == 2 && D2 == 0) || (D1 == 3 && D2 == 1);
        }

        public void ChangeDirection()
        {
            collCount = 0;

            foreach (Item item in World.entities.OfType<Item>())
            {
                if (Helper.AreColliding(item.coll, this))
                {
                    collCount++;
                    if (item != oldItem && collCount > 0 && previousCollCount == 0)
                    {

                        if (World.Down(this) != null && World.Down(this) is CarrierBuilding)
                        {
                            impossibleDirections[0] = true;
                            neighborDirections[0] = World.Down(this).direction;

                        }
                        else
                        {
                            impossibleDirections[0] = false;
                            neighborDirections[0] = -1;


                        }
                        if (World.Left(this) != null && World.Left(this) is CarrierBuilding)
                        {

                            impossibleDirections[1] = true;
                            neighborDirections[1] = World.Left(this).direction;

                        }
                        else
                        {
                            impossibleDirections[1] = false;
                            neighborDirections[1] = -1;

                        }
                        if (World.Up(this) != null && World.Up(this) is Building)
                        {

                            impossibleDirections[2] = true;
                            neighborDirections[2] = World.Up(this).direction;

                        }
                        else
                        {
                            impossibleDirections[2] = false;
                            neighborDirections[2] = -1;

                        }
                        if (World.Right(this) != null && World.Right(this) is CarrierBuilding)
                        {

                            impossibleDirections[3] = true;
                            neighborDirections[3] = World.Right(this).direction;


                        }
                        else
                        {
                            impossibleDirections[3] = false;
                            neighborDirections[3] = -1;

                        }

                        direction++;
                        for (int i = 0; i < impossibleDirections.Length; i++)
                        {
                            if (direction >= 4)
                            {
                                direction = 0;
                            }
                            if (direction == i && Opposite(direction, neighborDirections[i]))
                            {
                                direction++;

                                if (direction >= 4)
                                {
                                    direction = 0;
                                }

                            }
                        }
                        if (direction >= 4)
                        {
                            direction = 0;
                        }


                    }
                    oldItem = item;
                }

            }
            previousCollCount = collCount;
        }
    }
}
