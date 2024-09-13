using Cheesed;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheese
{
    public class Buildings
    {
        public static List<Building> buildings = new List<Building>();

        public Buildings()
        {
            buildings.Add(new GeneratorBuilding(0, "Generator", Vector2.Zero, 0, 500, "production"));
            buildings.Add(new MakerBuilding(1, "Fermenter", Vector2.Zero, 0, 100, "production"));
            buildings.Add(new MakerBuilding(2, "Heater", Vector2.Zero, 0, 150, "production"));
            buildings.Add(new SellerBuilding(3, "Seller", Vector2.Zero, 0, 25, "utility"));
            buildings.Add(new CarrierBuilding(4, "Carrier", Vector2.Zero, 0, 10, "transportation"));
            buildings.Add(new SorterBuilding(5, "Sorter", Vector2.Zero, 0, -1, 50, "transportation"));
            buildings.Add(new ShufflerBuilding(6, "Shuffler", Vector2.Zero, 0, 50, "transportation"));
            buildings.Add(new IslandBuilding(7, "Island", Vector2.Zero, 0, 50, "transportation"));
            buildings.Add(new IslandBuilding(8, "Crate", Vector2.Zero, 0, 50, "utility"));
            buildings.Add(new StandBuilding(9, "Stand", Vector2.Zero, 0, 50, "utility", -1));
            buildings.Add(new SucculentBuilding(10, "Succulent", Vector2.Zero, 0, 50, "utility"));




        }



    }
}
