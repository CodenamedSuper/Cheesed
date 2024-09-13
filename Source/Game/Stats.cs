using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheesed { 
    public class Stats
    {
        public int gold = 100;

        public float carrierSpeed = 1;
        public float pistonSpeed = 5;

        public double goldPerMinute = 0;
        public double lastGoldPerMinute = 0;
        public double goldPerMinuteTimer;
        public bool[] unlockedItems;
        public bool[] availableItems;
        public bool[] madeItems;

        public bool finishedTutorial = false;

        public double volume;

        public int[] buildingPrices =
        {
            500, 100, 150, 30, 5, 50, 250, 600, 1000, 5000, 7500
        };
        public int[] buildingCounts = new int[11];
        public int[] oldBuildingPrices =
{
            500, 100, 150, 30, 5, 50, 250, 600, 1000, 5000, 7500
        };


        public void Update(GameTime gameTime)
        {
            goldPerMinuteTimer += gameTime.ElapsedGameTime.TotalSeconds;

            if(goldPerMinuteTimer >= 60)
            {
                goldPerMinuteTimer = 0;
                lastGoldPerMinute = goldPerMinute;
                goldPerMinute = 0;
            }

        }

        public void AddGold(int G)
        {
            gold += G;
            goldPerMinute += G;

        }
        
    }
}
