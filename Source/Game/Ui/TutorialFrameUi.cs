using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheesed
{
    public class TutorialFrameUi : Ui
    {
        public ContinueButton button;

        public Text text;

        public static int stage;


        public TutorialFrameUi(int ID, string NAME, Vector2 POS, Vector2 DIMS)
        {
            pos = POS;
            dims = DIMS;
            id = ID;
            name = NAME;
            button = new ContinueButton(0, "c", POS + new Vector2(40, 20), Helper.gridSize);
            text = new Text("", new Vector2(pos.X + 10, pos.Y + 10), 0, 2);

            sprite = new Sprite("Ui\\" + name, pos, dims);



        }

        public override void Update()
        {


            base.Update();
            button.Update();

        }

        public override void Draw()
        {
            base.Draw();
            button.Draw();
            text.Draw();
        }
    }
}
