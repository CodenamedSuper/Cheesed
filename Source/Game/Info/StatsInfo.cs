using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheesed
{ 
    public class StatsInfo
    {
        public int gold { get; set; }

        public float carrierSpeed { get; set; }

        public double goldPerMinute { get; set; }
        public double lastGoldPerMinute { get; set; }

        public int currentBuilding { get; set; }

        public int currentCount { get; set; }

        public double goldPerMinuteTimer { get; set; }

        public bool[] unlockedItems { get; set; }
        public bool[] availableItems { get; set; }
        public bool[] madeItems { get; set; }

        public int[] buildingPrices { get; set; }

        public int[] buildingCounts { get; set; }




        public void AssignInfo(int G, float SPEED, double GPM, double LGPM, double GPMT, bool[] U, bool[] A, bool[] M, int CURRENT_BUILDING, int CURRENT_COUNT, int[] BP, int[] BC)
        {
            buildingPrices = new int[BP.Length];
            gold = G;
            carrierSpeed = SPEED;
            goldPerMinute = GPM;
            lastGoldPerMinute = LGPM;
            goldPerMinuteTimer = GPMT;
            unlockedItems = U;
            availableItems = A;
            madeItems = M;
            currentBuilding = CURRENT_BUILDING;
            currentCount = CURRENT_COUNT;
            buildingPrices = BP;
            buildingCounts = BC;



        }
    }
}
