using System;
using System.Threading;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;


namespace Model
{
    public static class ShapeHelpers
    {


        public static CircleShape RedCircleShape(float size, uint side, Vector2f position, Color color)
        {
            return RedCircleShape(size, side, position, color, Color.Transparent);
        }

        public static CircleShape RedCircleShape(float size, uint side, Vector2f position, Color color, Color fillColor)
        {
            CircleShape shape = new CircleShape(size, side)
            {
                FillColor = fillColor,
                OutlineThickness = 8f,
                OutlineColor = color,
                Position = position,
            };

            return shape;
        }



    }
}
