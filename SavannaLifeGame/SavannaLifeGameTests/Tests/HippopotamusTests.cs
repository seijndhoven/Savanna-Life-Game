using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SavannaLifeGame.Data;
using SavannaLifeGame.Source;

namespace SavannaLifeGameTests.Tests
{
    [TestClass()]
    public class HippopotamusTests
    {
        [TestMethod()]
        public void WhenHippopotamusIsCreated_ThenHippopotamusHasTypePositionBoundingBoxMaxHealthHealthSpeedAttackDamageViewRangePreferredFoodAndPredator()
        {
            Point position = new Point(2, 2);
            Hippopotamus hippopotamus = new Hippopotamus(position);

            Assert.AreEqual(EntityTypes.Hippopotamus, hippopotamus.Type);
            Assert.AreEqual(position, hippopotamus.Position);
            Assert.AreEqual(position.X, hippopotamus.Position.X);
            Assert.AreEqual(position.Y, hippopotamus.Position.Y);
            Assert.AreEqual(position, hippopotamus.BoundingBox.Location);
            Assert.AreEqual(13, hippopotamus.BoundingBox.Width);
            Assert.AreEqual(13, hippopotamus.BoundingBox.Height);
            Assert.AreEqual(100, hippopotamus.MaxHealth);
            Assert.AreEqual(100, hippopotamus.Health);
            Assert.AreEqual(2, hippopotamus.Speed);
            Assert.AreEqual(7, hippopotamus.AttackDamage);
            Assert.AreEqual(70, hippopotamus.ViewRange);
            Assert.AreEqual(EntityTypes.Grass, hippopotamus.PreferredFood);
            Assert.AreEqual(EntityTypes.Leopard, hippopotamus.Enemy);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WhenHippopotamusIsCreatedWithNegativeXPosition_ThenThrowArgumentNull()
        {
            Hippopotamus hippopotamus = new Hippopotamus(new Point(-1, 0));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WhenHippopotamusIsCreatedWithNegativeYPosition_ThenThrowArgumentNull()
        {
            Hippopotamus hippopotamus = new Hippopotamus(new Point(0, -1));
        }

        [TestMethod()]
        public void WhenHippopotamusHealthIsSetNegative_ThenHippopotamusHealthIsZero()
        {
            Hippopotamus hippopotamus = new Hippopotamus(new Point(34, 87));
            hippopotamus.Health = -1;

            Assert.AreEqual(0, hippopotamus.Health);
        }

        [TestMethod()]
        public void WhenHippopotamusHealthIsSetHigherThanMaxHealth_ThenHippopotamusHealthIsMaxHealth()
        {
            Hippopotamus hippopotamus = new Hippopotamus(new Point(34, 87));
            hippopotamus.Health = 101;

            Assert.AreEqual(hippopotamus.MaxHealth, hippopotamus.Health);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DrawTo_CanvasNull_ThrowArgumentNull()
        {
            Hippopotamus hippopotamus = new Hippopotamus(new Point(1, 1));

            hippopotamus.DrawTo(null);
        }

        [TestMethod()]
        public void Find_NoOtherEntitiesInListEnemy_ReturnsNull()
        {
            Hippopotamus hippopotamus = new Hippopotamus(new Point(2, 1));
            List<Entity> entities = new List<Entity>();

            entities.Add(hippopotamus);

            Entity result = hippopotamus.Find(entities, hippopotamus.Enemy);

            Assert.AreEqual(null, result);
        }

        [TestMethod()]
        public void Find_NoOtherEntitiesInListPreferredFood_ReturnsNull()
        {
            Hippopotamus hippopotamus = new Hippopotamus(new Point(2, 1));
            List<Entity> entities = new List<Entity>();

            entities.Add(hippopotamus);

            Entity result = hippopotamus.Find(entities, hippopotamus.PreferredFood);

            Assert.AreEqual(null, result);
        }

        [TestMethod()]
        public void Find_EnemyInEntitiesListOutsideViewRange_ReturnsNull()
        {
            Hippopotamus hippopotamus = new Hippopotamus(new Point(2, 1));
            Leopard leopard = new Leopard(new Point(72, 1));
            List<Entity> entities = new List<Entity>();

            entities.Add(hippopotamus);
            entities.Add(leopard);

            Entity result = hippopotamus.Find(entities, hippopotamus.Enemy);

            Assert.AreEqual(null, result);
        }

        [TestMethod()]
        public void Find_PreferredFoodInEntitiesListOutsideViewRange_ReturnsNull()
        {
            Hippopotamus hippopotamus = new Hippopotamus(new Point(2, 1));
            Grass grass = new Grass(new Point(2, 71));
            List<Entity> entities = new List<Entity>();

            entities.Add(hippopotamus);
            entities.Add(grass);

            Entity result = hippopotamus.Find(entities, hippopotamus.PreferredFood);

            Assert.AreEqual(null, result);
        }

        [TestMethod()]
        public void Find_EnemyInEntitiesListInsideViewRange_ReturnsEnemy()
        {
            Hippopotamus hippopotamus = new Hippopotamus(new Point(2, 1));
            Leopard leopard = new Leopard(new Point(71, 1));
            List<Entity> entities = new List<Entity>();

            entities.Add(hippopotamus);
            entities.Add(leopard);

            Entity result = hippopotamus.Find(entities, hippopotamus.Enemy);

            Assert.AreEqual(leopard, result);
        }

        [TestMethod()]
        public void Find_PreferredFoodInEntitiesListInsideViewRange_ReturnsPreferredFood()
        {
            Hippopotamus hippopotamus = new Hippopotamus(new Point(2, 1));
            Grass grass = new Grass(new Point(2, 70));
            List<Entity> entities = new List<Entity>();

            entities.Add(hippopotamus);
            entities.Add(grass);

            Entity result = hippopotamus.Find(entities, hippopotamus.PreferredFood);

            Assert.AreEqual(grass, result);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Find_EntitiesNull_ThrowArgumentNull()
        {
            Hippopotamus hippopotamus = new Hippopotamus(new Point(2, 1));

            hippopotamus.Find(null, hippopotamus.PreferredFood);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Find_EntitiesEmpty_ThrowArgumentNull()
        {
            Hippopotamus hippopotamus = new Hippopotamus(new Point(2, 1));
            List<Entity> entities = new List<Entity>();

            hippopotamus.Find(entities, hippopotamus.PreferredFood);
        }

        [TestMethod()]
        public void Move_SpeedAsRange_SetsNewPositionBetweenRangeAndUpdatesBoundingBoxLocation()
        {
            Point position = new Point(50, 50);
            Hippopotamus hippopotamus = new Hippopotamus(position);

            hippopotamus.Move();

            Assert.IsTrue(hippopotamus.Position.X >= position.X - hippopotamus.Speed && hippopotamus.Position.X <= position.X + hippopotamus.Speed);
            Assert.IsTrue(hippopotamus.Position.Y >= position.Y - hippopotamus.Speed && hippopotamus.Position.Y <= position.Y + hippopotamus.Speed);
            Assert.AreEqual(hippopotamus.Position.X, hippopotamus.BoundingBox.Location.X);
            Assert.AreEqual(hippopotamus.Position.Y, hippopotamus.BoundingBox.Location.Y);
        }

        [TestMethod()]
        public void MoveTo_DestinationUpperInLeftCornerQuadrant_SetsNewPositionInQuadrantBetweenRangeAndUpdatesBoundingBoxLocation()
        {
            Point destination = new Point(25, 25);
            Point position = new Point(50, 50);
            Hippopotamus hippopotamus = new Hippopotamus(new Point(50, 50));

            hippopotamus.MoveTo(destination);

            Assert.IsTrue(hippopotamus.Position.X >= position.X - hippopotamus.Speed && hippopotamus.Position.X < position.X);
            Assert.IsTrue(hippopotamus.Position.Y >= position.Y - hippopotamus.Speed && hippopotamus.Position.Y < position.Y);
            Assert.AreEqual(hippopotamus.Position.X, hippopotamus.BoundingBox.Location.X);
            Assert.AreEqual(hippopotamus.Position.Y, hippopotamus.BoundingBox.Location.Y);
        }

        [TestMethod()]
        public void MoveTo_DestinationInUpperRightCornerQuadrant_SetsNewPositionInQuadrantBetweenRangeAndUpdatesBoundingBoxLocation()
        {
            Point destination = new Point(75, 25);
            Point position = new Point(50, 50);
            Hippopotamus hippopotamus = new Hippopotamus(new Point(50, 50));

            hippopotamus.MoveTo(destination);

            Assert.IsTrue(hippopotamus.Position.X <= position.X + hippopotamus.Speed && hippopotamus.Position.X > position.X);
            Assert.IsTrue(hippopotamus.Position.Y >= position.Y - hippopotamus.Speed && hippopotamus.Position.Y < position.Y);
            Assert.AreEqual(hippopotamus.Position.X, hippopotamus.BoundingBox.Location.X);
            Assert.AreEqual(hippopotamus.Position.Y, hippopotamus.BoundingBox.Location.Y);
        }

        [TestMethod()]
        public void MoveTo_DestinationInLowerRightCornerQuadrant_SetsNewPositionInQuadrantBetweenRangeAndUpdatesBoundingBoxLocation()
        {
            Point destination = new Point(75, 75);
            Point position = new Point(50, 50);
            Hippopotamus hippopotamus = new Hippopotamus(new Point(50, 50));

            hippopotamus.MoveTo(destination);

            Assert.IsTrue(hippopotamus.Position.X <= position.X + hippopotamus.Speed && hippopotamus.Position.X > position.X);
            Assert.IsTrue(hippopotamus.Position.Y <= position.Y + hippopotamus.Speed && hippopotamus.Position.Y > position.Y);
            Assert.AreEqual(hippopotamus.Position.X, hippopotamus.BoundingBox.Location.X);
            Assert.AreEqual(hippopotamus.Position.Y, hippopotamus.BoundingBox.Location.Y);
        }

        [TestMethod()]
        public void MoveTo_DestinationInLowerLeftCornerQuadrant_SetsNewPositionInQuadrantBetweenRangeAndUpdatesBoundingBoxLocation()
        {
            Point destination = new Point(25, 75);
            Point position = new Point(50, 50);
            Hippopotamus hippopotamus = new Hippopotamus(new Point(50, 50));

            hippopotamus.MoveTo(destination);

            Assert.IsTrue(hippopotamus.Position.X >= position.X - hippopotamus.Speed && hippopotamus.Position.X < position.X);
            Assert.IsTrue(hippopotamus.Position.Y <= position.Y + hippopotamus.Speed && hippopotamus.Position.Y > position.Y);
            Assert.AreEqual(hippopotamus.Position.X, hippopotamus.BoundingBox.Location.X);
            Assert.AreEqual(hippopotamus.Position.Y, hippopotamus.BoundingBox.Location.Y);
        }

        [TestMethod()]
        public void Attack_GrassEntity_SetsEntityHealthMinusAttackDamageAndReturnsFalse()
        {
            Hippopotamus hippopotamus = new Hippopotamus(new Point(50, 50));
            Grass grass = new Grass(new Point(50, 50));

            bool result = hippopotamus.Attack(grass);

            Assert.AreEqual(grass.MaxHealth - hippopotamus.AttackDamage, grass.Health);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void Attack_GrassEntity_ReturnsTrueWhenEntityIsDead()
        {
            Hippopotamus hippopotamus = new Hippopotamus(new Point(50, 50));
            Grass grass = new Grass(new Point(50, 50));

            bool result = false;

            while (grass.Health > 0)
            {
                result = hippopotamus.Attack(grass);
            }

            Assert.AreEqual(0, grass.Health);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Attack_NullEntity_ThrowArgumentNull()
        {
            Hippopotamus hippopotamus = new Hippopotamus(new Point(50, 50));

            hippopotamus.Attack(null);
        }

        [TestMethod()]
        public void Eat_PreferredFoodEntity_UpsHealthWithQuarterOfEntityMacHealth()
        {
            Hippopotamus hippopotamus = new Hippopotamus(new Point(50, 50));
            Grass grass = new Grass(new Point(55, 55));
            hippopotamus.Health = 20;
            grass.Health = 0;

            hippopotamus.Eat(grass);

            Assert.AreEqual(32, hippopotamus.Health);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Eat_NullEntity_ThrowArgumentNull()
        {
            Hippopotamus hippopotamus = new Hippopotamus(new Point(50, 50));

            hippopotamus.Eat(null);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Eat_EntityThatIsNotPreferredFood_ThrowArgumentOutOfRange()
        {
            Hippopotamus hippopotamus = new Hippopotamus(new Point(50, 50));
            Leopard leopard = new Leopard(new Point(55, 55));

            hippopotamus.Eat(leopard);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Eat_EntityThatIsPreferredFoodButNotDead_ThrowArgumentOutOfRange()
        {
            Hippopotamus hippopotamus = new Hippopotamus(new Point(50, 50));
            Grass grass = new Grass(new Point(55, 55));

            hippopotamus.Eat(grass);
        }

        [TestMethod()]
        public void ToString_hippopotamusProperties_SetsAllPropertiesInString()
        {
            Hippopotamus hippopotamus = new Hippopotamus(new Point(1, 3));

            Assert.AreEqual("Type: hippopotamus, position: 1x, 3y, bounding box: 13w, 13h, health: 100, speed: 2px/frame, view range: 70px, preferred food: grass, enemy: leopard", hippopotamus.ToString());
        }
    }
}