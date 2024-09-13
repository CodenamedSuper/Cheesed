using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheesed
{
    public class SettingsFrameUi : Ui
    {
        public TrashButtonUi trash;
        public SaveButtonUi save;
        public SettingsFrameUi(int ID, string NAME, Vector2 POS, Vector2 DIMS)
        {
            pos = POS;
            dims = DIMS;
            id = ID;
            name = NAME;

            save = new SaveButtonUi(2, "save_button", pos + new Vector2(25, 100), new Vector2(22, 22));
            trash = new TrashButtonUi(3, "trash_button", pos + new Vector2(50, 100), new Vector2(22, 22));

            sprite = new Sprite("Ui\\" + name, pos, dims);


            RegisterContent();

        }

        public virtual void RegisterContent()
        {

        }

        public override void Update()
        {
            trash.Update();
            save.Update();

        }

        public override void Draw()
        {
            base.Draw();
            trash.Draw();
            save.Draw();
        }

    }
}
