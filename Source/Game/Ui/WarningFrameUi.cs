using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheesed
{
    public class WarningFrameUi : Ui
    {
        public VbuttonUi V;
        public XButtonUi X;

        public Text text;
        public WarningFrameUi(int ID, string NAME, Vector2 POS, Vector2 DIMS)
        {
            pos = POS;
            dims = DIMS;
            id = ID;
            name = NAME;

            sprite = new Sprite("Ui\\" + name, pos, dims);

            X = new XButtonUi(0, "x", pos + new Vector2(10, 10), new Vector2(16, 16));
            V = new VbuttonUi(0, "v", pos + new Vector2(35, 10), new Vector2(16,16));
            text = new Text("Are you sure you want \n to delete your progress?", pos + new Vector2(0, -10), 0, 1.2f);


        }

        public override void Update()
        {
            V.Update();
            X.Update();

            sprite.UpdatePos(pos);
        }

        public override void Draw()
        {
            base.Draw();

            V.Draw();
            X.Draw();
            text.Draw();

        }
    }
}
