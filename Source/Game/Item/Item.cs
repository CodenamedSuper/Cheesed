using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cheesed
{
    public class Item : Entity
    {
        public string desc { get; set; }


        public bool unlocked = false;

        public bool isGrowing = true;
        public bool isShrinking = false;


        public Recipe recipe { get; set; }

        public bool isOnStand = false;


        public int value { get; set; }

        public int parent { get; set; }

        public int price;




        public Vector2 velocity;
        public Vector2 Velocity  
        {
            get { return velocity; }   
            set { velocity = value; } 
        }
        public enum directions
        {
            south,
            west,
            north,
            east
        }
        public int direction { get; set; }
        public int oldDirection { get; set; }
        public int nextDirection { get; set; }

        public Rectangle coll;

        public Rectangle Coll
        {
            get { return coll; }
            set { coll = value; }
        }
        public Item(int ID, string NAME, string DESC, Vector2 POS, Recipe RECIPE)
        {
            pos = POS;
            name = NAME;
            recipe = RECIPE;
            dims = new Vector2(16, 16);
            id = ID;
            desc = DESC;
            coll = new Rectangle((int)pos.X + 4, (int)pos.Y + 4, 8, 8);
            
            sprite = new Sprite("items", pos, dims, Helper.SpriteCords(id, new Vector2(12,12)));
            sprite.SetScale(0);

        }

        public override void Update()
        {
            base.Update();
            OnCollision();

            pos += velocity;

            coll.X = (int)pos.X;
            coll.Y = (int)pos.Y;

            ApplyEffects();
        }

        public void OnCollision()
        {

            
        }

        public void ApplyVelocity()
        {
            pos += velocity;
            
            velocity.X--;
            if(velocity.X < 0)
            {
                velocity.X = 0;
            }
            velocity.Y--;
            if (velocity.Y < 0)
            {
                velocity.Y = 0;
            }

        }

        public void ApplyEffects()
        {
            if(isGrowing && sprite.GetScale() <= Helper.spriteScale)
            {
                Effects.Grow(sprite);
            }
            else
            {
                isGrowing = false;
            }
            if(isShrinking)
            {
                Effects.Shrink(sprite);

            }

        }

        public override void Draw()
        {
            sprite.Draw(new Vector2(pos.X - 2, pos.Y), new Color(10, 10, 10, 100), 1.55f);

            base.Draw();
        }

    }
}
