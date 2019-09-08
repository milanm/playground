using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentLineup;

namespace StudentLineUpTest
{
    [TestClass]
    public class StudentLineUpTest
    {
        [TestMethod]
        public void WhenGivenZeroStudentsWithHeightsShouldReturnZeroRowsCreated()
        {
            // Arrange
            int[] studentHeights = { };

            // Act
            var rowsCreated = StudentLineUp.LineUp(studentHeights);

            // Assert
            Assert.AreEqual(0, rowsCreated);
        }

        [TestMethod]
        public void WhenGivenOneStudentsWithHeightsShouldReturnOneRowCreated()
        {
            // Arrange
            int[] studentHeights = { 1 };

            // Act
            var rowsCreated = StudentLineUp.LineUp(studentHeights);

            // Assert
            Assert.AreEqual(1, rowsCreated);
        }

        [TestMethod]
        public void WhenGiven3StudentsWithHeightsShouldReturnMinimumRowsCreated()
        {
            // Arrange
            int[] studentHeights = { 9, 5, 2 };

            // Act
            var rowsCreated = StudentLineUp.LineUp(studentHeights);

            // Assert
            Assert.AreEqual(1, rowsCreated);
        }

        [TestMethod]
        public void WhenGiven3StudentsWithDifferentHeightsShouldReturnMinimumRowsCreated()
        {
            // Arrange
            int[] studentHeights = { 9, 5, 10 };

            // Act
            var rowsCreated = StudentLineUp.LineUp(studentHeights);

            // Assert
            Assert.AreEqual(2, rowsCreated);
        }

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
        public void WhenGiven5StudentsWithDifferentHeightsShouldReturnMinimumRowsCreated()
        {
            // Arrange
            int[] studentHeights = { 9, 2, 7, 1, 6 };

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
