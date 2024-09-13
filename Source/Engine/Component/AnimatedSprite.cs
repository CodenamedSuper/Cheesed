using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cheesed
{
    public class AnimatedSprite : Sprite
    {
        public List<AnimatedSprite> animatedSprites = new List<AnimatedSprite>();

        public Vector2[] animation;

        public byte currentAnimationIndex;
        public byte previousAnimationIndex;

        public Rectangle[] sourceRectangles;

        public float timer = 0;
        public float threshold;



        public AnimatedSprite()
        {

        }
        public AnimatedSprite(string TEXTURE, Vector2 POS, Vector2 DIMS, Vector2[] ANIMATION, float ROT, float SCALE)
        {
            animatedSprites.Add(new AnimatedSprite { texture = Helper.content.Load<Texture2D>("Img\\" + TEXTURE), pos = POS, dims = DIMS, animation = ANIMATION, rot = ROT, scale = Helper.spriteScale });
        }

        public AnimatedSprite(string TEXTURE, Vector2 POS, Vector2 DIMS, Vector2 CORDS, float ROT, float SCALE)
        {
            animatedSprites.Add(new AnimatedSprite { texture = Helper.content.Load<Texture2D>("Img\\" + TEXTURE), pos = POS, dims = DIMS, cords = CORDS, rot = ROT, scale = Helper.spriteScale });
        }

        public void Animate(int ANIMSPEED)
        {
            foreach (AnimatedSprite sprite in animatedSprites)
            {
                sprite.sourceRectangles = new Rectangle[sprite.animation.Length];
                for (int i = 0; i < sprite.animation.Length; i++)
                {
                    sprite.sourceRectangles[i] = new Rectangle((int)sprite.animation[i].X * (int)sprite.dims.X, (int)sprite.animation[i].Y * (int)sprite.dims.Y, (int)sprite.dims.X, (int)sprite.dims.Y);

                    if (sprite.animation.Length == 1)
                    {

                        sprite.currentAnimationIndex = 0;

                    }
                    else if (sprite.animation.Length == 2)
                    {

                        sprite.threshold = ANIMSPEED;
                        if (sprite.timer > sprite.threshold)
                        {

                            if (sprite.currentAnimationIndex == 0)
                            {

                                sprite.currentAnimationIndex = 1;
                            }
                            else

                            {
                                sprite.currentAnimationIndex = 0;
                            }

                            sprite.previousAnimationIndex = sprite.currentAnimationIndex;

                            sprite.timer = 0;
                        }

                        else
                        {
                            sprite.timer += (float)Helper.gameTime.ElapsedGameTime.TotalMilliseconds;
                        }
                    }
                    else
                    {
                        sprite.threshold = ANIMSPEED;
                        if (sprite.timer > sprite.threshold)
                        {


                            if (sprite.previousAnimationIndex != sprite.animation.Length - 1)
                            {
                                sprite.currentAnimationIndex++;

                            }
                            else

                            {
                                sprite.currentAnimationIndex = 0;
                            }

                            sprite.previousAnimationIndex = sprite.currentAnimationIndex;

                            sprite.timer = 0;
                        }
                        else
                        {
                            sprite.timer += (float)Helper.gameTime.ElapsedGameTime.TotalMilliseconds;
                        }

                    }
                }
            }
        }

        public Vector2[] GetAnimation()
        {
            foreach (AnimatedSprite sprite in animatedSprites)
            {
                return sprite.animation;
            }
            return null;
        }

        public void UpdateAnimation(Vector2[] ANIMATION)
        {
            foreach (AnimatedSprite sprite in animatedSprites)
            {
                sprite.animation = ANIMATION;
            }
        }

        public override void UpdateTexture(string TEXTURE)
        {
            foreach (AnimatedSprite sprite in animatedSprites)
            {
                sprite.texture = Helper.content.Load<Texture2D>(TEXTURE);
            }
        }

        public override void UpdatePos(Vector2 POS)
        {
            foreach (AnimatedSprite sprite in animatedSprites)
            {
                sprite.pos = new Vector2(POS.X, POS.Y);
            }

        }
        public override void UpdateDims(Vector2 DIMS)
        {
            foreach (AnimatedSprite sprite in animatedSprites)
            {
                sprite.dims = new Vector2(DIMS.X, DIMS.Y);
            }

        }

        public override void UpdateCords(Vector2 CORDS)
        {
            foreach (AnimatedSprite sprite in animatedSprites)
            {
                sprite.cords = new Vector2(CORDS.X, CORDS.Y);
            }
        }
        public override void ResetScale()
        {
            foreach (AnimatedSprite sprite in animatedSprites)
            {
                sprite.scale = Helper.spriteScale;
            }
        }
        public override void UpdateScale(float SCALE)
        {
            foreach (AnimatedSprite sprite in animatedSprites)
            {
                sprite.scale = Helper.spriteScale + SCALE;
            }
        }

        public override void UpdateRotation(float ROT)
        {
            foreach (AnimatedSprite sprite in animatedSprites)
            {
                sprite.rot = ROT;
            }
        }

        public override void Draw()
        {

            foreach (AnimatedSprite sprite in animatedSprites)
            {
                
                if (sprite.texture != null || sprite.texture != Helper.content.Load<Texture2D>(""))
                {
                    Helper.spriteBatch.Draw(sprite.texture, new Vector2(sprite.pos.X, sprite.pos.Y) * Helper.spriteScale, new Rectangle((int)sprite.animation[sprite.currentAnimationIndex].X * (int)sprite.dims.X, (int)sprite.animation[sprite.currentAnimationIndex].Y * 16, (int)sprite.dims.X, (int)sprite.dims.Y), Color.White, sprite.rot, Vector2.Zero, sprite.scale, SpriteEffects.None, 1f);

                }
            }
            
        }
        public override void Draw(Color COLOR)
        {

            foreach (AnimatedSprite sprite in animatedSprites)
            {

                if (sprite.texture != null || sprite.texture != Helper.content.Load<Texture2D>(""))
                {
                    Helper.spriteBatch.Draw(sprite.texture, new Vector2(sprite.pos.X, sprite.pos.Y) * Helper.spriteScale, new Rectangle((int)sprite.animation[sprite.currentAnimationIndex].X * (int)sprite.dims.X, (int)sprite.animation[sprite.currentAnimationIndex].Y * 16, (int)sprite.dims.X, (int)sprite.dims.Y), COLOR, sprite.rot, Vector2.Zero, sprite.scale, SpriteEffects.None, 1f);

                }
            }

        }
        public override void Draw(Vector2 POS, Color COLOR)
        {

            foreach (AnimatedSprite sprite in animatedSprites)
            {

                if (sprite.texture != null || sprite.texture != Helper.content.Load<Texture2D>(""))
                {
                    Helper.spriteBatch.Draw(sprite.texture, POS * Helper.spriteScale, new Rectangle((int)sprite.cords.X * (int)sprite.dims.X, (int)sprite.cords.Y * 16, (int)sprite.dims.X, (int)sprite.dims.Y), COLOR, sprite.rot, Vector2.Zero, Helper.spriteScale, SpriteEffects.None, 1f);

                }
            }

        }

        public void Draw(float SCALE, Vector2 POS, Color COLOR, float ROT)
        {

            foreach (AnimatedSprite sprite in animatedSprites)
            {

                if (sprite.texture != null || sprite.texture != Helper.content.Load<Texture2D>(""))
                {
                    Helper.spriteBatch.Draw(sprite.texture, POS * Helper.spriteScale, new Rectangle((int)sprite.cords.X * (int)sprite.dims.X, (int)sprite.cords.Y * 16, (int)sprite.dims.X, (int)sprite.dims.Y), COLOR, ROT, Vector2.Zero, sprite.scale, SpriteEffects.None, 1f);

                }
            }

        }

        public override void Draw(Color COLOR, float ROT)
        {

            foreach (AnimatedSprite sprite in animatedSprites)
            {

                if (sprite.texture != null || sprite.texture != Helper.content.Load<Texture2D>(""))
                {
                    Helper.spriteBatch.Draw(sprite.texture, new Vector2(sprite.pos.X, sprite.pos.Y) * Helper.spriteScale, new Rectangle((int)sprite.animation[sprite.currentAnimationIndex].X * (int)sprite.dims.X, (int)sprite.animation[sprite.currentAnimationIndex].Y * 16, (int)sprite.dims.X, (int)sprite.dims.Y), COLOR, ROT, Vector2.Zero, Helper.spriteScale, SpriteEffects.None, 1f);

                }
            }

        }

        public override void Draw(Vector2 POS, Color COLOR, float ROT)
        {

            foreach (AnimatedSprite sprite in animatedSprites)
            {

                if (sprite.texture != null || sprite.texture != Helper.content.Load<Texture2D>(""))
                {
                    Helper.spriteBatch.Draw(sprite.texture, POS * Helper.spriteScale, new Rectangle((int)sprite.animation[sprite.currentAnimationIndex].X * (int)sprite.dims.X, (int)sprite.animation[sprite.currentAnimationIndex].Y * 16, (int)sprite.dims.X, (int)sprite.dims.Y), COLOR, ROT, Vector2.Zero, Helper.spriteScale, SpriteEffects.None, 1f);

                }
            }

        }


    }
}

