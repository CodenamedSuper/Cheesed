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
    public class Sprite
    {
        public List<Sprite> sprites = new List<Sprite>();

        public bool isScaled = false;

        public Vector2 pos { set; get; }

        public Vector2 oldPos { set; get; }

        public Vector2 dims { set; get; }
        public Vector2 cords { set; get; }

        public float rot { get; set; }
        public float scale { get; set; }



        public Texture2D texture { set; get; }

        public Sprite()
        {

        }
        public Sprite(string TEXTURE, Vector2 POS, Vector2 DIMS, Vector2 CORDS, float ROT, float SCALE)
        {
            sprites.Add(new Sprite { texture = Helper.content.Load<Texture2D>("Img\\" + TEXTURE), pos = new Vector2(POS.X,POS.Y), dims = DIMS, cords = new Vector2(CORDS.X, CORDS.Y), rot = ROT, scale = SCALE });

        }

        public Sprite(string TEXTURE, Vector2 POS, Vector2 DIMS)
        {
            sprites.Add(new Sprite { texture = Helper.content.Load<Texture2D>("Img\\" + TEXTURE), pos = new Vector2(POS.X, POS.Y), dims = DIMS, scale = Helper.spriteScale});

        }

        public Sprite(string TEXTURE, Vector2 POS, Vector2 DIMS, Vector2 CORDS)
        {
            sprites.Add(new Sprite { texture = Helper.content.Load<Texture2D>("Img\\" + TEXTURE), pos = new Vector2(POS.X, POS.Y), dims = DIMS, cords = CORDS, scale = Helper.spriteScale });

        }

        public virtual void Scale(bool IS_SCALED)
        {
            foreach (Sprite sprite in sprites)
            {
                sprite.isScaled = IS_SCALED;
                if (sprite.isScaled)
                {
                    sprite.scale = 4.5f;
                    sprite.oldPos = sprite.pos;

                    sprite.pos = new Vector2(sprite.pos.X - 2, sprite.pos.Y - 2);
                }
                else
                {
                    sprite.pos = sprite.oldPos;

                    sprite.scale = Helper.spriteScale;
                }
            }
        }

        public virtual void UpdateTexture(string TEXTURE)
        {
            foreach (Sprite sprite in sprites)
            {
                sprite.texture = Helper.content.Load<Texture2D>("Img\\" + TEXTURE);
            }
        }

        public virtual Vector2 GetPosition()
        {
            foreach (Sprite sprite in sprites)
            {
                return sprite.pos;
            }
            return Vector2.Zero;
        }

        public virtual Vector2 GetCords()
        {
            foreach (Sprite sprite in sprites)
            {
                return sprite.cords;
            }
            return Vector2.Zero;
        }

        public virtual string GetTexture()
        {
            foreach (Sprite sprite in sprites)
            {
                return sprite.texture.Name;
            }
            return "";
        }

        public virtual Vector2 GetDims()
        {
            foreach (Sprite sprite in sprites)
            {
                return sprite.dims;
            }
            return Vector2.Zero;
        }

        public virtual Sprite GetSprite()
        {
            foreach (Sprite sprite in sprites)
            {
                return sprite;
            }
            return null; 
        }

        public virtual float GetScale()
        {
            foreach (Sprite sprite in sprites)
            {
                return sprite.scale;
            }
            return 0;
        }

        public virtual void UpdatePos(Vector2 POS)
        {
            foreach (Sprite sprite in sprites)
            {
                sprite.pos = new Vector2(POS.X, POS.Y);
            }

        }
        public virtual void UpdateDims(Vector2 DIMS)
        {
            foreach (Sprite sprite in sprites)
            {
                sprite.dims = new Vector2(DIMS.X, DIMS.Y);
            }

        }

        public virtual void UpdateCords(Vector2 CORDS)
        {
            foreach (Sprite sprite in sprites)
            {
                sprite.cords = new Vector2(CORDS.X, CORDS.Y);
            }
        }
        public virtual void ResetScale()
        {
            foreach (Sprite sprite in sprites)
            {
                sprite.scale = Helper.spriteScale;
            }
        }
        public virtual void UpdateScale(float SCALE)
        {
            foreach (Sprite sprite in sprites)
            {
                sprite.scale = Helper.spriteScale + SCALE;
            }
        }

        public virtual void SetScale(float SCALE)
        {
            foreach (Sprite sprite in sprites)
            {
                sprite.scale = SCALE;
            }
        }

        public virtual void UpdateRotation(float ROT)
        {
            foreach (Sprite sprite in sprites)
            {
                sprite.rot = ROT;
            }
        }

        public virtual void Draw(Vector2 ORIGIN, Vector2 OFFSET, Color COLOR)
        {
            foreach(Sprite sprite in sprites)
            {
                if (sprite.texture != null || sprite.texture != Helper.content.Load< Texture2D >(""))
                {

                    Helper.spriteBatch.Draw(sprite.texture, new Vector2(sprite.pos.X + OFFSET.X, sprite.pos.Y + OFFSET.X), new Rectangle((int)sprite.cords.X * 16, (int)sprite.cords.Y * 16, (int)sprite.dims.X, (int)sprite.dims.Y), COLOR, sprite.rot, new Vector2(ORIGIN.X, ORIGIN.Y), sprite.scale, SpriteEffects.None, 1f);
                }
            }
        }

        public virtual void Draw()
        {
            foreach (Sprite sprite in sprites)
            {
                if (sprite.texture != null || sprite.texture != Helper.content.Load<Texture2D>(""))
                {

                    Helper.spriteBatch.Draw(sprite.texture, new Vector2(sprite.pos.X, sprite.pos.Y) * Helper.spriteScale, new Rectangle((int)sprite.cords.X * 16, (int)sprite.cords.Y * 16, (int)sprite.dims.X, (int)sprite.dims.Y), Color.White, sprite.rot, Vector2.Zero, sprite.scale, SpriteEffects.None, 1f);
                }
            }
        }

        public virtual void Draw(Color COLOR, float ROT)
        {
            foreach (Sprite sprite in sprites)
            {
                if (sprite.texture != null || sprite.texture != Helper.content.Load<Texture2D>(""))
                {

                    Helper.spriteBatch.Draw(sprite.texture, new Vector2(sprite.pos.X, sprite.pos.Y), new Rectangle((int)sprite.cords.X * 16, (int)ROT * 16, (int)sprite.dims.X, (int)sprite.dims.Y), COLOR, 0, Vector2.Zero, sprite.scale, SpriteEffects.None, 1f);
                }
            }
        }

        public virtual void Draw(Vector2 ORIGIN)
        {
            foreach (Sprite sprite in sprites)
            {
                if (sprite.texture != null || sprite.texture != Helper.content.Load<Texture2D>(""))
                {

                    Helper.spriteBatch.Draw(sprite.texture, new Vector2(sprite.pos.X, sprite.pos.Y) * Helper.spriteScale, new Rectangle((int)sprite.cords.X * 16, 0, (int)sprite.dims.X, (int)sprite.dims.Y), Color.White, 0, ORIGIN, sprite.scale, SpriteEffects.None, 1f);
                }
            }
        }

        public virtual void Draw(Vector2 POS, Vector2 ORIGIN)
        {
            foreach (Sprite sprite in sprites)
            {
                if (sprite.texture != null || sprite.texture != Helper.content.Load<Texture2D>(""))
                {
                    Helper.spriteBatch.Draw(sprite.texture, new Vector2(sprite.pos.X, sprite.pos.Y) * Helper.spriteScale + Helper.screenOffset, new Rectangle((int)sprite.cords.X * 16, 0, (int)sprite.dims.X, (int)sprite.dims.Y), Color.White, 0, ORIGIN, sprite.scale, SpriteEffects.None, 1f);
                }
            }
        }

        public virtual void Draw(Color COLOR)
        {
            foreach (Sprite sprite in sprites)
            {
                if (sprite.texture != null || sprite.texture != Helper.content.Load<Texture2D>(""))
                {

                    Helper.spriteBatch.Draw(sprite.texture, new Vector2(sprite.pos.X, sprite.pos.Y) * Helper.spriteScale, new Rectangle((int)sprite.cords.X * 16, 0, (int)sprite.dims.X, (int)sprite.dims.Y), COLOR, 0, Vector2.Zero, sprite.scale, SpriteEffects.None, 1f);
                }
            }
        }

        public virtual void Draw(Color COLOR, Vector2 POS)
        {
            foreach (Sprite sprite in sprites)
            {
                if (sprite.texture != null || sprite.texture != Helper.content.Load<Texture2D>(""))
                {

                    Helper.spriteBatch.Draw(sprite.texture, new Vector2(sprite.pos.X, sprite.pos.Y) * Helper.spriteScale + Helper.screenOffset, new Rectangle((int)sprite.cords.X * 16, 0, (int)sprite.dims.X, (int)sprite.dims.Y), COLOR, 0, Vector2.Zero, sprite.scale, SpriteEffects.None, 1f);
                }
            }
        }

        public virtual void Draw(Vector2 POS, Color COLOR, float ROT)
        {
            foreach (Sprite sprite in sprites)
            {
                if (sprite.texture != null || sprite.texture != Helper.content.Load<Texture2D>(""))
                {

                    Helper.spriteBatch.Draw(sprite.texture, new Vector2(POS.X, POS.Y) * Helper.spriteScale, new Rectangle((int)sprite.cords.X * 16, (int)sprite.cords.Y * 16, (int)sprite.dims.X, (int)sprite.dims.Y), COLOR, 0, Vector2.Zero, sprite.scale, SpriteEffects.None, 1f);
                }
            }
        }

        public virtual void Draw(Vector2 POS, Color COLOR)
        {
            foreach (Sprite sprite in sprites)  
            {
                if (sprite.texture != null || sprite.texture != Helper.content.Load<Texture2D>(""))
                {
                    Helper.spriteBatch.Draw(sprite.texture, new Vector2(sprite.pos.X, sprite.pos.Y) * Helper.spriteScale + Helper.screenOffset, new Rectangle((int)sprite.cords.X * 16, (int)sprite.cords.Y * 16, (int)sprite.dims.X, (int)sprite.dims.Y), COLOR, 0, Vector2.Zero, sprite.scale, SpriteEffects.None, 1f);
                }
            }
        }


    }
}
