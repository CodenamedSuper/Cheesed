using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheesed
{
    public class Building : Entity
    {
        public int initialDirection = -1;

        public new AnimatedSprite sprite { get; set; }
        public Animation animation { get; set; }

        public int animationCounter { get; set; }

        public int direction { get; set; }
        public float price { get; set; }
        public int count { get; set; }
        public bool unlocked { get; set; }

        public bool powered { get; set; }
        public int currentItem = -1;

        public int currentItemCount { get; set; }

        public string category { get; set; }

        public Color color { get; set; }


        public enum directions
        {
            south,
            west,
            north,
            east
        }

        public Building(int ID, string NAME, Vector2 POS, int DIRECTION, float PRICE, string CATEG)
        {
            animations = new Animation[8];

            animations[0] = new Animation(1, new Vector2(id, 0), dims);
            animations[1] = new Animation(1, new Vector2(id, 4), dims);
            animations[2] = new Animation(1, new Vector2(id, 8), dims);
            animations[3] = new Animation(1, new Vector2(id, 12), dims);

            animations[4] = new Animation(4, new Vector2(id, 0), dims);
            animations[5] = new Animation(4, new Vector2(id, 4), dims);
            animations[6] = new Animation(4, new Vector2(id, 8), dims);
            animations[7] = new Animation(4, new Vector2(id, 12), dims);

            id = ID;
            name = NAME;
            dims = new Vector2(16,16);
            pos = POS;
            direction = DIRECTION;
            price = PRICE;
            category = CATEG;
            
        }

        public override void Update()
        {
            sprite.UpdatePos(pos);
            if(!powered) {
                sprite.UpdateAnimation(animations[direction].animation);
            }
            else
            {
                sprite.UpdateAnimation(animations[direction + 4].animation);
                animationCounter++;

                if(animationCounter >= 20)
                {
                    powered = false;
                    animationCounter = 0;
                }
            }
            sprite.Animate(400);
        }


        public override void Draw()
        {
            sprite.Draw(3.5f, new Vector2(pos.X + 10, pos.Y + 2), new Color(10, 10, 10, 100), 1.55f);


                if (color == new Color(0, 0, 0, 0) || id == 10)
                {
                    sprite.Draw();
                }
                else
                {
                    sprite.Draw(color);
                }

            
        }
    }
}
