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
    public class VbuttonUi : Ui
    {

        public VbuttonUi(int ID, string NAME, Vector2 POS, Vector2 DIMS)
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
                    sprite.ResetScale();

                    Cursor.cameraPos = new Vector2((int)Helper.screenOffset.X,(int)Helper.screenOffset.Y);
                    Helper.screenOffset = Vector2.Zero;

                    World.stats.gold = 100;
                    Game1.timer = 0;
                    Cursor.currentBuilding = -1;
                    Cursor.currentColor = new Color(0, 0, 0, 0);
                    Cursor.currentCount = 0;
                    World.stats.carrierSpeed = 1;
                    World.stats.pistonSpeed = 5;
                    World.stats.goldPerMinute = 0;
                    World.stats.lastGoldPerMinute = 0;
                    World.stats.goldPerMinuteTimer = 0;
                    World.stats.unlockedItems = new bool[Items.items.Count];
                    World.stats.availableItems = new bool[Items.items.Count];
                    World.stats.madeItems = new bool[Items.items.Count];
                    for(int i = 0; i < Items.items.Count; i++)
                    {
                        World.stats.madeItems[i] = false;
                        World.stats.availableItems[i] = false;
                        World.stats.unlockedItems[i] = false;
                    }

                    World.stats.buildingPrices = World.stats.oldBuildingPrices;
                    World.stats.buildingCounts = new int[Buildings.buildings.Count];

                    World.entities.Clear();

                    World.AddBuildings();
                    World.AddUis();

                    World.entities.Add(new Cursor());

                    Sounds.pop1.Play();
                    return;
                }

            }

            base.Update();
        }
    }
}
