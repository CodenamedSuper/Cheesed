using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheesed
{
    public class Effects
    {


        public static Sprite Shrink(Sprite sprite)
        {
            sprite.UpdateScale(-0.1f);

            return sprite.GetSprite();
        }

        public static Sprite Grow(Sprite sprite)
        {
            sprite.SetScale(sprite.GetScale() + 0.2f);
            sprite.UpdatePos(sprite.GetPosition() + new Vector2(4 - sprite.GetScale(), 0));

            return sprite.GetSprite();
        }

    }
}
