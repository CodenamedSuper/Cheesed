using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheesed
{
    public class ContinueButton : Ui
    {
        public ContinueButton(int ID, string NAME, Vector2 POS, Vector2 DIMS)
        {
            pos = POS;
            dims = DIMS;
            id = ID;
            name = NAME;

            sprite = new Sprite("Ui\\" + name, pos, dims);



        }

        public override void Update()
        {
            Vector2 p = Helper.mouse.newMousePos / Helper.spriteScale;
            sprite.ResetScale();
            if (Helper.AreColliding(p + new Vector2(4, 4), new Vector2(8, 8), pos, dims))
            {
                sprite.UpdateScale(0.5f);

                if (Helper.mouse.LeftClick())
                {
                    TutorialFrameUi.stage++;

                    return;
                }

            }

            base.Update();
        }
    }
}
