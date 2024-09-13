using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheesed
{
    public class Helper
    {
        //Determines by how much the game's graphics will be scaled
        public static float spriteScale = 4f;

        //Dimentions of the game's grid
        public static readonly Vector2 gridSize = new Vector2(16, 16);

        public static int screenHeight, screenWidth;

        public static int animationSpeed = 200;



        public static  ContentManager content;
        public static  SpriteBatch spriteBatch;

        public static GameTime gameTime;

        public static  ShibKeyboard keyboard;
        public static  ShibMouse mouse;


        public static Vector2 screenOffset;

        public static Vector2 screenOffsetSpeed;


        public static bool isActive;


        public static Random random;
        public static bool AreColliding(Entity COLL1, Entity COLL2)
        {
            //Returns true if both arguments are colliding with each other.

            Rectangle coll1 = new Rectangle((int)COLL1.pos.X, (int)COLL1.pos.Y, (int)COLL1.dims.X, (int)COLL1.dims.Y);
            Rectangle coll2 = new Rectangle((int)COLL2.pos.X, (int)COLL2.pos.Y, (int)COLL2.dims.X, (int)COLL2.dims.Y);



            if (coll1.Intersects(coll2) && COLL1 != COLL2)
            {
                return true;
            }




            return false;
        }

        public static bool AreColliding(Vector2 POS1, Vector2 DIMS1, Vector2 POS2, Vector2 DIMS2)
        {
            //Returns true if both arguments are colliding with each other.

            Rectangle coll1 = new Rectangle((int)POS1.X, (int)POS1.Y, (int)DIMS1.X, (int)DIMS1.Y);
            Rectangle coll2 = new Rectangle((int)POS2.X, (int)POS2.Y, (int)DIMS2.X, (int)DIMS2.Y);



            if (coll1.Intersects(coll2))
            {
                return true;
            }




            return false;
        }

        public static bool AreColliding(Rectangle COLL1, Entity COLL2)
        {
            //Returns true if both arguments are colliding with each other.

            Rectangle coll1 = new Rectangle((int)COLL1.X, (int)COLL1.Y, (int)COLL1.Width, (int)COLL1.Height);
            Rectangle coll2 = new Rectangle((int)COLL2.pos.X, (int)COLL2.pos.Y, (int)COLL2.dims.X, (int)COLL2.dims.Y);



            if (coll1.Intersects(coll2))
            {
                return true;
            }




            return false;
        }
        public static int Index(Vector2 CORDS, Vector2 DIMS)
        {
            int x = 0;
            int y = 0;

            int index = 0;

            for (int i = 0; i < DIMS.X * DIMS.Y; i++)
            {


                if (new Vector2(x, y) == CORDS)
                {
                    return index;
                }
                x++;
                index++;
                if (x >= DIMS.X)
                {
                    y++;
                    x = 0;
                }



            }
            return -1;
        }
        public static float GetDistance(Vector2 pos, Vector2 target)
        {
            //Returns the distance between to coordinates.
            return (float)Math.Sqrt(Math.Pow(pos.X - target.X, 2) + Math.Pow(pos.Y - target.Y, 2));
        }

        public static Vector2 Table(Vector2 POS, Vector2 DIMS)
        {
            //Positions coordinates in a designated table.
            if (POS.X == DIMS.X - 1 || POS.X == DIMS.X && DIMS.X == 1)
            {
                POS.X = 0;
                POS.Y++;
            }
            else
            {
                POS.X++;
            }
            return POS;
        }

        public static Vector2 Snap(Vector2 value, float GRID)
        {
            //Snaps a coordinate to the closest designated grid square. 
            return Vector2.Floor(value / GRID + new Vector2(0.5f)) * GRID;
        }

        public static Vector2 SpriteCords(int NUM, Vector2 DIMS)
        {
            int x = 0;
            int y = 0;

            for (int i = 0; i < NUM; i++)
            {
                x++;
                if (x >= DIMS.X)
                {
                    y++;
                    x = 0;
                }


            }
            return new Vector2(x, y);
        }
    }
}
