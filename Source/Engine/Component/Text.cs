using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = Microsoft.Xna.Framework.Color;

namespace Cheesed
{
    public class Text
    {
        public SpriteFont normalFont = Helper.content.Load<SpriteFont>("Font\\File");

        public List<Text> texts = new List<Text>();

        public Vector2 pos { set; get; }

        public string text { set; get; }

        public float scale { set; get; }


        public float rot { set; get; }

        public Text()
        {
            
        }
        public Text(string TEXT, Vector2 POS, float ROT, float SCALE)
        {
            texts.Add(new Text {text = TEXT, pos = POS, rot = ROT, scale = SCALE * (Helper.spriteScale / 4) }) ;
        }

        public void UpdateText(string TEXT)
        {
            foreach(Text text in texts)
            {
                text.text = TEXT;
            }
        }
        public void UpdateRotation(float ROT)
        {
            foreach (Text text in texts)
            {
                text.rot = ROT;
            }
        }

        public virtual void UpdatePos(Vector2 POS)
        {
            foreach (Text text in texts)
            {
                text.pos = new Vector2(POS.X, POS.Y);
            }

        }
        public virtual Vector2 GetPos()
        {
            foreach (Text text in texts)
            {
                return text.pos;
            }
            return Vector2.Zero;

        }
        public void UpdateScale(float SCALE)
        {
            foreach (Text text in texts)
            {
                text.scale = SCALE;
            }
        }

        public void Draw()
        {
            foreach(Text text in texts)
            { 
                if (text.text != null || text.text != "")
                {
                    Helper.spriteBatch.DrawString(normalFont, text.text, text.pos * Helper.spriteScale + Helper.screenOffset, Color.Black, text.rot, Vector2.Zero, text.scale, SpriteEffects.None, 0);
                }
            }
        }

        public void Draw(Color COLOR)
        {
            foreach (Text text in texts)
            {
                if (text.text != null || text.text != "")
                {
                    Helper.spriteBatch.DrawString(normalFont, text.text, text.pos * Helper.spriteScale + Helper.screenOffset, COLOR, text.rot, Vector2.Zero, text.scale, SpriteEffects.None, 0);
                }
            }
        }


        }
    }
