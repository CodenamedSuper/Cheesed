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
    public class CheeseLogButtonUi : Ui
    {
        public static bool isCheeseLogOpen = false;
        public static CheeseLogFrameUi cheeseLogUi = new CheeseLogFrameUi(0, "cheese_log", new Vector2(86, 28), new Vector2(228, 140));

        public CheeseLogButtonUi(int ID, string NAME, Vector2 POS, Vector2 DIMS)
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

                if (Helper.mouse.LeftClick() && isCheeseLogOpen == false)
                {
                    sprite.ResetScale();
                    World.entities.Remove(SettingsButtonUi.settingsUi);
                    cheeseLogUi = new CheeseLogFrameUi(0, "cheese_log", new Vector2(86, 28), new Vector2(228, 140));
                    SettingsButtonUi.isSettingsOpen = false;
                    SettingsButtonUi.settingsUi = null;

                    World.entities.Add(cheeseLogUi);
                    isCheeseLogOpen = true;

                    Sounds.pop1.Play();
                    return;
                }
                if (Helper.mouse.LeftClick() && isCheeseLogOpen)
                {
                    sprite.ResetScale();

                    World.entities.Remove(cheeseLogUi);
                    cheeseLogUi = null;
                    isCheeseLogOpen = false;

                    Sounds.pop2.Play();

                    return;
                }

            }

                base.Update();
        }
    }
}
