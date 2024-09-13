using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Cheesed
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;

        public static bool isGameRunning = true;
        public World world;

        public Sprite logo;
        public Text start;
        public Text credit;
        public Text saved;
        public Text emptied;

        public Text versionText;




        public Cursor cursor;

        public static double timer = 0;

        public bool gameStarted;

        public int counter;

        public int musicTimer = 0;

        public int logoPosCounter = 3;
        public bool logoMovingDown = false;

        public static int saveTimer = 0;
        public int emptyTimer = 0;


        private const string buildingsPath = "Save\\buildings.json";

        private const string statsPath = "Save\\stats.json";

        public Game1()
        {


            _graphics = new GraphicsDeviceManager(this);
            _graphics.IsFullScreen = false;
            Content.RootDirectory = "Content";
            IsMouseVisible = false;



        }


        protected override void Initialize()
        {
            Helper.screenWidth = _graphics.PreferredBackBufferWidth = 1280;
            Helper.screenHeight = _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();



            base.Initialize();
        }

        protected override void LoadContent()
        {

            MediaPlayer.Volume = 0.5f;
            Helper.content = this.Content;
            Helper.spriteBatch = new SpriteBatch(GraphicsDevice);

            logo = new Sprite("logo", new Vector2(70, 50), new Vector2(170, 32));
            start = new Text("Press space to start", new Vector2(105, 100), 0, 2);
            credit = new Text("Made by CodenamedSuper", new Vector2(98, 155), 0, 2);
            saved = new Text("Game saved!", new Vector2(275, 115), 0, 1.5f);
            emptied = new Text("Recipes emptied!", new Vector2(255, 100), 0, 1.5f);


            cursor = new Cursor();


            world = new World();

            foreach (BuildingInfo b in LoadBuildings())
            {
                World.AddBuilding(new Vector2(b.x, b.y), b.direction, b.id, b.currentItem, b.initialDirection);

                foreach (Building building in World.entities.OfType<Building>())
                {
                    if (World.entities.IndexOf(building) == World.entities.Count - 1)
                    {
                        building.initialDirection = b.initialDirection;
                        building.currentItem = b.currentItem;
                        building.currentItemCount = b.currentItemCount;
                        if (b.r != 0)
                        {
                            building.color = new Color(b.r, b.g, b.b);

                        }


                    }
                }

            }


            World.stats.gold = LoadStats().gold;
            World.stats.unlockedItems = LoadStats().unlockedItems;
            World.stats.availableItems = LoadStats().availableItems;
            World.stats.madeItems = LoadStats().madeItems;

            World.stats.goldPerMinute = LoadStats().goldPerMinute;
            World.stats.goldPerMinuteTimer = LoadStats().goldPerMinuteTimer;
            World.stats.lastGoldPerMinute = LoadStats().lastGoldPerMinute;
            World.stats.carrierSpeed = LoadStats().carrierSpeed;
            Cursor.currentBuilding = LoadStats().currentBuilding;
            Cursor.currentCount = LoadStats().currentCount;
            World.stats.buildingPrices = LoadStats().buildingPrices;
            World.stats.buildingCounts = LoadStats().buildingCounts;



            Helper.keyboard = new ShibKeyboard();
            Helper.mouse = new ShibMouse();



        }
        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed )
                Exit();
            Helper.gameTime = gameTime;

            Helper.keyboard.Update();
            Helper.mouse.Update();

            Helper.isActive = this.IsActive;
            timer += gameTime.ElapsedGameTime.TotalSeconds;



            if (!gameStarted)
            {
                cursor.Update();
            }

            if (gameStarted == false && Helper.keyboard.GetPress("Space") || gameStarted == false && Helper.mouse.LeftClick())
            {
                MediaPlayer.IsRepeating = false;

                Sounds.pop3.Play();

                gameStarted = true;
                logo = null;
                start = null;
                cursor = null;

            }
            else if (gameStarted == false)
            {
                if (logoMovingDown == false && counter >= 10)
                {
                    logo.UpdatePos(new Vector2(logo.GetPosition().X, logo.GetPosition().Y - 1));
                    logoPosCounter--;
                    counter = 0;
                }
                else if (logoMovingDown && counter >= 10)
                {
                    logo.UpdatePos(new Vector2(logo.GetPosition().X, logo.GetPosition().Y + 1));
                    logoPosCounter++;
                    counter = 0;

                }
                if (logoPosCounter == 0)
                {
                    logoMovingDown = true;
                }
                if (logoPosCounter == 6)
                {
                    logoMovingDown = false;

                }
                counter++;
            }

            if(musicTimer == 25 && !gameStarted)
            {

            }


            if (Helper.keyboard.GetPress("E"))
            {
                emptyTimer = 100;
            }

            if (timer >= 30)
            {
                Save(World.entities, World.stats);
                timer = 0;
                saveTimer = 100;

            }
            if (gameStarted)
            {
                world.Update(gameTime);
            }
            musicTimer++;
            Helper.keyboard.UpdateOld();
            Helper.mouse.UpdateOld();

            base.Update(gameTime);
        }

        public static void Save(List<Entity> entities, Stats stats)
        {
            List<BuildingInfo> e = new List<BuildingInfo>();

            StatsInfo s = new StatsInfo();
            foreach (Building entity in entities.OfType<Building>())
            {
                e.Add(new BuildingInfo());
                e[e.Count - 1].x = entity.pos.X;
                e[e.Count - 1].y = entity.pos.Y;
                e[e.Count - 1].direction = entity.direction;
                e[e.Count - 1].id = entity.id;
                e[e.Count - 1].initialDirection = entity.initialDirection;
                e[e.Count - 1].currentItem = entity.currentItem;
                e[e.Count - 1].currentItemCount = entity.currentItemCount;
                e[e.Count - 1].r = entity.color.R;
                e[e.Count - 1].g = entity.color.G;
                e[e.Count - 1].b = entity.color.B;


            }
            s.AssignInfo(stats.gold, stats.carrierSpeed, stats.goldPerMinute, stats.lastGoldPerMinute, stats.goldPerMinuteTimer, stats.unlockedItems, stats.availableItems, stats.madeItems, Cursor.currentBuilding, Cursor.currentCount, stats.buildingPrices, stats.buildingCounts);

            string serializedEntitiesText = JsonSerializer.Serialize<List<BuildingInfo>>(e);
            Trace.WriteLine(serializedEntitiesText);
            File.WriteAllText(buildingsPath, serializedEntitiesText);

            string serializedStatsText = JsonSerializer.Serialize<StatsInfo>(s);
            Trace.WriteLine(serializedStatsText);
            File.WriteAllText(statsPath, serializedStatsText);

        }

        public List<BuildingInfo> LoadBuildings()
        {
            var deserializedText = File.ReadAllText(buildingsPath);
            return JsonSerializer.Deserialize<List<BuildingInfo>>(deserializedText);
        }

        public StatsInfo LoadStats()
        {
            var deserializedText = File.ReadAllText(statsPath);
            return JsonSerializer.Deserialize<StatsInfo>(deserializedText);
        }






        protected override void Draw(GameTime gameTime)
        {
            if (!gameStarted)
            {
                GraphicsDevice.Clear(Color.CadetBlue);

            }
            else
            {
                GraphicsDevice.Clear(new Color(181, 186, 71));
            }
            Helper.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, transformMatrix: Camera.Transform);

            if (logo != null)
            {
                logo.Draw();
                start.Draw(Color.White);
                credit.Draw(Color.White);
                cursor.Draw();


            }
            if (gameStarted)
            {
                world.Draw();
                saved.Draw(new Color(0, 0, 0, saveTimer));
                emptied.Draw(new Color(0, 0, 0, emptyTimer));
                emptyTimer--;
                saveTimer--;
            }

            Helper.spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}