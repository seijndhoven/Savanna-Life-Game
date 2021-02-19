using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SavannaLifeGame.Data;
using SavannaLifeGame.Source;

namespace SavannaLifeGameTests.Tests
{
    [TestClass()]
    public class GrassTests
    {
        [TestMethod()]
        public void WhenGrassIsCreated_ThenGrassHasTypePositionBoundingBoxMaxHealthAndHealth()
        {
            Point position = new Point(1, 2);
            Grass grass = new Grass(position);

            Assert.AreEqual(EntityTypes.Grass, grass.Type);
            Assert.AreEqual(position, grass.Position);
            Assert.AreEqual(position.X, grass.Position.X);
            Assert.AreEqual(position.Y, grass.Position.Y);
            Assert.AreEqual(position, grass.BoundingBox.Location);
            Assert.AreEqual(8, grass.BoundingBox.Width);
            Assert.AreEqual(8, grass.BoundingBox.Height);
            Assert.AreEqual(50, grass.MaxHealth);
            Assert.AreEqual(50, grass.Health);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WhenGrassIsCreatedWithNegativeXPosition_ThenThrowArgumentNull()
        {
            Grass grass = new Grass(new Point(-1, 0));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WhenGrassIsCreatedWithNegativeYPosition_ThenThrowArgumentNull()
        {
            Grass grass = new Grass(new Point(0, -1));
        }

        [TestMethod()]
        public void WhenGrassHealthIsSetNegative_ThenGrassHealthIsZero()
        {
            Grass grass = new Grass(new Point(34, 87));
            grass.Health = -1;

            Assert.AreEqual(0, grass.Health);
        }

        [TestMethod()]
        public void WhenGrassHealthIsSetHigherThanMaxHealth_ThenGrassHealthIsMaxHealth()
        {
            Grass grass = new Grass(new Point(34, 87));
            grass.Health = 51;

            Assert.AreEqual(grass.MaxHealth, grass.Health);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DrawTo_CanvasNull_ThrowArgumentNull()
        {
            Grass grass = new Grass(new Point(1, 1));

            grass.DrawTo(null);
        }

        [TestMethod()]
        public void ToString_GrassProperties_SetsAllPropertiesInString()
        {
            Grass grass = new Grass(new Point(1, 3));

            Assert.AreEqual("Type: grass, position: 1x, 3y, bounding box: 8w, 8h, health: 50", grass.ToString());
        }
    }
}