using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheesed
{
    public class CheeseItem : Item
    {
        public CheeseItem(int ID, string NAME, string DESC, Vector2 POS, Recipe RECIPE, int VALUE, int PRICE, int PARENT) : base(ID, NAME, DESC, POS, RECIPE)
        {
            value = VALUE;
            recipe = RECIPE;
        }
    }
}
