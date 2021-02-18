using System;
using System.Collections.Generic;
using System.Drawing;

namespace SavannaLifeGame
{
    [Serializable]
    public class Hippopotamus : Animal
    {
        private const EntityTypes EntityType = EntityTypes.Hippopotamus;
        private const int Width = 13;
        private const int Height = 13;
        private const int MaxHealthPoints = 100;
        private const int MaxSpeed = 2;
        private const int MaxDamage = 7;
        private const int MaxViewRange = 70;
        private const EntityTypes PreferredFoodEntity = EntityTypes.Grass;

        private readonly Random random;
        private double angle;
        private int rangeBeforeTurning;
        private bool moving;

        public EntityTypes Enemy { get; }

        public Hippopotamus(Point position) : base(EntityType, position, new Rectangle(position.X, position.Y, Width, Height), MaxHealthPoints, MaxSpeed, MaxDamage, MaxViewRange, PreferredFoodEntity)
        {
            random = new Random();
            angle = 0;
            rangeBeforeTurning = 10;
            moving = false;
            Enemy = EntityTypes.Leopard;
        }

        public override void DrawTo(Graphics canvas)
        {
            if (canvas == null)
            {
                throw new ArgumentNullException(nameof(canvas), "Canvas cannot be null.");
            }

            canvas.FillRectangle(Brushes.MediumSlateBlue, Position.X, Position.Y, Height, Width);
            canvas.DrawRectangle(Pens.Indigo, Position.X, Position.Y, Height, Width);
        }

        public override void Move()
        {
            const int maximumRangeBeforeTurning = 20;
            int randomMovementChance = random.Next(1, 30);

            if (rangeBeforeTurning < 1 && moving)
            {
                rangeBeforeTurning = maximumRangeBeforeTurning;

                moving = false;
            }
            if (randomMovementChance == 1 && !moving)
            {
                angle = random.Next(1, 360) * (Math.PI / 180);

                moving = true;
            }
            else if (moving)
            {
                rangeBeforeTurning -= Speed;

                Point position = CalculateNewPosition(angle, Speed);
                UpdatePositionAndBoundingBox(position);
            }
        }

        public override string ToString()
        {
            return base.ToString() + ", " + "enemy: " + "leopard";
        }
    }
}