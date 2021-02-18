using System;
using System.Drawing;

namespace SavannaLifeGame
{
    [Serializable]
    public class Gazelle : Animal
    {
        private const EntityTypes PreferredFoodEntity = EntityTypes.Grass;
        private const int Width = 10;
        private const int Height = 10;
        private const int MaxHealthPoints = 60;
        private const int MaxSpeed = 2;
        private const int MaxDamage = 3;
        private const int MaxViewRange = 100;
        private const EntityTypes EntityType = EntityTypes.Gazelle;  

        private readonly Random random;

        public EntityTypes Predator { get; }

        public Gazelle(Point position) : base(EntityType, position, new Rectangle(position.X, position.Y, Width, Height), MaxHealthPoints, MaxSpeed, MaxDamage, MaxViewRange, PreferredFoodEntity)
        {
            random = new Random();
            Predator = EntityTypes.Leopard;
        }

        public override void DrawTo(Graphics canvas)
        {
            if (canvas == null)
            {
                throw new ArgumentNullException(nameof(canvas), "Canvas cannot be null.");
            }

            canvas.FillRectangle(Brushes.SaddleBrown, Position.X, Position.Y, Height, Width);
            canvas.DrawRectangle(Pens.Black, Position.X, Position.Y, Height, Width);
        }

        public override void Move()
        {
            double randomAngle = random.Next(1, 360) * (Math.PI / 180);

            Point position = CalculateNewPosition(randomAngle, Speed);
            UpdatePositionAndBoundingBox(position);
        }

        public override string ToString()
        {
            return base.ToString() + ", " + "predator: " + "leopard";
        }
    }
}