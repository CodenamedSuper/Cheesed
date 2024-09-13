using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheesed.Source.Game.Regisrty
{
    public class Colors
    {
        public static List<Color> colors = new List<Color>();

        public static string[] colorNames =
        {
           "none","red", "blue", "green", "yellow", "purple", "light_blue"
        };

        public Colors()
        {
            colors.Add(new Color(0,0,0,0));

            colors.Add(RegisterColor("#ff605a"));
            colors.Add(RegisterColor("#549dff"));
            colors.Add(RegisterColor("#48b607"));
            colors.Add(RegisterColor("#f9bc21"));
            colors.Add(RegisterColor("#c391ff"));
            colors.Add(RegisterColor("#3cc6f6"));


        }

        public static Color RegisterColor(string color)
        {
            var hex = color.Replace("#", string.Empty);
            var h = NumberStyles.HexNumber;

            // Parse individual R, G, B components
            var r = int.Parse(hex.Substring(0, 2), h);
            var g = int.Parse(hex.Substring(2, 2), h);
            var b = int.Parse(hex.Substring(4, 2), h);

            // Optional: Parse alpha component (if needed)
            // var a = int.Parse(hex.Substring(6, 2), h);

            // Create the Color instance
            return new Color(r, g, b);
        }
    }

}
