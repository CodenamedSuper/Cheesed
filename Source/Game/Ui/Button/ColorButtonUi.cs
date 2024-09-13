using Cheese;
using Cheesed.Source.Game.Regisrty;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Cheesed
{
    public class ColorButtonUi : Ui
    {
        public string color = "";

        public ColorButtonUi(int ID, string COLOR, Vector2 POS, Vector2 DIMS)
        {
            pos = POS;
            dims = DIMS;
            id = ID;
            name = color;
            color = COLOR;


            sprite = new Sprite("Ui\\" + color, pos, dims);



        }

        public override void Update()
        {
            Vector2 p = Helper.mouse.newMousePos / Helper.spriteScale;
            sprite.ResetScale();
            if (Helper.AreColliding(p + new Vector2(6, 6), new Vector2(4, 4), pos, dims))
            {
                sprite.UpdateScale(0.5f);

                if (Helper.mouse.LeftClick())
                {
                    sprite.ResetScale();

                    for(int i = 0; i < Colors.colorNames.Length; i++)
                    {
                        if(color == Colors.colorNames[i])
                        {
                            Cursor.currentColor = Colors.colors[i];
                        }
                    }
                    Sounds.pop2.Play();

                    return;
                }

            }

                base.Update();
        }
    }
}
