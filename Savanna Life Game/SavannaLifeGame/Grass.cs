using System;
using System.Drawing;

namespace SavannaLifeGame
{
    [Serializable]
    public class Grass : Entity
    {
        private const int Height = 8;
        private const int Width = 8;
        private const int MaxHealthPoints = 50;
        private const EntityTypes EntityType = EntityTypes.Grass;

        public Grass(Point position) : base(EntityType, position, new Rectangle(position.X, position.Y, Width, Height), MaxHealthPoints)
        {
        }

        public override void DrawTo(Graphics canvas)
        {
            if (canvas == null)
            {
                throw new ArgumentNullException(nameof(canvas), "Canvas cannot be null");
            }

            canvas.FillRectangle(Brushes.Green, Position.X, Position.Y, Height, Width);
            canvas.DrawRectangle(Pens.DarkGreen, Position.X, Position.Y, Height, Width);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}