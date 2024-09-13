using Cheese;
using Cheesed.Source.Game.Regisrty;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Cheesed.Building;

namespace Cheesed
{
    public class World
    {
        public Buildings buildings;
        public Items items;
        public Colors colors;

        public static int ItemCount = 0;
        public static List<Entity> entities = new List<Entity>();
        public Vector2 mousePos;

        public Text goldText;
        public Text goldPerMinuteText;

        public static double time;





        public static Stats stats = new Stats();
        public World()
        {


            buildings = new Buildings();
            items = new Items();
            colors = new Colors();

            entities.Add(new Cursor());





            goldText = new Text(stats.gold + " Cheese",new Vector2(100, 10), 0, 2);
            goldPerMinuteText = new Text(stats.lastGoldPerMinute + " Gold Per Minute", new Vector2(100, 20), 0, 2);

            AddUis();

            stats.unlockedItems = new bool[Items.items.Count];
            stats.madeItems = new bool[Items.items.Count];
            stats.availableItems = new bool[Items.items.Count];



        }

        public static void AddBuildings()
        {
            World.AddBuilding(new Vector2(144, 32), 0, 0, -1, 0);
            World.AddBuilding(new Vector2(144, 48), 0, 4, -1, 0);
            World.AddBuilding(new Vector2(144, 64), 0, 1, -1, 0);
            World.AddBuilding(new Vector2(144, 80), 0, 4, -1, 0);
            World.AddBuilding(new Vector2(144, 96), 0, 2, -1, 0);
            World.AddBuilding(new Vector2(144, 112), 0, 4, -1, 0);
            World.AddBuilding(new Vector2(144, 128), 0, 3, -1, 0);

        }

        public static void AddUis()
        {

            entities.Add(new StoreFrameUi(0, "store", new Vector2(20, 28), new Vector2(64, 140)));
            entities.Add(new CheeseLogButtonUi(1, "cheese_log_button", new Vector2(30, 5), new Vector2(22, 22)));
            entities.Add(new SettingsButtonUi(2, "settings_button", new Vector2(54, 5), new Vector2(22, 22)));

            entities.Add(new CategoryButton(3, "production_button", new Vector2(1, 32), new Vector2(16, 16), "production"));
            entities.Add(new CategoryButton(4, "transportation_button", new Vector2(1, 54), new Vector2(16, 16), "transportation"));
            entities.Add(new CategoryButton(5, "utility_button", new Vector2(1, 76), new Vector2(16, 16), "utility"));

            entities.Add(new ColorButtonUi(6, "none", new Vector2(252, 132), new Vector2(16, 16)));
            entities.Add(new ColorButtonUi(7, "red", new Vector2(252 + 18, 132), new Vector2(16, 16)));
            entities.Add(new ColorButtonUi(8, "blue", new Vector2(252 + 18 * 2, 132), new Vector2(16, 16)));
            entities.Add(new ColorButtonUi(9, "green", new Vector2(252, 132 + 18), new Vector2(16, 16)));
            entities.Add(new ColorButtonUi(10, "yellow", new Vector2(252 + 18, 132 + 18), new Vector2(16, 16)));
            entities.Add(new ColorButtonUi(11, "purple", new Vector2(252 + 18 * 2, 132 + 18), new Vector2(16, 16)));


        }

        public void Update(GameTime gameTime)
        {
            mousePos = Helper.mouse.newMousePos / Helper.spriteScale;
            foreach (Entity entity in entities.ToList())
            {
                entity.Update();
            }
            goldText.UpdatePos(goldText.GetPos());
            goldPerMinuteText.UpdatePos(goldPerMinuteText.GetPos());

            stats.Update(gameTime);
            goldText.UpdateText(stats.gold + " Gold");
            goldPerMinuteText.UpdateText($"{stats.lastGoldPerMinute:0}" + " Gold Per Minute");
            time = gameTime.ElapsedGameTime.TotalSeconds;

        }

