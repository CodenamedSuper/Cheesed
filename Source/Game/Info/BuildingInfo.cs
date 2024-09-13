using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheesed
{
    public class BuildingInfo : EntityInfo
    {

        public int direction { get; set; }
        public int initialDirection { get; set; }
        public bool powered { get; set; }

        public Recipe recipe { get; set; }

        public int currentItem { get; set; }

        public int currentItemCount { get; set; }

        public byte r { get; set; }
        public byte g { get; set; }
        public byte b { get; set; }

        public int GetDirection()
        {
            return direction;
        }

        public int GetInitialDirection()
        {
            return initialDirection;
        }

        public Recipe GetRecipe()
        {
            return new Recipe(recipe.GetIngredients(), recipe.GetRecipeType());
        }


    }
}
