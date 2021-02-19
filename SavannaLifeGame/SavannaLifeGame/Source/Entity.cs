using System;
using System.Drawing;
using SavannaLifeGame.Data;

namespace SavannaLifeGame.Source
{
    [Serializable]
    public abstract class Entity : IDrawable
    {
        private const int MinHealth = 0;

        private int health;

        public EntityTypes Type { get; }
        public Point Position { get; protected set; }
        public Rectangle BoundingBox { get; protected set; }
        public int MaxHealth { get; }
        public int Health
        {
            get => health;
            set
            {
                if (value < MinHealth)
                {
                    health = MinHealth;
                }
                else if (value > MaxHealth)
                {
                    health = MaxHealth;
                }
                else
                {
                    health = value;
                }
            }
        }

        protected Entity(EntityTypes type, Point position, Rectangle boundingBox, int health)
        {
            if (position.X < 0 || position.Y < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(position), position, "Position cannot be negative.");
            }
            if (boundingBox == Rectangle.Empty)
            {
                throw new ArgumentOutOfRangeException(nameof(boundingBox), boundingBox, "Bounding box cannot be empty.");
            }
            if (health < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(health), health, "Health cannot be equal to, or less than zero.");
            }

            Type = type;
            Position = position;
            BoundingBox = boundingBox;
            MaxHealth = health;
            Health = health;
        }

        public abstract void DrawTo(Graphics canvas);

        public override string ToString()
        {
            string type;

            switch (Type)
            {
                case EntityTypes.Grass:
                    type = "grass";
                    break;
                case EntityTypes.Gazelle:
                    type = "gazelle";
                    break;
                case EntityTypes.Leopard:
                    type = "leopard";
                    break;
                case EntityTypes.Hippopotamus:
                    type = "hippopotamus";
                    break;
                default:
                    type = "";
                    break;
            }

            string info = "Type: " + type + ", " + 
                          "position: " + Position.X + "x, " + Position.Y + "y, " + 
                          "bounding box: " + BoundingBox.Width + "w, " + BoundingBox.Height + "h, " + 
                          "health: " + health;

            return info;
        }
    }
}