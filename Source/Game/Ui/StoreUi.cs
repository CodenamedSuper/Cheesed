using Cheese;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheesed
{
    public class StoreUi : Ui
    {
        public Text title { get; set; }
        public int spacing = 6;

        public static int mode { get; set; }

        public int buildingsMode = 0;
        public int cheesesMode = 1;



        public static bool isColliding { get; set; }

        public int boughtCheeseCount = 0;

        public static string category = "production";



        public List<Building> buildings = new List<Building>();
        public List<CheeseItem> cheeses = new List<CheeseItem>();


        public List<Sprite> sprites = new List<Sprite>();
        public List<Text> names = new List<Text>();
        public List<Text> counts = new List<Text>();
        public List<Text> prices = new List<Text>();
        public List<Text> values = new List<Text>();







        public StoreUi(Vector2 POS)
        {
            pos = POS;

            for (int i = 0; i < Buildings.buildings.Count; i++)
            {
                buildings.Add(Buildings.buildings[i]);
            }
            foreach (CheeseItem item in Items.items.OfType<CheeseItem>())
            {
                cheeses.Add(item);

            }
            float x, y;
            x = 0;
            y = 0;
            for (int i = 0; i < Buildings.buildings.Count; i++)
            {
                if (Buildings.buildings[i].category == category)
                {



                    Vector2 p = new Vector2(x, y);

                    sprites.Add(new Sprite("buildings", new Vector2(pos.X + p.X, pos.Y + p.Y * (Helper.gridSize.X + spacing)), new Vector2(16, 16), new Vector2(buildings[i].id, 0)));


                    names.Add(new Text(buildings[i].name, new Vector2(pos.X - 35, pos.Y + p.Y * (Helper.gridSize.X + spacing)), 0, 1.8f));
                    prices.Add(new Text(buildings[i].price + "G", new Vector2(pos.X + p.X - 36, pos.Y + p.Y * (Helper.gridSize.X + spacing) + 10), 0, 1.6f));
                    counts.Add(new Text(Buildings.buildings[i].count.ToString(), new Vector2(pos.X + p.X - 10, pos.Y + p.Y * (Helper.gridSize.X + spacing) + 10), 0, 2));

                    y++;
                    
                }
                else
                {
                    y = 0;
                }

            }

        }

        public override void Update()
        {


            if (mode == buildingsMode && Helper.isActive)
            {
                sprites.Clear();
                names.Clear();
                prices.Clear();
                counts.Clear();

                float x, y;
                x = 2;
                y = 0;
                for (int i = 0; i < Buildings.buildings.Count; i++)
                {
                    if (Buildings.buildings[i].category == category)
                    {

                        Vector2 p = new Vector2(x, y);

                        sprites.Add(new Sprite("buildings", new Vector2(pos.X + p.X, pos.Y + p.Y * (Helper.gridSize.X + spacing)), new Vector2(16, 16), new Vector2(buildings[i].id, 0)));


                        names.Add(new Text(buildings[i].name, new Vector2(pos.X - 35, pos.Y + p.Y * (Helper.gridSize.X + spacing)), 0, 1.8f));
                        prices.Add(new Text(World.stats.buildingPrices[i] + "G", new Vector2(pos.X + p.X - 36, pos.Y + p.Y * (Helper.gridSize.X + spacing) + 10), 0, 1.6f));
                        counts.Add(new Text(World.stats.buildingCounts[i].ToString(), new Vector2(pos.X + p.X - 10, pos.Y + p.Y * (Helper.gridSize.X + spacing) + 10), 0, 2));

                        y++;
                    }
                    else
                    {
                        sprites.Add(null);


                        names.Add(null);
                        prices.Add(null);
                        counts.Add(null);

                    }
                }
                foreach (Sprite building in sprites)
                {
                    if(building != null) { 
                    building.ResetScale();

                    Vector2 p = Helper.mouse.newMousePos / Helper.spriteScale;
                        if (Helper.AreColliding(p + new Vector2(4, 4), new Vector2(8, 8), building.GetPosition(), building.GetDims()))
                        {
                            isColliding = true;
                            building.UpdateScale(0.5f);

                            if (Helper.mouse.LeftClick() && World.stats.gold >= World.stats.buildingPrices[sprites.IndexOf(building)] && (Cursor.currentBuilding == -1 || Cursor.currentBuilding == sprites.IndexOf(building)))
                            {
                                building.ResetScale();
                                World.stats.gold -= (int)Buildings.buildings[sprites.IndexOf(building)].price;
                                Cursor.currentBuilding = sprites.IndexOf(building);
                                Cursor.currentCount++;
                                World.stats.buildingPrices[sprites.IndexOf(building)] = (int)Math.Round(World.stats.buildingPrices[sprites.IndexOf(building)] * 1.1f);
                                World.stats.buildingCounts[sprites.IndexOf(building)]++;
                                counts[sprites.IndexOf(building)].UpdateText(World.stats.buildingCounts[sprites.IndexOf(building)].ToString());
                                Sounds.pop2.Play();

                            }
                        }
                    }
                    else
                    {
                        isColliding = false;

                    }

                }

            }




        }

        public override void Draw()
        {
            foreach (Sprite sprite in sprites)
            {
                if (sprite != null)
                {
                    sprite.Draw(sprite.GetPosition() + Helper.screenOffset, Vector2.Zero);
                    names[sprites.IndexOf(sprite)].Draw();
                    if (mode == buildingsMode)
                    {
                        if (World.stats.gold >= World.stats.buildingPrices[sprites.IndexOf(sprite)])
                        {
                            prices[sprites.IndexOf(sprite)].Draw();


                        }
                        else
                        {
                            prices[sprites.IndexOf(sprite)].Draw(Color.DarkRed);

                        }
                        counts[sprites.IndexOf(sprite)].Draw();
                    }

                }
            }

        }
    }
}
