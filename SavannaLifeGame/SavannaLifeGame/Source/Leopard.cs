using System;
using System.Drawing;
using SavannaLifeGame.Data;

namespace SavannaLifeGame.Source
{
    [Serializable]
    public class Leopard : Animal
    {
        private const EntityTypes PreferredFoodEntity = EntityTypes.Gazelle;
        private const int Width = 11;
        private const int Height = 11;
        private const int MaxHealthPoints = 80;
        private const int MaxSpeed = 3;
        private const int MaxDamage = 5;
        private const int MaxViewRange = 95;
        private const EntityTypes EntityType = EntityTypes.Leopard;

        private readonly Random random;
        private readonly bool inverseMovement;
        private int rangeBeforeTurning;
        private int heading;
        
        public EntityTypes Fear { get; }

        public Leopard(Point position) : base(EntityType, position, new Rectangle(position.X, position.Y, Width, Height), MaxHealthPoints, MaxSpeed, MaxDamage, MaxViewRange, PreferredFoodEntity)
        {
            random = new Random();
            inverseMovement = random.Next(2) == 1;
            rangeBeforeTurning = 20;
            heading = 1;
            Fear = EntityTypes.Hippopotamus;
        }

        public override void DrawTo(Graphics canvas)
        {
            if (canvas == null)
            {
                throw new ArgumentNullException(nameof(canvas), "Canvas cannot be null.");
            }

            canvas.FillRectangle(Brushes.DarkGoldenrod, Position.X, Position.Y, Height, Width);
            canvas.DrawRectangle(Pens.SaddleBrown, Position.X, Position.Y, Height, Width);
        }

        public override void Move()
        {
            const int directions = 8;
            const int maximumRangeBeforeTurning = 20;
            const double angleIncrement = 0.25;
            double angle = Math.PI * angleIncrement * heading;

            if (inverseMovement)
            {
                angle = Math.PI * 2 - angle;
            }
            if ((rangeBeforeTurning -= Speed) < 1)
            {
                rangeBeforeTurning = maximumRangeBeforeTurning;
                heading = ++heading % directions;
            }

            Point position = CalculateNewPosition(angle, Speed);
            UpdatePositionAndBoundingBox(position);
        }

        public override string ToString()
        {
            return base.ToString() + ", " + "enemy: " + "hippopotamus";
        }
    }
}