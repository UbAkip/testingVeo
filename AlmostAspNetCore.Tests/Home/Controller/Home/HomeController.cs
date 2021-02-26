using AlmostAspNetCore.Tests.Home.Controller.Classes;
using AlmostNetCore.Data.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmostAspNetCore.Tests.Home.Controller
{
    [TestFixture]
    class HomeController
    {
        [Test]
        public void GetMatrixReturnTrue()
        {
            var iMatrixService = new Mock<IMatrixService>();

            var matrix = iMatrixService.Object.GenerateRandomMatrix(4);

            Assert.IsTrue(matrix != null);
        }
        public void TransformMatrixEqualWithOriginReturnTrue()
        {
            var iMatrixService = new MatrixServiceTest();

            var matrix = iMatrixService.GenerateRandomMatrix(4);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Assert.IsTrue(matrix[i][j] == MatrixServiceTest.ExpectedMatrix[i][j]);
                }
            }

        }

    }
}
