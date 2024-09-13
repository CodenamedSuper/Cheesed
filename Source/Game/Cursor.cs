using Cheese;
using Cheesed.Source.Game.Regisrty;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheesed
{
    public class Cursor : Entity
    {

        public Camera camera = new Camera();
        public static Vector2 cameraPos;


        public int speed = 4;

        public bool isUiColliding = false;

        public static bool isHolding = false;
        public static bool isBuilding = false;

        public static Color currentColor;

        public static int direction;

        public static int currentBuilding = -1;

        public static int currentCount;

        public bool isHoldingBuilding = false;
        public int heldBuilding = -1;


        public Sprite currentBuildingSprite;
        public Cursor()
        {

            dims = new Vector2(16, 16);

            sprite = new Sprite("cursor", pos, dims, new Vector2(80,80));

            cameraPos = pos;

        }


        public override void Update()
        {
            sprite.UpdateCords(Vector2.Zero);
            pos = (Helper.mouse.newMousePos / Helper.spriteScale + Helper.screenOffset / Helper.spriteScale);
            if (Helper.isActive)
            {
                base.Update();
                Rotate();
                Remove();
                Add();
                Move();
                Clear();
                Empty();
                Paint();
                Zoom();
                MoveBuilding();
                //RotatePlacedBuilding();
                camera.Follow(new Rectangle((int)cameraPos.X + 600, (int)cameraPos.Y + 420, (int)dims.X * (int)Helper.spriteScale, (int)dims.Y * (int)Helper.spriteScale));




                if (isHolding)
                {
                    sprite.UpdateCords(new Vector2(1, 0));
                }
                else
                {
                    sprite.UpdateCords(Vector2.Zero);
                }

                if (currentBuilding != -1)
                {
                    currentBuildingSprite = new Sprite("buildings", Helper.Snap(pos, 16), Buildings.buildings[currentBuilding].dims, new Vector2(Buildings.buildings[currentBuilding].id, direction * 4));

                }
                else
                {
                    currentBuildingSprite = null;

                }
            }
            sprite.SetScale(Helper.spriteScale);



        }

        public void Zoom()
        {
            if(Helper.mouse.GetMouseWheelChange() > 1 && !SettingsButtonUi.isSettingsOpen && !CheeseLogButtonUi.isCheeseLogOpen)
            {
                if(Helper.spriteScale == 3f)
                {
                    Helper.spriteScale = 4f;


                    foreach (ColorButtonUi color in World.entities.OfType<ColorButtonUi>())
                    {
                        color.pos -= new Vector2(80, 50);
                    }
                }
                else
                {
                    Helper.spriteScale = 3f;
                    foreach (ColorButtonUi color in World.entities.OfType<ColorButtonUi>())
                    {
                        color.pos += new Vector2(80, 50);
                    }

                }
            }
        }

        public void ChangeStoreMode()
        {
            if(Helper.keyboard.GetPress("E"))
            {
                StoreUi.mode = 0;
            }
            else if(Helper.keyboard.GetPress("R"))
            {
                StoreUi.mode = 1;
            }
        }

        public void Add()
        {
            foreach (StoreFrameUi ui in World.entities.OfType<StoreFrameUi>())
            {
                if(Helper.AreColliding(new Rectangle((int)ui.pos.X + (int)Helper.screenOffset.X, (int)ui.pos.Y + (int)Helper.screenOffset.Y, (int)ui.dims.X, (int)ui.dims.Y), this)) {
                    isUiColliding = true;
                }
                else
                {
                    isUiColliding = false;
                }
            }
            if (Helper.mouse.LeftClick() && currentBuilding != -1 && !isUiColliding && currentCount > 0)
            {
                bool isColl = false;
                if (currentBuilding == 4 || currentBuilding == 5 || currentBuilding == 6)
                {
                    Debug.WriteLine(direction);
                    World.AddBuilding(pos, direction, currentBuilding, -1, direction);
                }
                else
                {
                    World.AddBuilding(pos, 0, currentBuilding, -1, 0);

                }

                foreach (Building building in World.entities.OfType<Building>())
                {
                    if (Helper.AreColliding(World.entities[World.entities.Count - 1], building))
                    {
                        isColl = true;
                        break;
                    }
                    else
                    {
                        isColl = false;
                    }
                }
                if(isColl)
                {
                    World.entities.RemoveAt(World.entities.Count - 1);
                }
                else
                {
                    currentCount--;
                    if (currentCount == 0)
                    {
                        currentBuilding = -1;
                    }

                    direction = 0;
                    currentBuildingSprite = null;

                    
                    Sounds.pop1.Play();

                }



            }
        }


        public void Move()
        {
            if (Helper.keyboard.GetPress("A"))
            {
                cameraPos.X -= speed;
                Helper.screenOffset.X -= speed;


            }
            if (Helper.keyboard.GetPress("D") )
            {
                cameraPos.X += speed;
                Helper.screenOffset.X += speed;



            }
            if (Helper.keyboard.GetPress("S"))
            {
                cameraPos.Y += speed;
                Helper.screenOffset.Y += speed;



            }
            if (Helper.keyboard.GetPress("W"))
            {

                cameraPos.Y -= speed;
                Helper.screenOffset.Y -= speed;




            }


        }

        public void MoveBuilding()
        {
            foreach (Building building in World.entities.OfType<Building>())
            {
                building.sprite.ResetScale();
                if (Helper.AreColliding(Helper.Snap(pos, Helper.gridSize.X) + new Vector2(6, 6), new Vector2(4, 4), building.pos, building.dims) && currentBuilding == -1)
                {
                    building.sprite.UpdateScale(0.5f);
                    if (Helper.mouse.LeftClickHold() && heldBuilding == -1)
                    {
                        isHoldingBuilding = true;
                        heldBuilding = World.entities.IndexOf(building);
                    }
                    

                }
                if (isHoldingBuilding && World.entities.IndexOf(building) == heldBuilding) 
                {
                    building.pos = Helper.Snap(pos, 16);
                }
                foreach (Building building2 in World.entities.OfType<Building>())
                {
                    if (isHoldingBuilding && Helper.mouse.LeftClickRelease() && !Helper.AreColliding(building, building2))
                    {
                        isHoldingBuilding = false;
                        heldBuilding = -1;
                    }
                }

            }

        }


        public void Clear()
        {
            if(Helper.keyboard.GetPress("Space"))
            {
                for (int i = 0; i < World.entities.Count(); i++)
                {
                    if (World.entities[i] is Item)
                    {
                        World.entities.RemoveAt(i);
                    }
                }
            }
        }

        public void Rotate()
        {

            if (Helper.mouse.RightClick() && currentBuilding != -1)
            {
                direction++;
                if (currentBuilding != -1)
                {
                    currentBuildingSprite.UpdateCords(new Vector2(Buildings.buildings[currentBuilding].id, direction * 4));
                }
                if (direction == 4)
                {
                    direction = 0;
                }
            }
        }


        public void Remove()
        {

            foreach (Building building in World.entities.OfType<Building>())
            {
                building.sprite.ResetScale();
                if(Helper.AreColliding(new Vector2(pos.X + 6, pos.Y + 6), new Vector2(4,4), building.pos, building.dims) && currentBuilding == -1)
                {
                    building.sprite.UpdateScale(0.5f);
                    if (Helper.mouse.RightClick() && World.entities.IndexOf(building) > 10)
                    {
                        foreach (StandBuilding b in World.entities.OfType<StandBuilding>())
                        {
                            if(building == b)
                            {
                                b.currentItem = -1;
                                foreach (Item item in World.entities.OfType<Item>())
                                {
                                    if(b.index != -1 && World.entities.IndexOf(item) == b.index)
                                    {
                                        item.isOnStand = false;
                                        b.index = -1;
                                    }
                                }
                            }
                        }
                        World.stats.gold += (int)Math.Round(World.stats.buildingPrices[building.id] * 0.90909);
                        World.stats.buildingPrices[building.id] = (int)Math.Round(World.stats.buildingPrices[building.id] / 1.1);
                        Sounds.pop3.Play();
                        World.stats.buildingCounts[building.id]--;  

                        World.entities.Remove(building);
                        break;

                    }


                }
            }
        }

        public void Empty()
        {
            if (Helper.keyboard.GetPress("E"))
            {
                foreach (MakerBuilding building in World.entities.OfType<MakerBuilding>())
                {

                    building.recipe.Reset();
                    building.powered = true;

                }
            }
        }

        public void RotatePlacedBuilding()
        {
            foreach (Building building in World.entities.OfType<Building>())
            {
                building.sprite.ResetScale();
                if (Helper.AreColliding(new Vector2(pos.X + 6, pos.Y + 6), new Vector2(4, 4), building.pos, building.dims) && currentBuilding == -1)
                {
                    building.sprite.UpdateScale(0.5f);
                    if (Helper.mouse.LeftClick() && building is CarrierBuilding)
                    {
                        building.direction++;
                        if (building.direction == 4)
                        {
                            building.direction = 0;
                        }
                        Sounds.pop2.Play();

                    }

                    break;

                }
            }
        }

        public void Paint()
        {
            foreach (Building building in World.entities.OfType<Building>())
            {
                building.sprite.ResetScale();
                if (Helper.AreColliding(new Vector2(pos.X + 6, pos.Y + 6), new Vector2(4, 4), building.pos, building.dims) && Helper.mouse.LeftClick() && currentBuilding == -1)
                {
                    if (currentColor != building.color)
                    {
                        building.sprite.UpdateScale(0.5f);
                        building.color = currentColor;
                        Sounds.pop2.Play();
                    }

                    


                    break;

                }
            }
        }

        public void GrabItem()
        {
            foreach (Item Item in World.entities.OfType<Item>())
            {
                if(Helper.mouse.LeftClick() && isHolding)
                {
                    isHolding = false;
                }
               else if (Helper.AreColliding(this, Item) && Helper.mouse.LeftClick() || isHolding)
                {
                    Item.pos = pos - new Vector2(4,4);
                    isHolding = true;


                }

            }

        }

        public override void Draw()
        {
            sprite.Draw(new Vector2(0, 0));

            if (currentBuildingSprite != null)
            {
                currentBuildingSprite.Draw(Helper.Snap(pos, 16), new Color(50, 50, 50, 50));
            }

        }
    }
}
