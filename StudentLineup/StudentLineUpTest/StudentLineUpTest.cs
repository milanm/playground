using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentLineup;

namespace StudentLineUpTest
{
    [TestClass]
    public class StudentLineUpTest
    {
        [TestMethod]
        public void WhenGiven5StudentsWithHeightsShouldReturnMinimumRowsCreated()
        {
            // Arrange
            int[] studentHeights = { 5, 4, 3, 6, 1 };

            // Act
            var rowsCreated = StudentLineUp.LineUp(studentHeights);

            // Assert
            Assert.AreEqual(2, rowsCreated);
        }

        [TestMethod]
        public void WhenGiven7StudentsWithHeightsShouldReturnMinimumRowsCreated()
        {
            // Arrange
            int[] studentHeights = {5, 4, 3, 6, 1, 2, 7};

            // Act
            var rowsCreated = StudentLineUp.LineUp(studentHeights);

            // Assert
            Assert.AreEqual(3, rowsCreated);
        }
    }
}
