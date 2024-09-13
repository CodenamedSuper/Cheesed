using Cheese;
using Cheesed.Source.Game.Regisrty;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cheesed
{
    public class SucculentBuilding : Building
    {
        public SucculentBuilding(int ID, string NAME, Vector2 POS, int DIRECTION, float PRICE, string CATEG) : base(ID, NAME, POS, DIRECTION, PRICE, CATEG)
        {
            animations = new Animation[8];

            animations[0] = new Animation(1, new Vector2(id, 0), dims);
            animations[1] = new Animation(1, new Vector2(id, 1), dims);
            animations[2] = new Animation(1, new Vector2(id, 2), dims);
            animations[3] = new Animation(1, new Vector2(id, 3), dims);
            animations[4] = new Animation(1, new Vector2(id, 4), dims);
            animations[5] = new Animation(1, new Vector2(id, 5), dims);


            sprite = new AnimatedSprite("buildings", pos, dims, animations[0].animation, 0, Helper.spriteScale);

        }

        public override void Update()
        {

            sprite.UpdatePos(pos);
            for (int i = 0; i < Colors.colors.Count; i++)
            {
                if (color == Colors.colors[i])
                {
                    sprite.UpdateAnimation(animations[i].animation);
                }
            }
        }
    }

}
