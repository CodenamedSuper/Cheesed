using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheesed
{
    public class Items
    {
        public static List<Item> items = new List<Item>();

        public Items()
        {
            items.Add(new Item(0, "Milk", "The source of all good things",  Vector2.Zero, Recipe.Empty()));
            items.Add(new CurdItem(1, "Milk Curd", "Little clumps of dairy goods", Vector2.Zero, new Recipe(new Vector3(0,-1,-1), 1)));




            items.Add(new CheeseItem(2, "Simple Cheese", "It's a start.", Vector2.Zero, new Recipe(new Vector3(1, -1, -1), 2), 10, 0, -1));

            items.Add(new CheeseItem(3, "Brie", "Best eaten raw... objectively.", Vector2.Zero, new Recipe(new Vector3(2, 1, -1), 2), 18, 25, 2));

            items.Add(new CheeseItem(4, "Parmesan", "Don't buy it pre-graded you monster.", Vector2.Zero, new Recipe(new Vector3(2, 2, 2), 2), 45, 50, 2));

            items.Add(new CheeseItem(5, "Mozzarella", "The ultimate cheese for pizzas!", Vector2.Zero, new Recipe(new Vector3(2, 0, 0), 2), 20, 80, 2));

            items.Add(new CheeseItem(6, "Gouda", "So Goudddd", Vector2.Zero, new Recipe(new Vector3(4, 3, -1), 2), 85, 100, 4));

            items.Add(new CheeseItem(7, "Oaxaca", "Can also be called Cowaca!", Vector2.Zero, new Recipe(new Vector3(5, 5, 5),2), 80, 250, 5));

            items.Add(new CheeseItem(8, "Ricotta", "Excellent used in lasagna!", Vector2.Zero, new Recipe(new Vector3(3, 0, 0), 2), 30, 600, 3));

            items.Add(new CheeseItem(9, "Swiss Cheese", "The universal icon for cheese.", Vector2.Zero, new Recipe(new Vector3(4, 6, -1), 2), 200, 500, 4));

            items.Add(new CheeseItem(10, "Feta", "This is what the greeks built their empire with!", Vector2.Zero, new Recipe(new Vector3(8, 8, 0), 2), 95, 850, 9));

            items.Add(new CheeseItem(11, "Roquefort", "So you're telling me this cheese has fungus?", Vector2.Zero, new Recipe(new Vector3(3, 3, 3), 2), 70, 1000, 3));

            items.Add(new CheeseItem(12, "Manchego", "My ego needs some of that manchego!", Vector2.Zero, new Recipe(new Vector3(6, 6, 6), 2), 350, 2500, 6));

            items.Add(new CheeseItem(13, "Cheddar", "This is the most default cheese in the world.", Vector2.Zero, new Recipe(new Vector3(6, 0, 0), 2), 185, 3400, 6));

            items.Add(new CheeseItem(14, "Cream Cheese", "Where'd that bowl come from?", Vector2.Zero, new Recipe(new Vector3(8, 0, 0), 2), 65, 4000, 9));

            items.Add(new CheeseItem(15, "American Cheese", "THIS is the most default cheese in the world.", Vector2.Zero, new Recipe(new Vector3(13, 13, 13), 2), 650, 10000, 13));

            items.Add(new CheeseItem(16, "Munster", "Best grilled, absolutely melts in your mouth!", Vector2.Zero, new Recipe(new Vector3(5, 5, 13), 2), 250, 12000, 6));

            items.Add(new CheeseItem(17, "Pecorino", "A brighter, creamier version of Parmesan.", Vector2.Zero, new Recipe(new Vector3(4, 8, 12), 2), 800, 25000, 12));

            items.Add(new CheeseItem(18, "Colby", "This might be the most orange thing to have ever oranged!", Vector2.Zero, new Recipe(new Vector3(13, 14, -1), 2), 400, 30000, 13));

            items.Add(new CheeseItem(19, "Oscypek", "This isn't cheese, this is art.", Vector2.Zero, new Recipe(new Vector3(12, 13, 16), 2), 1000, 50000, 16));

            items.Add(new CheeseItem(20, "Camembert", "A stronger, low fat version of brie.", Vector2.Zero, new Recipe(new Vector3(3, 3, 0), 2), 75, 75, 16));

            items.Add(new CheeseItem(21, "Tzfatit", "A soft and salty cheese produced in the middle east.", Vector2.Zero, new Recipe(new Vector3(8, 8, 8), 2), 130, 75, 16));

            items.Add(new CheeseItem(22, "Moon Cheese", "What's next, Mars Chocolate?", Vector2.Zero, new Recipe(new Vector3(10, 10, 10), 2), 560, 75, 16));

            items.Add(new CheeseItem(23, "Smelly Cheese", "This cheese got some mold and worms, is it even worth something?", Vector2.Zero, new Recipe(new Vector3(9, -1, -1), 2), 1, 75, 16));

            items.Add(new CheeseItem(24, "Casu Martzu", "Why are there worms in my  delectable cheese?!?", Vector2.Zero, new Recipe(new Vector3(17, 23, 23), 2), 1500, 75, 16));

            items.Add(new CheeseItem(25, "Burrata", "The ultimate cheese to put on a crispy bread.", Vector2.Zero, new Recipe(new Vector3(8, 5, -1), 2), 150, 75, 16));

            items.Add(new CheeseItem(26, "Akkawi", "Great with fruit!", Vector2.Zero, new Recipe(new Vector3(7, 7, 7), 2), 320, 75, 16));

        }



    }
}
