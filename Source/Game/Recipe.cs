using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheesed
{
    public class Recipe
    {

        public Vector3 ingredients = new Vector3(-1,-1,-1);

        public int type;

        public Recipe(Vector3 INGS, int TYPE)
        {
            type = TYPE;
            ingredients = new Vector3(INGS.X, INGS.Y, INGS.Z);
        }

        public void SetIngredient(int INGREDIENT)
        {
            if(ingredients.X == -1)
            {
                ingredients.X = INGREDIENT;
            }
            else if (ingredients.Y == -1)
            {
                ingredients.Y = INGREDIENT;

            }
            else if (ingredients.Z == -1)
            {
                ingredients.Z = INGREDIENT;

            }
        }

        public void Reset()
        {
            ingredients = new Vector3(-1, -1, -1);
        }

        public static Recipe Empty()
        {
            return new Recipe(new Vector3(-1, -1, -1), -1);
        }

        public void SetType(int TYPE)
        {
            type = TYPE;
        }

        public Vector3 GetIngredients()
        {
            return this.ingredients;
        }

        public int GetRecipeType()
        {
            return this.type;
        }

        public bool Matches(Recipe RECIPE)
        {
            if(type == RECIPE.type)
            {
                if (ingredients.X == RECIPE.ingredients.X && ingredients.Y == RECIPE.ingredients.Y && ingredients.Z == RECIPE.ingredients.Z
                 || ingredients.X == RECIPE.ingredients.Y && ingredients.Y == RECIPE.ingredients.Z && ingredients.Z == RECIPE.ingredients.X
                 || ingredients.X == RECIPE.ingredients.Z && ingredients.Y == RECIPE.ingredients.X && ingredients.Z == RECIPE.ingredients.Y
                 || ingredients.X == RECIPE.ingredients.X && ingredients.Y == RECIPE.ingredients.Z && ingredients.Z == RECIPE.ingredients.Y
                 || ingredients.X == RECIPE.ingredients.Y && ingredients.Y == RECIPE.ingredients.X && ingredients.Z == RECIPE.ingredients.Z
                 || ingredients.X == RECIPE.ingredients.Y && ingredients.Y == RECIPE.ingredients.Y && ingredients.Z == RECIPE.ingredients.X)

                   {
                    return true;
                   }
            }
            return false;
        }
    }
}
