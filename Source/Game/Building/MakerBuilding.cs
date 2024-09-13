using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cheesed
{
    public class MakerBuilding : Building
    {
        double time = 0;

        public Recipe recipe = new Recipe(new Vector3(-1,-1,-1), -1);

        public bool hasRecipe = false;
        public int itemId = -1;
        public MakerBuilding(int ID, string NAME, Vector2 POS, int DIRECTION, float PRICE, string CATEG) : base(ID, NAME, POS, DIRECTION, PRICE, CATEG)
        {
            animations = new Animation[8];

            animations[0] = new Animation(1, new Vector2(id, 0), dims);
            animations[1] = new Animation(1, new Vector2(id, 4), dims);
            animations[2] = new Animation(1, new Vector2(id, 8), dims);
            animations[3] = new Animation(1, new Vector2(id, 12), dims);

            animations[4] = new Animation(4, new Vector2(id, 0), dims);
            animations[5] = new Animation(4, new Vector2(id, 4), dims);
            animations[6] = new Animation(4, new Vector2(id, 8), dims);
            animations[7] = new Animation(4, new Vector2(id, 12), dims);

            recipe.SetType(id);


            sprite = new AnimatedSprite("buildings", pos, dims, animations[0].animation, 0, Helper.spriteScale);

        }

        public override void Update()
        {
            base.Update();
            GetIngredients();
            if(recipe.ingredients.X != -1)
            {
                CheckRecipe();

            }

            time += World.time;
            Vector2 p = Helper.Snap(pos + new Vector2(0, 16), 16);


                time = 0;
                foreach (Building building in World.entities.OfType<Building>())
                {
                    if(Helper.AreColliding(pos + new Vector2(0, 16), Helper.gridSize, building.pos, building.dims) && building is CarrierBuilding == false)
                    {
                        return;

                    }
                }
                if (hasRecipe)
                {
                    World.AddItem(p, itemId);
                    powered = true;
                    hasRecipe = false;
                }

            

        }

        public void GetIngredients()
        {
            foreach (Item item in World.entities.OfType<Item>())
            {
                if (Helper.AreColliding(item.coll, this) && Cursor.isHolding == false && !item.isOnStand)
                {
                    if (id == 1 && item.id == 0)
                    {
                        recipe.SetIngredient(item.id);

                        World.entities.Remove(item);
                        powered = true;
                        break;
                    }
                    else if(id != 1)
                    {
                        recipe.SetIngredient(item.id);

                        World.entities.Remove(item);
                        powered = true;
                        break;
                    }
                }
            }
        }

        public void CheckRecipe()
        {

            foreach (Item item in Items.items.OfType<Item>())
            {

                if (recipe.Matches(item.recipe))
                {

                    World.stats.madeItems[item.id] = true;
                    hasRecipe = true;
                    recipe.Reset();
                    itemId = item.id;



                    break;
                }
            }

            if (recipe.ingredients.X != -1 && recipe.ingredients.Y != -1 && recipe.ingredients.Z != -1)
            {
                recipe.Reset();
            }



        }
    }
}
