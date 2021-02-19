using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SavannaLifeGame.Data;
using SavannaLifeGame.Source;

namespace SavannaLifeGameTests.Tests
{
    [TestClass()]
    public class LeopardTests
    {
        [TestMethod()]
        public void WhenLeopardIsCreated_ThenLeopardHasTypePositionBoundingBoxMaxHealthHealthSpeedAttackDamageViewRangePreferredFoodAndPredator()
        {
            Point position = new Point(2, 2);
            Leopard leopard = new Leopard(position);

            Assert.AreEqual(EntityTypes.Leopard, leopard.Type);
            Assert.AreEqual(position, leopard.Position);
            Assert.AreEqual(position.X, leopard.Position.X);
            Assert.AreEqual(position.Y, leopard.Position.Y);
            Assert.AreEqual(position, leopard.BoundingBox.Location);
            Assert.AreEqual(11, leopard.BoundingBox.Width);
            Assert.AreEqual(11, leopard.BoundingBox.Height);
            Assert.AreEqual(80, leopard.MaxHealth);
            Assert.AreEqual(80, leopard.Health);
            Assert.AreEqual(3, leopard.Speed);
            Assert.AreEqual(5, leopard.AttackDamage);
            Assert.AreEqual(95, leopard.ViewRange);
            Assert.AreEqual(EntityTypes.Gazelle, leopard.PreferredFood);
            Assert.AreEqual(EntityTypes.Hippopotamus, leopard.Fear);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WhenLeopardIsCreatedWithNegativeXPosition_ThenThrowArgumentNull()
        {
            Leopard leopard = new Leopard(new Point(-1, 0));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WhenLeopardIsCreatedWithNegativeYPosition_ThenThrowArgumentNull()
        {
            Leopard leopard = new Leopard(new Point(0, -1));
        }

        [TestMethod()]
        public void WhenLeopardHealthIsSetNegative_ThenLeopardHealthIsZero()
        {
            Leopard leopard = new Leopard(new Point(34, 87));
            leopard.Health = -1;

            Assert.AreEqual(0, leopard.Health);
        }

        [TestMethod()]
        public void WhenLeopardHealthIsSetHigherThanMaxHealth_ThenLeopardHealthIsMaxHealth()
        {
            Leopard leopard = new Leopard(new Point(34, 87));
            leopard.Health = 81;

            Assert.AreEqual(leopard.MaxHealth, leopard.Health);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DrawTo_CanvasNull_ThrowArgumentNull()
        {
            Leopard leopard = new Leopard(new Point(1, 1));

            leopard.DrawTo(null);
        }

        [TestMethod()]
        public void Find_NoOtherEntitiesInListFear_ReturnsNull()
        {
            Leopard leopard = new Leopard(new Point(2, 1));
            List<Entity> entities = new List<Entity>();

            entities.Add(leopard);

            Entity result = leopard.Find(entities, leopard.Fear);

            Assert.AreEqual(null, result);
        }

        [TestMethod()]
        public void Find_NoOtherEntitiesInListPreferredFood_ReturnsNull()
        {
            Leopard leopard = new Leopard(new Point(2, 1));
            List<Entity> entities = new List<Entity>();

            entities.Add(leopard);

            Entity result = leopard.Find(entities, leopard.PreferredFood);

            Assert.AreEqual(null, result);
        }

        [TestMethod()]
        public void Find_FearInEntitiesListOutsideViewRange_ReturnsNull()
        {
            Leopard leopard = new Leopard(new Point(2, 1));
            Hippopotamus hippopotamus = new Hippopotamus(new Point(97, 1));
            List<Entity> entities = new List<Entity>();

            entities.Add(leopard);
            entities.Add(hippopotamus);

            Entity result = leopard.Find(entities, leopard.Fear);

            Assert.AreEqual(null, result);
        }

        [TestMethod()]
        public void Find_PreferredFoodInEntitiesListOutsideViewRange_ReturnsNull()
        {
            Leopard leopard = new Leopard(new Point(2, 1));
            Gazelle gazelle = new Gazelle(new Point(2, 96));
            List<Entity> entities = new List<Entity>();

            entities.Add(leopard);
            entities.Add(gazelle);

            Entity result = leopard.Find(entities, leopard.PreferredFood);

            Assert.AreEqual(null, result);
        }

        [TestMethod()]
        public void Find_EnemyInEntitiesListInsideViewRange_ReturnsEnemy()
        {
            Leopard leopard = new Leopard(new Point(96, 1));
            Hippopotamus hippopotamus = new Hippopotamus(new Point(2, 1));
            List<Entity> entities = new List<Entity>();

            entities.Add(leopard);
            entities.Add(hippopotamus);

            Entity result = leopard.Find(entities, leopard.Fear);

            Assert.AreEqual(hippopotamus, result);
        }

        [TestMethod()]
        public void Find_PreferredFoodInEntitiesListInsideViewRange_ReturnsPreferredFood()
        {
            Leopard leopard = new Leopard(new Point(2, 1));
            Gazelle gazelle = new Gazelle(new Point(2, 95));
            List<Entity> entities = new List<Entity>();

            entities.Add(leopard);
            entities.Add(gazelle);

            Entity result = leopard.Find(entities, leopard.PreferredFood);

            Assert.AreEqual(gazelle, result);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Find_EntitiesNull_ThrowArgumentNull()
        {
            Leopard leopard = new Leopard(new Point(2, 1));

            leopard.Find(null, leopard.PreferredFood);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Find_EntitiesEmpty_ThrowArgumentNull()
        {
            Leopard leopard = new Leopard(new Point(2, 1));
            List<Entity> entities = new List<Entity>();

            leopard.Find(entities, leopard.PreferredFood);
        }

        [TestMethod()]
        public void Move_SpeedAsRange_SetsNewPositionBetweenRangeAndUpdatesBoundingBoxLocation()
        {
            Point position = new Point(50, 50);
            Leopard leopard = new Leopard(position);

            leopard.Move();

            Assert.IsTrue(leopard.Position.X >= position.X - leopard.Speed && leopard.Position.X <= position.X + leopard.Speed);
            Assert.IsTrue(leopard.Position.Y >= position.Y - leopard.Speed && leopard.Position.Y <= position.Y + leopard.Speed);
            Assert.AreEqual(leopard.Position.X, leopard.BoundingBox.Location.X);
            Assert.AreEqual(leopard.Position.Y, leopard.BoundingBox.Location.Y);
        }

        [TestMethod()]
        public void MoveTo_DestinationUpperInLeftCornerQuadrant_SetsNewPositionInQuadrantBetweenRangeAndUpdatesBoundingBoxLocation()
        {
            Point destination = new Point(25, 25);
            Point position = new Point(50, 50);
            Leopard leopard = new Leopard(new Point(50, 50));

            leopard.MoveTo(destination);

            Assert.IsTrue(leopard.Position.X >= position.X - leopard.Speed && leopard.Position.X < position.X);
            Assert.IsTrue(leopard.Position.Y >= position.Y - leopard.Speed && leopard.Position.Y < position.Y);
            Assert.AreEqual(leopard.Position.X, leopard.BoundingBox.Location.X);
            Assert.AreEqual(leopard.Position.Y, leopard.BoundingBox.Location.Y);
        }

        [TestMethod()]
        public void MoveTo_DestinationInUpperRightCornerQuadrant_SetsNewPositionInQuadrantBetweenRangeAndUpdatesBoundingBoxLocation()
        {
            Point destination = new Point(75, 25);
            Point position = new Point(50, 50);
            Leopard leopard = new Leopard(new Point(50, 50));

            leopard.MoveTo(destination);

            Assert.IsTrue(leopard.Position.X <= position.X + leopard.Speed && leopard.Position.X > position.X);
            Assert.IsTrue(leopard.Position.Y >= position.Y - leopard.Speed && leopard.Position.Y < position.Y);
            Assert.AreEqual(leopard.Position.X, leopard.BoundingBox.Location.X);
            Assert.AreEqual(leopard.Position.Y, leopard.BoundingBox.Location.Y);
        }

        [TestMethod()]
        public void MoveTo_DestinationInLowerRightCornerQuadrant_SetsNewPositionInQuadrantBetweenRangeAndUpdatesBoundingBoxLocation()
        {
            Point destination = new Point(75, 75);
            Point position = new Point(50, 50);
            Leopard leopard = new Leopard(new Point(50, 50));

            leopard.MoveTo(destination);

            Assert.IsTrue(leopard.Position.X <= position.X + leopard.Speed && leopard.Position.X > position.X);
            Assert.IsTrue(leopard.Position.Y <= position.Y + leopard.Speed && leopard.Position.Y > position.Y);
            Assert.AreEqual(leopard.Position.X, leopard.BoundingBox.Location.X);
            Assert.AreEqual(leopard.Position.Y, leopard.BoundingBox.Location.Y);
        }

        [TestMethod()]
        public void MoveTo_DestinationInLowerLeftCornerQuadrant_SetsNewPositionInQuadrantBetweenRangeAndUpdatesBoundingBoxLocation()
        {
            Point destination = new Point(25, 75);
            Point position = new Point(50, 50);
            Leopard leopard = new Leopard(new Point(50, 50));

            leopard.MoveTo(destination);

            Assert.IsTrue(leopard.Position.X >= position.X - leopard.Speed && leopard.Position.X < position.X);
            Assert.IsTrue(leopard.Position.Y <= position.Y + leopard.Speed && leopard.Position.Y > position.Y);
            Assert.AreEqual(leopard.Position.X, leopard.BoundingBox.Location.X);
            Assert.AreEqual(leopard.Position.Y, leopard.BoundingBox.Location.Y);
        }

        [TestMethod()]
        public void Attack_GazelleEntity_SetsEntityHealthMinusAttackDamageAndReturnsFalse()
        {
            Leopard leopard = new Leopard(new Point(50, 50));
            Gazelle gazelle = new Gazelle(new Point(50, 50));

            bool result = leopard.Attack(gazelle);

            Assert.AreEqual(gazelle.MaxHealth - leopard.AttackDamage, gazelle.Health);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void Attack_GazelleEntity_ReturnsTrueWhenEntityIsDead()
        {
            Leopard leopard = new Leopard(new Point(50, 50));
            Gazelle gazelle = new Gazelle(new Point(50, 50));

            bool result = false;

            while (gazelle.Health > 0)
            {
                result = leopard.Attack(gazelle);
            }

            Assert.AreEqual(0, gazelle.Health);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Attack_NullEntity_ThrowArgumentNull()
        {
            Leopard leopard = new Leopard(new Point(50, 50));

            leopard.Attack(null);
        }

        [TestMethod()]
        public void Eat_PreferredFoodEntity_UpsHealthWithQuarterOfEntityMacHealth()
        {
            Leopard leopard = new Leopard(new Point(50, 50));
            Gazelle gazelle = new Gazelle(new Point(50, 50));
            leopard.Health = 20;
            gazelle.Health = 0;

            leopard.Eat(gazelle);

            Assert.AreEqual(35, leopard.Health);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Eat_NullEntity_ThrowArgumentNull()
        {
            Leopard leopard = new Leopard(new Point(50, 50));

            leopard.Eat(null);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Eat_EntityThatIsNotPreferredFood_ThrowArgumentOutOfRange()
        {
            Leopard leopard = new Leopard(new Point(50, 50));
            Grass grass = new Grass(new Point(55, 55));

            leopard.Eat(grass);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Eat_EntityThatIsPreferredFoodButNotDead_ThrowArgumentOutOfRange()
        {
            Leopard leopard = new Leopard(new Point(50, 50));
            Gazelle gazelle = new Gazelle(new Point(50, 50));

            leopard.Eat(gazelle);
        }

        [TestMethod()]
        public void ToString_LeopardProperties_SetsAllPropertiesInString()
        {
            Leopard leopard = new Leopard(new Point(1, 3));

            Assert.AreEqual("Type: leopard, position: 1x, 3y, bounding box: 11w, 11h, health: 80, speed: 3px/frame, view range: 95px, preferred food: gazelle, enemy: hippopotamus", leopard.ToString());
        }
    }
}