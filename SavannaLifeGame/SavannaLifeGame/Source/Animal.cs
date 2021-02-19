using System;
using System.Collections.Generic;
using System.Drawing;
using SavannaLifeGame.Data;

namespace SavannaLifeGame.Source
{
    [Serializable]
    public abstract class Animal : Entity
    {
        private const int LowerBoundaryXy = 0;
        private const int UpperBoundaryX = 420;
        private const int UpperBoundaryY = 640;

        public int Speed { get; }
        public int AttackDamage { get; }
        public int ViewRange { get; }
        public EntityTypes PreferredFood { get; }


        protected Animal(EntityTypes type, Point position, Rectangle boundingBox, int health, int speed, int attackDamage, int viewRange, EntityTypes preferredFood) : base(type, position, boundingBox, health)
        {
            if (speed <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(speed), speed, "Speed cannot be negative");
            }
            if (attackDamage <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(attackDamage), attackDamage, "Attack damage cannot be negative");
            }
            if (viewRange <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(viewRange), viewRange, "View range cannot be negative");
            }

            Speed = speed;
            AttackDamage = attackDamage;
            ViewRange = viewRange;
            PreferredFood = preferredFood;
        }

        public abstract override void DrawTo(Graphics graphics);

        public Entity Find(List<Entity> entities, EntityTypes entityType)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities), "Entity list cannot be null.");
            }
            if (entities.Count == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(entities), entities.Count, "Entity list must contain elements.");
            }

            double nearestDistance = ViewRange;
            Entity nearestEntity = null;

            foreach (Entity entity in entities)
            {
                if (entity.Type == entityType)
                {
                    double distance = Math.Sqrt(Math.Pow(entity.Position.X - Position.X, 2) + Math.Pow(entity.Position.Y - Position.Y, 2));

                    if (distance < nearestDistance)
                    {
                        nearestDistance = distance;
                        nearestEntity = entity;
                    }
                }
            }

            return nearestEntity;
        }

        protected void UpdatePositionAndBoundingBox(Point position)
        {
            if (position.X < 0 || position.Y < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(position), position, "Position cannot be empty.");
            }

            Position = position;
            BoundingBox = new Rectangle(Position.X, Position.Y, BoundingBox.Width, BoundingBox.Height);
        }

        protected Point CalculateNewPosition(double angle, int range)
        {
            if (angle < -(Math.PI * 2) || angle > Math.PI * 2)
            {
                throw new ArgumentOutOfRangeException(nameof(angle), angle, "Angle cannot be less than zero or greater than two radians.");
            }
            if (range <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(range), range, "Range cannot be zero or negative");
            }

            int positionX = Position.X + (int)Math.Round(range * Math.Cos(angle));
            int positionY = Position.Y + (int)Math.Round(range * Math.Sin(angle));

            if (positionX < LowerBoundaryXy)
            {
                positionX = LowerBoundaryXy;
            }
            else if (positionX > UpperBoundaryY - BoundingBox.Width)
            {
                positionX = UpperBoundaryY - BoundingBox.Width;
            }
            if (positionY < LowerBoundaryXy)
            {
                positionY = LowerBoundaryXy;
            }
            else if (positionY > UpperBoundaryX - BoundingBox.Height)
            {
                positionY = UpperBoundaryX - BoundingBox.Height;
            }

            return new Point(positionX, positionY);
        }

        public abstract void Move();

        public void MoveTo(Point point)
        {
            int deltaX = point.X - Position.X;
            int deltaY = point.Y - Position.Y;

            double angle = Math.Atan2(deltaY, deltaX);

            Point position = CalculateNewPosition(angle, Speed);
            UpdatePositionAndBoundingBox(position);
        }

        public bool Attack(Entity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
            }

            return (entity.Health -= AttackDamage) < 1;
        }

        public void Eat(Entity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
            }
            if (entity.Type != PreferredFood)
            {
                throw new ArgumentOutOfRangeException(nameof(entity), entity, "This entity cannot be eaten.");
            }
            if (entity.Health > 0)
            {
                throw new ArgumentOutOfRangeException(nameof(entity), entity, "This entity cannot be eaten.");
            }

            Health += entity.MaxHealth / 4;
        }

        public override string ToString()
        {
            string preferredFood;

            switch (PreferredFood)
            {
                case EntityTypes.Grass:
                    preferredFood = "grass";
                    break;
                case EntityTypes.Gazelle:
                    preferredFood = "gazelle";
                    break;
                case EntityTypes.Leopard:
                    preferredFood = "leopard";
                    break;
                case EntityTypes.Hippopotamus:
                    preferredFood = "hippopotamus";
                    break;
                default:
                    preferredFood = "";
                    break;
            }

            string info = base.ToString() + ", " +
                          "speed: " + Speed + "px/frame, " +
                          "view range: " + ViewRange + "px, " +
                          "preferred food: " + preferredFood;

            return info;
        }
    }
}