        public static void AddBuilding(Vector2 POS, int DIRECTION, int ID, int CURRENT_ITEM, int INITIAL_DIRECTION)
        {
            Vector2 pos = Helper.Snap(POS, 16);
            foreach (Building building in Buildings.buildings)
            {
                if (building.id == ID && ID == 0)
                {
                    entities.Add(new GeneratorBuilding(building.id, building.name, pos, DIRECTION, building.price, building.category));
                }
                if (building.id == ID && ID == 2 || building.id == ID && ID == 1)
                {
                    entities.Add(new MakerBuilding(building.id, building.name, pos, DIRECTION, building.price, building.category));

                }
                if (building.id == ID && ID == 4)
                {
                    entities.Add(new CarrierBuilding(building.id, building.name, pos, DIRECTION, building.price, building.category));
                }
                if (building.id == ID && ID == 5)
                {
                    entities.Add(new SorterBuilding(building.id, building.name, pos, DIRECTION, INITIAL_DIRECTION, building.price, building.category));

                }
                if (building.id == ID && ID == 3)
                {
                    entities.Add(new SellerBuilding(building.id, building.name, pos, DIRECTION, building.price, building.category));

                }
                if (building.id == ID && ID == 6)
                {
                    entities.Add(new ShufflerBuilding(building.id, building.name, pos, DIRECTION, building.price, building.category));

                }
                if (building.id == ID && ID == 7)
                {
                    entities.Add(new IslandBuilding(building.id, building.name, pos, DIRECTION, building.price, building.category));

                }
                if (building.id == ID && ID == 8)
                {
                    entities.Add(new CrateBuilding(building.id, building.name, pos, DIRECTION, building.price, building.category));

                }
                if (building.id == ID && ID == 9)
                {
                    entities.Add(new StandBuilding(building.id, building.name, pos, DIRECTION, building.price, building.category, CURRENT_ITEM));

                }
                if (building.id == ID && ID == 10)
                {
                    entities.Add(new SucculentBuilding(building.id, building.name, pos, DIRECTION, building.price, building.category));

                }
            }
        }

        public static void AddItem(Vector2 POS, int ID)
        {

            Vector2 pos = Helper.Snap(POS, 16);
            foreach (CheeseItem item in Items.items.OfType<CheeseItem>())
            {

                if (item is CheeseItem && item.id == ID)
                {
                    entities.Add(new CheeseItem(item.id, item.name, item.desc, pos, item.recipe, item.value, 0, 0));
                    return;


                }

            }
            foreach (CurdItem item in Items.items.OfType<CurdItem>())
            {
                if (item is CurdItem && item.id == ID)
                {
                    entities.Add(new CurdItem(item.id, item.name, item.desc, pos, item.recipe));
                    return;
                }
            }


                foreach (Item item in Items.items)
            {

                if (item is Item && item.id == ID)
                {
                    entities.Add(new Item(item.id, item.name, item.desc, pos, item.recipe));
                }
            }

        }

        public static Building Left(Entity E)
        {
            Vector2 pos = E.pos - new Vector2(Helper.gridSize.Y, 0);

            foreach (Building building in entities.OfType<Building>())
            {

                if (Helper.AreColliding(pos, Helper.gridSize, building.pos, building.dims))
                {

                    return building;
                }
            }
            return null;
        }

        public static Building Right(Entity E)
        {
            Vector2 pos = E.pos + new Vector2(Helper.gridSize.Y, 0);

            foreach (Building building in entities.OfType<Building>())
            {

                if (Helper.AreColliding(pos, Helper.gridSize, building.pos, building.dims))
                {

                    return building;
                }
            }
            return null;
        }

        public static Building Up(Entity E)
        {
            Vector2 pos = E.pos - new Vector2(0, Helper.gridSize.Y) ;

            foreach (Building building in entities.OfType<Building>())
            {

                if (Helper.AreColliding(pos, Helper.gridSize, building.pos, building.dims))
                {

                    return building;
                }
            }
            return null;
        }

        public static Building Down(Entity E)
        {
            Vector2 pos = E.pos + new Vector2(0, Helper.gridSize.Y);

            foreach (Building building in entities.OfType<Building>())
            {

                if (Helper.AreColliding(pos, Helper.gridSize, building.pos, building.dims))
                {

                    return building;
                }
            }
            return null;
        }

        public void Draw()
            {
            foreach (Building entity in entities.OfType<Building>())
            {
                entity.Draw();
            }
            foreach (Item entity in entities.OfType<Item>())
            {
                entity.Draw();
            }
            foreach (Ui entity in entities.OfType<Ui>())
            {
                entity.Draw();
            }
            goldText.Draw();
            goldPerMinuteText.Draw();
            foreach (Cursor entity in entities.OfType<Cursor>())
            {
                entity.Draw();
            }
            foreach (var item in entities)
            {
              ///  Helper.spriteBatch.Draw(Helper.content.Load<Texture2D>("Img\\Collision"), new Vector2(item.pos.X, item.pos.Y) * Helper.spriteScale, new Rectangle((int)0, (int)0 * 16, (int)item.dims.X, (int)item.dims.Y), Color.White, 0, Vector2.Zero, Helper.spriteScale, SpriteEffects.None, 1f);

            }


        }
    }
}
