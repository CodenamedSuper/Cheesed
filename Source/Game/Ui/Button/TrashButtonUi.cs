using Cheese;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Cheesed
{
    public class TrashButtonUi : Ui
    {
        public static WarningFrameUi warning;
        public TrashButtonUi(int ID, string NAME, Vector2 POS, Vector2 DIMS)
        {
            pos = POS;
            dims = DIMS;
            id = ID;
            name = NAME;

            sprite = new Sprite("Ui\\" + name, pos, dims);



        }

        public override void Update()
        {
            if(warning != null)
            {
                warning.Update();
            }
            Vector2 p = Helper.mouse.newMousePos / Helper.spriteScale;
            sprite.ResetScale();
            if (Helper.AreColliding(p + new Vector2(4, 4), new Vector2(8, 8), pos, dims))
            {
                sprite.UpdateScale(0.5f);

                if (Helper.mouse.LeftClick())
                {
                    warning = new WarningFrameUi(0, "warning", pos - new Vector2(35, 45), new Vector2(64, 38));

                    Sounds.pop1.Play();
                    
                    return;
                }

            }

            base.Update();
        }

        public override void Draw()
        {
            base.Draw();
            if (warning != null)
            {
                warning.Draw();
            }

        }
    }
}
