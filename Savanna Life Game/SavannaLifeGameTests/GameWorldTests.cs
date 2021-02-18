using Microsoft.VisualStudio.TestTools.UnitTesting;
using SavannaLifeGame;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavannaLifeGameTests
{
    [TestClass()]
    public class GameWorldTests
    {
        [TestMethod()]
        public void WhenGameWorldIsCreated_ThenAdministrationHasAnEmptyEntitiesList()
        {
            GameWorld gameWorld = new GameWorld();

            Assert.AreEqual(0, gameWorld.Entities.Count);
        }

        [TestMethod()]
        public void Add_NewEntityAsGrass_AddsGrassToEntitiesList()
        {
            GameWorld gameWorld = new GameWorld();
            Grass grass = new Grass(new Point(20, 82));

            gameWorld.Add(grass);

            Assert.AreEqual(1, gameWorld.Entities.Count);
            Assert.IsTrue(gameWorld.Entities.Contains(grass));
        }

        [TestMethod()]
        public void Add_NewEntityAsGazelle_AddsGazelleToEntitiesList()
        {
            GameWorld gameWorld = new GameWorld();
            Gazelle gazelle = new Gazelle(new Point(90, 82));

            gameWorld.Add(gazelle);

            Assert.AreEqual(1, gameWorld.Entities.Count);
            Assert.IsTrue(gameWorld.Entities.Contains(gazelle));
        }

        [TestMethod()]
        public void Add_NewEntityAsLeopard_AddsLeopardToEntitiesList()
        {
            GameWorld gameWorld = new GameWorld();
            Leopard leopard = new Leopard(new Point(53, 26));

            gameWorld.Add(leopard);

            Assert.AreEqual(1, gameWorld.Entities.Count);
            Assert.IsTrue(gameWorld.Entities.Contains(leopard));
        }

        [TestMethod()]
        public void Add_NewEntityAsHippopotamus_AddsHippopotamusToEntitiesList()
        {
            GameWorld gameWorld = new GameWorld();
            Hippopotamus hippopotamus = new Hippopotamus(new Point(20, 82));

            gameWorld.Add(hippopotamus);

            Assert.AreEqual(1, gameWorld.Entities.Count);
            Assert.IsTrue(gameWorld.Entities.Contains(hippopotamus));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_EntityNull_ThrowArgumentNull()
        {
            GameWorld gameWorld = new GameWorld();

            gameWorld.Add(null);
        }

        [TestMethod()]
        public void Remove_NewEntityAsGrass_AddsGrassToEntitiesList()
        {
            GameWorld gameWorld = new GameWorld();
            Grass grass = new Grass(new Point(20, 82));

            gameWorld.Add(grass);
            gameWorld.Remove(grass);

            Assert.AreEqual(0, gameWorld.Entities.Count);
            Assert.IsFalse(gameWorld.Entities.Contains(grass));
        }

        [TestMethod()]
        public void Remove_NewEntityAsGazelle_AddsGazelleToEntitiesList()
        {
            GameWorld gameWorld = new GameWorld();
            Gazelle gazelle = new Gazelle(new Point(90, 82));

            gameWorld.Add(gazelle);
            gameWorld.Remove(gazelle);

            Assert.AreEqual(0, gameWorld.Entities.Count);
            Assert.IsFalse(gameWorld.Entities.Contains(gazelle));
        }

        [TestMethod()]
        public void Remove_NewEntityAsLeopard_AddsLeopardToEntitiesList()
        {
            GameWorld gameWorld = new GameWorld();
            Leopard leopard = new Leopard(new Point(53, 26));

            gameWorld.Add(leopard);
            gameWorld.Remove(leopard);

            Assert.AreEqual(0, gameWorld.Entities.Count);
            Assert.IsFalse(gameWorld.Entities.Contains(leopard));
        }

        [TestMethod()]
        public void Remove_NewEntityAsHippopotamus_AddsHippopotamusToEntitiesList()
        {
            GameWorld gameWorld = new GameWorld();
            Hippopotamus hippopotamus = new Hippopotamus(new Point(20, 82));

            gameWorld.Add(hippopotamus);
            gameWorld.Remove(hippopotamus);

            Assert.AreEqual(0, gameWorld.Entities.Count);
            Assert.IsFalse(gameWorld.Entities.Contains(hippopotamus));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Remove_EntityNull_ThrowArgumentNull()
        {
            GameWorld gameWorld = new GameWorld();

            gameWorld.Remove(null);
        }

        [TestMethod()]
        public void Find_PointThatDoesNotIntersectWithEntity_ReturnsNull()
        {
            GameWorld gameWorld = new GameWorld();
            Hippopotamus hippopotamus = new Hippopotamus(new Point(20, 82));

            gameWorld.Add(hippopotamus);

            Entity entity = gameWorld.Find(new Point(19, 81));

            Assert.IsNull(entity);
        }

        [TestMethod()]
        public void Find_PointThatDoesIntersectWithEntity_ReturnsEntity()
        {
            GameWorld gameWorld = new GameWorld();
            Hippopotamus hippopotamus = new Hippopotamus(new Point(20, 82));

            gameWorld.Add(hippopotamus);

            Entity entity = gameWorld.Find(new Point(21, 83));

            Assert.AreEqual(hippopotamus, entity);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Find_NegativePointX_ThrowArgumentOutOfRange()
        {
            GameWorld gameWorld = new GameWorld();

            gameWorld.Find(new Point(-1, 0));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Find_NegativePointY_ThrowArgumentOutOfRange()
        {
            GameWorld gameWorld = new GameWorld();

            gameWorld.Find(new Point(0, -1));
        }

        [TestMethod()]
        public void RunOneTurn_DeadEntity_RemovesEntityFromEntitiesList()
        {
            GameWorld gameWorld = new GameWorld();
            Grass grass = new Grass(new Point(20, 82));

            grass.Health = 0;
            gameWorld.Add(grass);
            gameWorld.RunOneTurn();

            Assert.AreEqual(0, gameWorld.Entities.Count);
            Assert.IsFalse(gameWorld.Entities.Contains(grass));
        }

        [TestMethod()]
        public void RunOneTurn_NoDestinationEntity_AnimalAsGazelleDoesRandomMoveAndSetsNewPositionBetweenRange()
        {
            GameWorld gameWorld = new GameWorld();
            Point position = new Point(20, 82);
            Gazelle gazelle = new Gazelle(position);

            gameWorld.Add(gazelle);
            gameWorld.RunOneTurn();

            Assert.IsTrue(gazelle.Position.X >= position.X - gazelle.Speed && gazelle.Position.X <= position.X + gazelle.Speed);
            Assert.IsTrue(gazelle.Position.Y >= position.Y - gazelle.Speed && gazelle.Position.Y <= position.Y + gazelle.Speed);
        }

        [TestMethod()]
        public void RunOneTurn_NoDestinationEntity_AnimalAsLeopardDoesRandomMoveAndSetsNewPositionBetweenRange()
        {
            GameWorld gameWorld = new GameWorld();
            Point position = new Point(53, 90);
            Leopard leopard = new Leopard(position);

            gameWorld.Add(leopard);
            gameWorld.RunOneTurn();

            Assert.IsTrue(leopard.Position.X >= position.X - leopard.Speed && leopard.Position.X <= position.X + leopard.Speed);
            Assert.IsTrue(leopard.Position.Y >= position.Y - leopard.Speed && leopard.Position.Y <= position.Y + leopard.Speed);
        }

        [TestMethod()]
        public void RunOneTurn_NoDestinationEntity_AnimalAsHippopotamusDoesRandomMoveAndSetsNewPositionBetweenRange()
        {
            GameWorld gameWorld = new GameWorld();
            Point position = new Point(66, 99);
            Hippopotamus hippopotamus = new Hippopotamus(position);

            gameWorld.Add(hippopotamus);
            gameWorld.RunOneTurn();

            Assert.IsTrue(hippopotamus.Position.X >= position.X - hippopotamus.Speed && hippopotamus.Position.X <= position.X + hippopotamus.Speed);
            Assert.IsTrue(hippopotamus.Position.Y >= position.Y - hippopotamus.Speed && hippopotamus.Position.Y <= position.Y + hippopotamus.Speed);
        }

        [TestMethod()]
        public void RunOneTurn_DestinationEntityPreferredFoodOfGazelle_AnimalAsGazelleSetsNewPositionInDestinationQuadrantBetweenSpeedAsRange()
        {
            GameWorld gameWorld = new GameWorld();
            Point position = new Point(50, 50);
            Gazelle gazelle = new Gazelle(position);
            Grass grass = new Grass(new Point(25, 25));

            gameWorld.Add(gazelle);
            gameWorld.Add(grass);
            gameWorld.RunOneTurn();

            Assert.IsTrue(gazelle.Position.X >= position.X - gazelle.Speed && gazelle.Position.X < position.X);
            Assert.IsTrue(gazelle.Position.Y >= position.Y - gazelle.Speed && gazelle.Position.Y < position.Y);
        }

        [TestMethod()]
        public void RunOneTurn_DestinationEntityPreferredFoodOfLeopard_AnimalAsLeopardSetsNewPositionInDestinationQuadrantBetweenSpeedAsRange()
        {
            GameWorld gameWorld = new GameWorld();
            Point position = new Point(50, 50);
            Leopard leopard = new Leopard(position);
            Gazelle gazelle = new Gazelle(new Point(75, 25));

            gameWorld.Add(leopard);
            gameWorld.Add(gazelle);
            gameWorld.RunOneTurn();

            Assert.IsTrue(leopard.Position.X <= position.X + leopard.Speed && leopard.Position.X > position.X);
            Assert.IsTrue(leopard.Position.Y >= position.Y - leopard.Speed && leopard.Position.Y < position.Y);
        }

        [TestMethod()]
        public void RunOneTurn_DestinationEntityPreferredFoodOfHippopotamus_AnimalAsHippopotamusSetsNewPositionInDestinationQuadrantBetweenSpeedAsRange()
        {
            GameWorld gameWorld = new GameWorld();
            Point position = new Point(50, 50);
            Hippopotamus hippopotamus = new Hippopotamus(position);
            Grass grass = new Grass(new Point(75, 75));

            gameWorld.Add(hippopotamus);
            gameWorld.Add(grass);
            gameWorld.RunOneTurn();

            Assert.IsTrue(hippopotamus.Position.X <= position.X + hippopotamus.Speed && hippopotamus.Position.X > position.X);
            Assert.IsTrue(hippopotamus.Position.Y <= position.Y + hippopotamus.Speed && hippopotamus.Position.Y > position.Y);
        }

        [TestMethod()]
        public void RunOneTurn_DestinationEntityPredatorOfGazelle_AnimalAsGazelleSetsNewPositionMirroredToDestinationQuadrantBetweenSpeedAsRange()
        {
            GameWorld gameWorld = new GameWorld();
            Point position = new Point(50, 50);
            Gazelle gazelle = new Gazelle(position);
            Leopard leopard = new Leopard(new Point(25, 25));

            gameWorld.Add(gazelle);
            gameWorld.Add(leopard);
            gameWorld.RunOneTurn();

            Assert.IsTrue(gazelle.Position.X <= position.X + gazelle.Speed && gazelle.Position.X > position.X);
            Assert.IsTrue(gazelle.Position.Y <= position.Y + gazelle.Speed && gazelle.Position.Y > position.Y);
        }

        [TestMethod()]
        public void RunOneTurn_DestinationEntityFearOfLeopard_AnimalAsLeopardDoesNotChangeLocationBecauseItIsScaredOfHippopotamus()
        {
            GameWorld gameWorld = new GameWorld();
            Point position = new Point(50, 50);
            Leopard leopard = new Leopard(position);
            Hippopotamus hippopotamus = new Hippopotamus(new Point(75, 25));

            gameWorld.Add(leopard);
            gameWorld.Add(hippopotamus);
            gameWorld.RunOneTurn();

            Assert.AreEqual(position, leopard.Position);
            Assert.AreEqual(leopard.Position.X, leopard.BoundingBox.Location.X);
            Assert.AreEqual(leopard.Position.Y, leopard.BoundingBox.Location.Y);
        }

        [TestMethod()]
        public void RunOneTurn_DestinationEntityEnemyOfHippopotamus_AnimalAsHippopotamusSetsNewPositionInDestinationQuadrantBetweenSpeedAsRange()
        {
            GameWorld gameWorld = new GameWorld();
            Point position = new Point(50, 50);
            Hippopotamus hippopotamus = new Hippopotamus(position);
            Leopard leopard = new Leopard(new Point(75, 75));

            gameWorld.Add(hippopotamus);
            gameWorld.Add(leopard);
            gameWorld.RunOneTurn();

            Assert.IsTrue(hippopotamus.Position.X <= position.X + hippopotamus.Speed && hippopotamus.Position.X > position.X);
            Assert.IsTrue(hippopotamus.Position.Y <= position.Y + hippopotamus.Speed && hippopotamus.Position.Y > position.Y);
        }

        [TestMethod()]
        public void RunOneTurn_GazelleIntersectsWithPreferredFood_AnimalAsGazelleAttacksEntityAndEntityItsHealthIsLoweredWithAttackDamage()
        {
            GameWorld gameWorld = new GameWorld();
            Point position = new Point(50, 50);
            Gazelle gazelle = new Gazelle(position);
            Grass grass = new Grass(position);

            gameWorld.Add(gazelle);
            gameWorld.Add(grass);
            gameWorld.RunOneTurn();

            Assert.AreEqual(grass.MaxHealth - gazelle.AttackDamage, grass.Health);
        }

        [TestMethod()]
        public void RunOneTurn_LeopardIntersectsWithPreferredFood_AnimalAsLeopardAttacksEntityAndEntityItsHealthIsLoweredWithAttackDamage()
        {
            GameWorld gameWorld = new GameWorld();
            Point position = new Point(50, 50);
            Leopard leopard = new Leopard(position);
            Gazelle gazelle = new Gazelle(position);

            gameWorld.Add(leopard);
            gameWorld.Add(gazelle);
            gameWorld.RunOneTurn();

            Assert.AreEqual(gazelle.MaxHealth - leopard.AttackDamage, gazelle.Health);
        }

        [TestMethod()]
        public void RunOneTurn_HippopotamusIntersectsWithPreferredFood_AnimalAsHippopotamusAttacksEntityAndEntityItsHealthIsLoweredWithAttackDamage()
        {
            GameWorld gameWorld = new GameWorld();
            Point position = new Point(50, 50);
            Hippopotamus hippopotamus = new Hippopotamus(position);
            Grass grass = new Grass(position);

            gameWorld.Add(hippopotamus);
            gameWorld.Add(grass);
            gameWorld.RunOneTurn();

            Assert.AreEqual(grass.MaxHealth - hippopotamus.AttackDamage, grass.Health);
        }


        [TestMethod()]
        public void RunOneTurn_GazelleIntersectsWithPreferredFoodAndPreferredFoodIsDead_AnimalAsGazelleEatsEntityAndEntityIsRemovedFromEntitiesList()
        {
            GameWorld gameWorld = new GameWorld();
            Point position = new Point(50, 50);
            Gazelle gazelle = new Gazelle(position);
            Grass grass = new Grass(position);

            grass.Health = 0;

            gameWorld.Add(gazelle);
            gameWorld.Add(grass);
            gameWorld.RunOneTurn();

            Assert.IsFalse(gameWorld.Entities.Contains(grass));
        }

        [TestMethod()]
        public void RunOneTurn_LeopardIntersectsWithPreferredFoodAndPreferredFoodIsDead_AnimalAsLeopardEatsEntityAndEntityIsRemovedFromEntitiesList()
        {
            GameWorld gameWorld = new GameWorld();
            Point position = new Point(50, 50);
            Leopard leopard = new Leopard(position);
            Gazelle gazelle = new Gazelle(position);

            gazelle.Health = 0;

            gameWorld.Add(leopard);
            gameWorld.Add(gazelle);
            gameWorld.RunOneTurn();

            Assert.IsFalse(gameWorld.Entities.Contains(gazelle));
        }

        [TestMethod()]
        public void RunOneTurn_HippoIntersectsWithPreferredFoodAndPreferredFoodIsDead_AnimalAsHippoEatsEntityAndEntityIsRemovedFromEntitiesList()
        {
            GameWorld gameWorld = new GameWorld();
            Point position = new Point(50, 50);
            Hippopotamus hippopotamus = new Hippopotamus(position);
            Grass grass = new Grass(position);

            grass.Health = 0;

            gameWorld.Add(hippopotamus);
            gameWorld.Add(grass);
            gameWorld.RunOneTurn();

            Assert.IsFalse(gameWorld.Entities.Contains(grass));
        }

        [TestMethod()]
        public void RunOneTurn_LeopardIntersectsWithFear_AnimalAsLeopardAttacksEntityAndEntityItsHealthIsLoweredWithAttackDamage()
        {
            GameWorld gameWorld = new GameWorld();
            Point position = new Point(50, 50);
            Leopard leopard = new Leopard(position);
            Hippopotamus hippopotamus = new Hippopotamus(position);

            gameWorld.Add(leopard);
            gameWorld.Add(hippopotamus);
            gameWorld.RunOneTurn();

            Assert.AreEqual(hippopotamus.MaxHealth - leopard.AttackDamage, hippopotamus.Health);
        }

        [TestMethod()]
        public void RunOneTurn_HippopotamusIntersectsWithEnemy_AnimalAsHippopotamusAttacksEntityAndEntityItsHealthIsLoweredWithAttackDamage()
        {
            GameWorld gameWorld = new GameWorld();
            Point position = new Point(50, 50);
            Hippopotamus hippopotamus = new Hippopotamus(position);
            Leopard leopard = new Leopard(position);

            gameWorld.Add(hippopotamus);
            gameWorld.Add(leopard);
            gameWorld.RunOneTurn();

            Assert.AreEqual(leopard.MaxHealth - hippopotamus.AttackDamage, leopard.Health);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Save_NullFileName_TrowArgumentNull()
        {
            GameWorld gameWorld = new GameWorld();
            gameWorld.Save(null);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Save_EmptyString_TrowArgumentOutOfRange()
        {
            GameWorld gameWorld = new GameWorld();
            gameWorld.Save("");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Save_WhiteSpace_TrowArgumentOutOfRange()
        {
            GameWorld gameWorld = new GameWorld();
            gameWorld.Save(" ");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Load_NullFileName_TrowArgumentNull()
        {
            GameWorld gameWorld = new GameWorld();
            gameWorld.Load(null);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Load_EmptyString_TrowArgumentOutOfRange()
        {
            GameWorld gameWorld = new GameWorld();
            gameWorld.Load("");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Load_WhiteSpace_TrowArgumentOutOfRange()
        {
            GameWorld gameWorld = new GameWorld();
            gameWorld.Load(" ");
        }
    }
}