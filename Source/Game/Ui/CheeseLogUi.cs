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
    public class CheeseLogUi : Ui
    {
        public Text title;
        public int spacing = 0;

        public Color unlockedColor = new Color(40, 40, 40, 90);


        public List<CheeseItem> cheeses = new List<CheeseItem>();

        public List<Sprite> sprites = new List<Sprite>();
        public List<Text> names = new List<Text>();
        public List<Text> counts = new List<Text>();
        public List<Text> prices = new List<Text>();


        public int currentCheese = -1;

        public Sprite currentCheeseSprite;
        public Recipe currentRecipe;
        public Text currentName;
        public Text currentDesc;
        public Text currentValue;


        public Text cheesesHeader;
        public Text combos;


        public List<Sprite> currentRecipeSprites = new List<Sprite>(3);
        public List<Sprite> currentComboSprites = new List<Sprite>(3);






        public CheeseLogUi(Vector2 POS)
        {
            pos = new Vector2(POS.X - 32, POS.Y);


            cheesesHeader = new Text("Cheeses", new Vector2(pos.X + 2, pos.Y + 2), 0, 2f);
            combos = new Text("Possible Combinations", new Vector2(pos.X + 162, pos.Y + 75), 0, 1.1f);

            foreach (CheeseItem item in Items.items.OfType<CheeseItem>())
            {

                    cheeses.Add(item);
                

            }
            float x, y;
            x = 0;
            y = 0;
            for (int i = 0; i < cheeses.Count; i++)
            {
                    float w, h;
                    h = 2;
                    w = i;

                    Vector2 p = new Vector2(w, h);
                    
                    sprites.Add(new Sprite("items", new Vector2(pos.X + (18 * x), pos.Y + 8 + 18 * y), new Vector2(16, 16), Helper.SpriteCords(cheeses[i].id, new Vector2(12,12)), 0, 0));
                    x++;

                    if (x == 7)
                    {
                        y++;
                        x = 0;
                    }

            }

            currentCheeseSprite = new Sprite("items", Vector2.Zero, Helper.gridSize, new Vector2(0, 0), 0, 0f);
            currentRecipe = new Recipe(new Vector3(-1,-1,-1), 1);

            currentRecipeSprites.Add(null);
            currentRecipeSprites.Add(null);
            currentRecipeSprites.Add(null);

            currentComboSprites.Add(null);
            currentComboSprites.Add(null);
            currentComboSprites.Add(null);

        }


        public override void Update()
        {
            foreach (Sprite cheese in sprites)
            {
                cheese.ResetScale();

                Vector2 p = Helper.mouse.newMousePos / Helper.spriteScale;
                if (Helper.AreColliding(p + new Vector2(8, 8), new Vector2(2, 2), cheese.GetPosition(), cheese.GetDims()))
                {
                    cheese.UpdateScale(0.5f);
                    if (Helper.mouse.LeftClick())
                    {
                        cheese.ResetScale();
                        currentCheese = sprites.IndexOf(cheese);
                        foreach (CheeseItem item in cheeses)
                        {
                            if (item.sprite.GetCords() == cheese.GetCords())
                            {
                                currentRecipe = item.recipe;
                            }
                        }

                    }
                }

            }

            if (currentCheese != -1)
            {
                Vector2 s = new Vector2(16, 16);

                if (World.stats.madeItems[currentCheese])
                {
                    if (Helper.spriteScale == 4)
                    {
                        currentCheeseSprite = new Sprite("items", new Vector2(pos.X + 170, pos.Y + 10), Helper.gridSize, Helper.SpriteCords(cheeses[currentCheese].id, new Vector2(12, 12)), 0, 8f);
                    }
                    else
                    {
                        currentCheeseSprite = new Sprite("items", new Vector2(pos.X + 170, pos.Y + 10), Helper.gridSize, Helper.SpriteCords(cheeses[currentCheese].id, new Vector2(12, 12)), 0, 6f);

                    }
                    currentName = new Text(cheeses[currentCheese].name, new Vector2(pos.X + 162, pos.Y), 0, 1.8f);
                    currentDesc = new Text(cheeses[currentCheese].desc, new Vector2(pos.X + 162, pos.Y + 10), 0, 1);
                    currentValue = new Text(cheeses[currentCheese].value + " Gold", new Vector2(pos.X + 175, pos.Y + 60), 0, 2);
                }
                else
                {
                    if (Helper.spriteScale == 4)
                    {
                        currentCheeseSprite = new Sprite("items", new Vector2(pos.X + 170, pos.Y + 10), Helper.gridSize, Helper.SpriteCords(cheeses[currentCheese].id, new Vector2(12, 12)), 0, 8f);
                    }
                    else
                    {
                        currentCheeseSprite = new Sprite("items", new Vector2(pos.X + 170, pos.Y + 10), Helper.gridSize, Helper.SpriteCords(cheeses[currentCheese].id, new Vector2(12, 12)), 0, 6f);

                    }
                    currentName = new Text("???", new Vector2(pos.X + 162, pos.Y), 0, 1.8f);
                    currentDesc = new Text("???", new Vector2(pos.X + 162, pos.Y + 10), 0, 1);
                    currentValue = new Text("???" + " Gold", new Vector2(pos.X + 175, pos.Y + 60), 0, 2);
                }

                if (currentRecipe.ingredients.X != -1)
                {

                    currentRecipeSprites[0] = new Sprite("items", new Vector2(pos.X + 148 + s.X * 1, pos.Y + 40), Helper.gridSize, Helper.SpriteCords((int)currentRecipe.ingredients.X, new Vector2(12, 12)), 0, 4f);

                }
                if (currentRecipe.ingredients.Y != -1)
                {
                    currentRecipeSprites[1] = new Sprite("items", new Vector2(pos.X + 148 + s.X * 2, pos.Y + 40), Helper.gridSize, Helper.SpriteCords((int)currentRecipe.ingredients.X, new Vector2(12, 12)), 0, 4f);

                }
                if (currentRecipe.ingredients.Z != -1)
                {
                    currentRecipeSprites[2] = new Sprite("items", new Vector2(pos.X + 148 + s.X * 3, pos.Y + 40), Helper.gridSize, Helper.SpriteCords((int)currentRecipe.ingredients.Y, new Vector2(12, 12)), 0, 4f);

                }
                currentComboSprites[0] = null;
                currentComboSprites[1] = null;
                currentComboSprites[2] = null;

                int count = 0;
                foreach (CheeseItem item in Items.items.OfType<CheeseItem>())
                {
                    if (count < 3)
                    {
                        if (item.recipe.GetIngredients().X == currentCheese + 2 || item.recipe.GetIngredients().Y == currentCheese + 2 || item.recipe.GetIngredients().Z == currentCheese + 2)
                        {

                            if (World.stats.madeItems[item.id])
                            {
                                currentComboSprites[count] = new Sprite("items", new Vector2(pos.X + 148 + s.X * (count + 1), pos.Y + 80), Helper.gridSize, Helper.SpriteCords(item.id, new Vector2(12, 12)), 0, 4f);
                                count++;
                            }
                            else
                            {
                                currentComboSprites[count] = new Sprite("question_mark", new Vector2(pos.X + 148 + s.X * (count + 1), pos.Y + 80), Helper.gridSize, new Vector2(0, 0), 0, 4f);
                                count++;

                            }
                        }
                    }
                }


            }





        }

        public override void Draw()
        {
            Color color = new Color(26, 13, 6);
            cheesesHeader.Draw();

            foreach (Sprite sprite in sprites)
            {
                if (World.stats.madeItems[sprites.IndexOf(sprite) + 2])
                {
                    sprite.Draw(sprite.GetPosition() + Helper.screenOffset, Vector2.Zero);

                }
                else
                {
                    sprite.Draw(sprite.GetPosition() + Helper.screenOffset, color);

                }

            }
            if (currentCheese != -1)
            {
                currentName.Draw();
                currentDesc.Draw();
                currentValue.Draw();
                combos.Draw();


            }

            if (!currentRecipe.Matches(new Recipe(new Vector3(-1, -1, -1), 1)))
            {
                if (World.stats.madeItems[(int)currentRecipe.ingredients.X])
                {
                    currentRecipeSprites[0].Draw(currentRecipeSprites[0].GetPosition() + Helper.screenOffset, Vector2.Zero);
                }
                else
                {
                    currentRecipeSprites[0].Draw(currentRecipeSprites[0].GetPosition() + Helper.screenOffset, color);

                }

                if (currentRecipe.ingredients.Y != -1)
                {
                    if (World.stats.madeItems[(int)currentRecipe.ingredients.Y])
                    {
                        currentRecipeSprites[1].Draw(currentRecipeSprites[1].GetPosition() + Helper.screenOffset, Vector2.Zero);
                    }
                    else
                    {
                        currentRecipeSprites[1].Draw(currentRecipeSprites[1].GetPosition() + Helper.screenOffset, color);

                    }
                }
                if (currentRecipe.ingredients.Z != -1)
                {
                    if (World.stats.madeItems[(int)currentRecipe.ingredients.Z])
                    {
                        currentRecipeSprites[2].Draw(currentRecipeSprites[2].GetPosition() + Helper.screenOffset, Vector2.Zero);
                    }
                    else
                    {
                        currentRecipeSprites[2].Draw(currentRecipeSprites[2].GetPosition() + Helper.screenOffset, color);

                    }
                }
            }
            if (currentComboSprites[0] != null)
            {
                currentComboSprites[0].Draw(currentComboSprites[0].GetPosition() + Helper.screenOffset, Vector2.Zero);
            }
            if (currentComboSprites[1] != null)
            {
                currentComboSprites[1].Draw(currentComboSprites[1].GetPosition() + Helper.screenOffset, Vector2.Zero);
            }
            if (currentComboSprites[2] != null)
            {
                currentComboSprites[2].Draw(currentComboSprites[2].GetPosition() + Helper.screenOffset, Vector2.Zero);
            }
            if (currentCheese != -1)
            {
                if (World.stats.madeItems[currentCheese + 2])
                {
                    currentCheeseSprite.Draw(currentCheeseSprite.GetPosition() + Helper.screenOffset, Vector2.Zero);

                }
                else
                {
                    currentCheeseSprite.Draw(currentCheeseSprite.GetPosition() + Helper.screenOffset, color);

                }
            }
        }

    }
}
