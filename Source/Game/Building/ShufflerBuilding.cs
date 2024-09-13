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
    public class ShufflerBuilding : CarrierBuilding
    {

        public Item oldItem;

        public int[] neighborDirections = new int[4];

        public bool[] impossibleDirections = new bool[4];



        public int collCount;
        public int previousCollCount;
        public ShufflerBuilding(int ID, string NAME, Vector2 POS, int DIRECTION, float PRICE, string CATEG) : base(ID, NAME, POS, DIRECTION, PRICE, CATEG)
        {
            initialDirection = direction;
        }

        public override void Update()
        {
            ChangeDirection();
            base.Update();

        }

        public bool Opposite(int D1, int D2)
        {

            if(D1 >= 4)
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
                        Helper.random = new Random();
                        direction = Helper.random.Next(0, 4);

                    }
                    oldItem = item;
                }

            }
            previousCollCount = collCount;
        }
    }
}
