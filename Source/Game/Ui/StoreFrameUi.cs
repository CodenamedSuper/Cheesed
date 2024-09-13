using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheesed
{
    public class StoreFrameUi : Ui
    {
        public StoreUi content;
        public StoreFrameUi(int ID, string NAME, Vector2 POS, Vector2 DIMS)
        {
            pos = POS;
            dims = DIMS;
            content = new StoreUi(new Vector2(pos.X + 40, pos.Y + 6));
            id = ID;
            name = NAME;

            sprite = new Sprite("Ui\\" + name, pos, dims);


            RegisterContent();

        }

        public virtual void RegisterContent()
        {

        }

        public override void Update()
        {

            sprite.SetScale(Helper.spriteScale);
            content.Update();
            sprite.UpdatePos(pos);
        }

        public override void Draw()
        {
            base.Draw();

            content.Draw();
        }
    }
}
