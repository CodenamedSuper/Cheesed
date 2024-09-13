using Cheese;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Cheesed
{
    public class CategoryButton : Ui
    {
        public int index;
        public string category = "production";

        public CategoryButton(int ID, string NAME, Vector2 POS, Vector2 DIMS, string CATEG)
        {
            pos = POS;
            dims = DIMS;
            id = ID;
            name = NAME;
            category = CATEG;

            sprite = new Sprite("Ui\\" + name, pos, dims);



        }

        public override void Update()
        {
            Vector2 p = Helper.mouse.newMousePos / Helper.spriteScale;
            sprite.ResetScale();
            if (Helper.AreColliding(p + new Vector2(6, 6), new Vector2(4, 4), pos, dims))
            {
                sprite.UpdateScale(0.5f);

                if (Helper.mouse.LeftClick())
                {
                    sprite.ResetScale();
                    StoreUi.category = category;

                    Sounds.pop1.Play();
                    return;
                }

            }

                base.Update();
        }
    }
}
