using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SavannaLifeGame.Data;
using SavannaLifeGame.Source;

namespace SavannaLifeGameTests.Tests
{
    [TestClass()]
    public class GazelleTests
    {
        [TestMethod()]
        public void WhenGazelleIsCreated_ThenGazelleHasTypePositionBoundingBoxMaxHealthHealthSpeedAttackDamageViewRangePreferredFoodAndPredator()
        {
            Point position = new Point(2, 2);
            Gazelle gazelle = new Gazelle(position);

            Assert.AreEqual(EntityTypes.Gazelle, gazelle.Type);
            Assert.AreEqual(position, gazelle.Position);
            Assert.AreEqual(position.X, gazelle.Position.X);
            Assert.AreEqual(position.Y, gazelle.Position.Y);
            Assert.AreEqual(position, gazelle.BoundingBox.Location);
            Assert.AreEqual(10, gazelle.BoundingBox.Width);
            Assert.AreEqual(10, gazelle.BoundingBox.Height);
            Assert.AreEqual(60, gazelle.MaxHealth);
            Assert.AreEqual(60, gazelle.Health);
            Assert.AreEqual(2, gazelle.Speed);
            Assert.AreEqual(3, gazelle.AttackDamage);
            Assert.AreEqual(100, gazelle.ViewRange);
            Assert.AreEqual(EntityTypes.Grass, gazelle.PreferredFood);
            Assert.AreEqual(EntityTypes.Leopard, gazelle.Predator);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WhenGazelleIsCreatedWithNegativeXPosition_ThenThrowArgumentNull()
        {
            Gazelle gazelle = new Gazelle(new Point(-1, 0));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WhenGazelleIsCreatedWithNegativeYPosition_ThenThrowArgumentNull()
        {
            Gazelle gazelle = new Gazelle(new Point(0, -1));
        }

        [TestMethod()]
        public void WhenGazelleHealthIsSetNegative_ThenGazelleHealthIsZero()
        {
            Gazelle gazelle = new Gazelle(new Point(34, 87));
            gazelle.Health = -1;

            Assert.AreEqual(0, gazelle.Health);
        }

        [TestMethod()]
        public void WhenGazelleHealthIsSetHigherThanMaxHealth_ThenGazelleHealthIsMaxHealth()
        {
            Gazelle gazelle = new Gazelle(new Point(34, 87));
            gazelle.Health = 61;

            Assert.AreEqual(gazelle.MaxHealth, gazelle.Health);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DrawTo_CanvasNull_ThrowArgumentNull()
        {
            Gazelle gazelle = new Gazelle(new Point(1, 1));

            gazelle.DrawTo(null);
        }

        [TestMethod()]
        public void Find_NoOtherEntitiesInListPredator_ReturnsNull()
        {
            Gazelle gazelle = new Gazelle(new Point(2, 1));
            List<Entity> entities = new List<Entity>();

            entities.Add(gazelle);

            Entity result = gazelle.Find(entities, gazelle.Predator);

            Assert.AreEqual(null, result);
        }

        [TestMethod()]
        public void Find_NoOtherEntitiesInListPreferredFood_ReturnsNull()
        {
            Gazelle gazelle = new Gazelle(new Point(2, 1));
            List<Entity> entities = new List<Entity>();

            entities.Add(gazelle);

            Entity result = gazelle.Find(entities, gazelle.PreferredFood);

            Assert.AreEqual(null, result);
        }

        [TestMethod()]
        public void Find_PredatorInEntitiesListOutsideViewRange_ReturnsNull()
        {
            Gazelle gazelle = new Gazelle(new Point(2, 1));
            Leopard leopard = new Leopard(new Point(102, 1));
            List<Entity> entities = new List<Entity>();

            entities.Add(gazelle);
            entities.Add(leopard);

            Entity result = gazelle.Find(entities, gazelle.Predator);

            Assert.AreEqual(null, result);
        }

        [TestMethod()]
        public void Find_PreferredFoodInEntitiesListOutsideViewRange_ReturnsNull()
        {
            Gazelle gazelle = new Gazelle(new Point(2, 1));
            Grass grass = new Grass(new Point(2, 101));
            List<Entity> entities = new List<Entity>();

            entities.Add(gazelle);
            entities.Add(grass);

            Entity result = gazelle.Find(entities, gazelle.PreferredFood);

            Assert.AreEqual(null, result);
        }

        [TestMethod()]
        public void Find_PredatorInEntitiesListInsideViewRange_ReturnsPredator()
        {
            Gazelle gazelle = new Gazelle(new Point(2, 1));
            Leopard leopard = new Leopard(new Point(101, 1));
            List<Entity> entities = new List<Entity>();

            entities.Add(gazelle);
            entities.Add(leopard);

            Entity result = gazelle.Find(entities, gazelle.Predator);

            Assert.AreEqual(leopard, result);
        }

        [TestMethod()]
        public void Find_PreferredFoodInEntitiesListInsideViewRange_ReturnsPreferredFood()
        {
            Gazelle gazelle = new Gazelle(new Point(2, 1));
            Grass grass = new Grass(new Point(2, 100));
            List<Entity> entities = new List<Entity>();

            entities.Add(gazelle);
            entities.Add(grass);

            Entity result = gazelle.Find(entities, gazelle.PreferredFood);

            Assert.AreEqual(grass, result);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Find_EntitiesNull_ThrowArgumentNull()
        {
            Gazelle gazelle = new Gazelle(new Point(2, 1));

            gazelle.Find(null, gazelle.PreferredFood);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Find_EntitiesEmpty_ThrowArgumentNull()
        {
            Gazelle gazelle = new Gazelle(new Point(2, 1));
            List<Entity> entities = new List<Entity>();

            gazelle.Find(entities, gazelle.PreferredFood);
        }

        [TestMethod()]
        public void Move_SpeedAsRange_SetsNewPositionBetweenRangeAndUpdatesBoundingBoxLocation()
        {
            Point position = new Point(50, 50);
            Gazelle gazelle = new Gazelle(position);

            gazelle.Move();

            Assert.IsTrue(gazelle.Position.X >= position.X - gazelle.Speed && gazelle.Position.X <= position.X + gazelle.Speed);
            Assert.IsTrue(gazelle.Position.Y >= position.Y - gazelle.Speed && gazelle.Position.Y <= position.Y + gazelle.Speed);
            Assert.AreEqual(gazelle.Position.X, gazelle.BoundingBox.Location.X);
            Assert.AreEqual(gazelle.Position.Y, gazelle.BoundingBox.Location.Y);
        }

        [TestMethod()]
        public void MoveTo_DestinationUpperInLeftCornerQuadrant_SetsNewPositionInQuadrantBetweenRangeAndUpdatesBoundingBoxLocation()
        {
            Point destination = new Point(25, 25);
            Point position = new Point(50, 50);
            Gazelle gazelle = new Gazelle(new Point(50, 50));

            gazelle.MoveTo(destination);

            Assert.IsTrue(gazelle.Position.X >= position.X - gazelle.Speed && gazelle.Position.X < position.X);
            Assert.IsTrue(gazelle.Position.Y >= position.Y - gazelle.Speed && gazelle.Position.Y < position.Y);
            Assert.AreEqual(gazelle.Position.X, gazelle.BoundingBox.Location.X);
            Assert.AreEqual(gazelle.Position.Y, gazelle.BoundingBox.Location.Y);
        }        
        
        [TestMethod()]
        public void MoveTo_DestinationInUpperRightCornerQuadrant_SetsNewPositionInQuadrantBetweenRangeAndUpdatesBoundingBoxLocation()
        {
            Point destination = new Point(75, 25);
            Point position = new Point(50, 50);
            Gazelle gazelle = new Gazelle(new Point(50, 50));

            gazelle.MoveTo(destination);

            Assert.IsTrue(gazelle.Position.X <= position.X + gazelle.Speed && gazelle.Position.X > position.X);
            Assert.IsTrue(gazelle.Position.Y >= position.Y - gazelle.Speed && gazelle.Position.Y < position.Y);
            Assert.AreEqual(gazelle.Position.X, gazelle.BoundingBox.Location.X);
            Assert.AreEqual(gazelle.Position.Y, gazelle.BoundingBox.Location.Y);
        }

        [TestMethod()]
        public void MoveTo_DestinationInLowerRightCornerQuadrant_SetsNewPositionInQuadrantBetweenRangeAndUpdatesBoundingBoxLocation()
        {
            Point destination = new Point(75, 75);
            Point position = new Point(50, 50);
            Gazelle gazelle = new Gazelle(new Point(50, 50));

            gazelle.MoveTo(destination);

            Assert.IsTrue(gazelle.Position.X <= position.X + gazelle.Speed && gazelle.Position.X > position.X);
            Assert.IsTrue(gazelle.Position.Y <= position.Y + gazelle.Speed && gazelle.Position.Y > position.Y);
            Assert.AreEqual(gazelle.Position.X, gazelle.BoundingBox.Location.X);
            Assert.AreEqual(gazelle.Position.Y, gazelle.BoundingBox.Location.Y);
        }

        [TestMethod()]
        public void MoveTo_DestinationInLowerLeftCornerQuadrant_SetsNewPositionInQuadrantBetweenRangeAndUpdatesBoundingBoxLocation()
        {
            Point destination = new Point(25, 75);
            Point position = new Point(50, 50);
            Gazelle gazelle = new Gazelle(new Point(50, 50));

            gazelle.MoveTo(destination);

            Assert.IsTrue(gazelle.Position.X >= position.X - gazelle.Speed && gazelle.Position.X < position.X);
            Assert.IsTrue(gazelle.Position.Y <= position.Y + gazelle.Speed && gazelle.Position.Y > position.Y);
            Assert.AreEqual(gazelle.Position.X, gazelle.BoundingBox.Location.X);
            Assert.AreEqual(gazelle.Position.Y, gazelle.BoundingBox.Location.Y);
        }

        [TestMethod()]
        public void Attack_GrassEntity_SetsEntityHealthMinusAttackDamageAndReturnsFalse()
        {
            Gazelle gazelle = new Gazelle(new Point(50, 50));
            Grass grass = new Grass(new Point(50, 50));

            bool result = gazelle.Attack(grass);

            Assert.AreEqual(grass.MaxHealth - gazelle.AttackDamage, grass.Health);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void Attack_GrassEntity_ReturnsTrueWhenEntityIsDead()
        {
            Gazelle gazelle = new Gazelle(new Point(50, 50));
            Grass grass = new Grass(new Point(50, 50));

            bool result = false; 

            while (grass.Health > 0)
            {
                result = gazelle.Attack(grass);
            }

            Assert.AreEqual(0, grass.Health);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Attack_NullEntity_ThrowArgumentNull()
        {
            Gazelle gazelle = new Gazelle(new Point(50, 50));

            gazelle.Attack(null);
        }

        [TestMethod()]
        public void Eat_PreferredFoodEntity_UpsHealthWithQuarterOfEntityMacHealth()
        {
            Gazelle gazelle = new Gazelle(new Point(50, 50));
            Grass grass = new Grass(new Point(55, 55));
            gazelle.Health = 20;
            grass.Health = 0;

            gazelle.Eat(grass);

            Assert.AreEqual(32, gazelle.Health);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Eat_NullEntity_ThrowArgumentNull()
        {
            Gazelle gazelle = new Gazelle(new Point(50, 50));

            gazelle.Eat(null);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Eat_EntityThatIsNotPreferredFood_ThrowArgumentOutOfRange()
        {
            Gazelle gazelle = new Gazelle(new Point(50, 50));
            Leopard leopard = new Leopard(new Point(55, 55));

            gazelle.Eat(leopard);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Eat_EntityThatIsPreferredFoodButNotDead_ThrowArgumentOutOfRange()
        {
            Gazelle gazelle = new Gazelle(new Point(50, 50));
            Grass grass = new Grass(new Point(55, 55));

            gazelle.Eat(grass);
        }

        [TestMethod()]
        public void ToString_GazelleProperties_SetsAllPropertiesInString()
        {
            Gazelle gazelle = new Gazelle(new Point(1, 3));

            Assert.AreEqual("Type: gazelle, position: 1x, 3y, bounding box: 10w, 10h, health: 60, speed: 2px/frame, view range: 100px, preferred food: grass, predator: leopard", gazelle.ToString());
        }
    }
}