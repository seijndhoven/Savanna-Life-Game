using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SavannaLifeGame.Source
{
    public class GameWorld
    {
        private readonly Random random;

        public List<Entity> Entities { get; private set; }

        public GameWorld()
        {
            random = new Random();
            Entities = new List<Entity>();
        }

        public void Add(Entity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity to add cannot be null.");
            }

            Entities.Add(entity);
        }

        public void Remove(Entity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity to add cannot be null.");
            }

            Entities.Remove(entity);
        }

        public Entity Find(Point point)
        {
            if (point.X < 0 || point.Y < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(point), point, "Point cannot be empty.");
            }

            foreach (Entity entity in Entities)
            {
                if (entity.BoundingBox.IntersectsWith(new Rectangle(point.X, point.Y, 1, 1)))
                {
                    return entity;
                }
            }

            return null;
        }

        private Entity GetDestinationEntity(Animal animal)
        {
            Entity destinationEntity = null;

            switch (animal)
            {
                case Gazelle gazelle:
                    destinationEntity = gazelle.Find(Entities, gazelle.Predator) ?? gazelle.Find(Entities, gazelle.PreferredFood);
                    break;
                case Leopard leopard:
                    destinationEntity = leopard.Find(Entities, leopard.Fear) ?? leopard.Find(Entities, leopard.PreferredFood);
                    break;
                case Hippopotamus hippopotamus:
                    destinationEntity = hippopotamus.Find(Entities, hippopotamus.Enemy) ?? hippopotamus.Find(Entities, hippopotamus.PreferredFood);
                    break;
            }

            return destinationEntity;
        }

        private void MoveToDestination(Animal animal, Entity entity)
        {
            if (animal is Leopard leopard && entity.Type == leopard.Fear)
            {
                return;
            }

            Point destination = entity.Position;

            if (animal is Gazelle gazelle)
            {
                if (entity.Type == gazelle.Predator)
                {
                    int mirroredX = animal.Position.X + (entity.Position.X - animal.Position.X) * -1;
                    int mirroredY = animal.Position.Y + (entity.Position.Y - animal.Position.Y) * -1;

                    destination = new Point(mirroredX, mirroredY);
                }
            }

            animal.MoveTo(destination);
        }

        private void OnEntityIntersection(Animal animal, Entity entity)
        {
            if (entity.Type == animal.PreferredFood || !(animal is Gazelle))
            {
                if (animal.Attack(entity))
                {
                    if (entity.Type == animal.PreferredFood)
                    {
                        animal.Eat(entity);
                    }
                }
            }
        }

        public void RunOneTurn()
        {
            List<Entity> deadEntities = new List<Entity>();

            foreach (Entity entity in Entities)
            {
                if (entity.Health < 1)
                {
                    deadEntities.Add(entity);
                }
                else if (entity is Animal animal)
                {
                    Entity destinationEntity = GetDestinationEntity(animal);

                    if (destinationEntity == null)
                    {
                        animal.Move();
                    }
                    else
                    {
                        MoveToDestination(animal, destinationEntity);

                        if (animal.BoundingBox.IntersectsWith(destinationEntity.BoundingBox))
                        {
                            OnEntityIntersection(animal, destinationEntity);
                        }
                    }

                    int randomTurnDamageChance = random.Next(8);

                    if (randomTurnDamageChance == 1)
                    {
                        entity.Health -= 1;
                    }
                }
            }

            foreach (Entity deadEntity in deadEntities)
            {
                Remove(deadEntity);
            }
        }

        public void Load(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException(nameof(fileName), "Filename cannot be null.");
            }
            if (fileName.Trim() == String.Empty)
            {
                throw new ArgumentOutOfRangeException(nameof(fileName), fileName, "Filename cannot be empty.");
            }

            using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                if (formatter.Deserialize(fileStream) is List<Entity> entities)
                {
                    Entities = entities;
                }
            }
        }

        public void Save(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException(nameof(fileName), "Filename cannot be null.");
            }
            if (fileName.Trim() == String.Empty)
            {
                throw new ArgumentOutOfRangeException(nameof(fileName), fileName, "Filename cannot be empty.");
            }

            using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, Entities);
            }
        }
    }
}