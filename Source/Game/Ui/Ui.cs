using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheesed { 
    public class Ui : Entity
    {
        public override void Update()
        {

            base.Update();

        }

        public override void Draw()
        {
            sprite.Draw(pos + Helper.screenOffset, Vector2.Zero);
        }
    }
}
