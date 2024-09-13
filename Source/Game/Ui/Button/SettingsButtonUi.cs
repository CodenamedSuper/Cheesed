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
    public class SettingsButtonUi : Ui
    {
        public static bool isSettingsOpen = false;
        public static SettingsFrameUi settingsUi = new SettingsFrameUi(0, "settings", new Vector2(86, 28), new Vector2(92, 140));

        public SettingsButtonUi(int ID, string NAME, Vector2 POS, Vector2 DIMS)
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

                if (Helper.mouse.LeftClick() && isSettingsOpen == false)
                {
                    sprite.ResetScale();
                    World.entities.Remove(CheeseLogButtonUi.cheeseLogUi);
                    CheeseLogButtonUi.isCheeseLogOpen = false;
                    CheeseLogButtonUi.cheeseLogUi = null;
                    settingsUi = new SettingsFrameUi(0, "settings", new Vector2(86, 28), new Vector2(92, 140));
                    World.entities.Add(settingsUi);
                    isSettingsOpen = true;

                    Sounds.pop1.Play();
                    return;
                }
                if (Helper.mouse.LeftClick() && isSettingsOpen)
                {
                    sprite.ResetScale();

                    World.entities.Remove(settingsUi);
                    settingsUi = null;
                    isSettingsOpen = false;

                    Sounds.pop2.Play();

                    return;
                }

            }

                base.Update();
        }
    }
}
