using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheesed
{
    public class CurdItem : Item
    {
        public CurdItem(int ID, string NAME, string DESC, Vector2 POS, Recipe RECIPE) : base(ID, NAME, DESC, POS, RECIPE)
        {
            recipe = RECIPE;
        }
    }
}
