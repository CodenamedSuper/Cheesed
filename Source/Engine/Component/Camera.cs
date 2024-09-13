using Microsoft.Xna.Framework;
using Cheesed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheesed
{
    public class Camera
    {
        public static Matrix Transform { get; private set; }

        public void Follow(Rectangle target)
        {
            var position = Matrix.CreateTranslation(
              -target.X - (target.Width / 2),
              -target.Y - (target.Height / 2),
              0);

            var offset = Matrix.CreateTranslation(
                Helper.screenWidth / 2,
                Helper.screenHeight / 1.5f,
                0);

            Transform = position * offset;
        }
    }
}