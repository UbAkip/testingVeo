using AlmostNetCore.Data.Interfaces;
using AlmostNetCore.Services.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AlmostAspNetCore.Tests.Home.Controller
{
    [TestFixture]
    public class FileController 
    {
        [Test]
        public void CreateControllerReturnView()
        {
            var mockService = new Moq.Mock<IFileExecutorFactory>();

            var controller = new AlmostNetCore.Controllers.FileController(mockService.Object);

            mockService.Setup(x => x.CreateExcelFileExecutor()).Returns(new ExcelFileExecutor());

            var result = controller.DowloadFile(new int[2][] { new int[] { 1,2} , new int[] { 3, 4 } });

            Assert.True(result is ActionResult);
        }

        [Test]
        public void CreateFileExecutorReturnTrue()
        {
            var fileExecutorFactory = new FileExecutorFactory();

            var file = fileExecutorFactory.CreateExcelFileExecutor();

            Assert.True(file is IFileExecutor);
        }

        [Test]
        public void GetFromFileReturnTrue()
        {
            var textFile = @";
2;3;4
5;6;7
8;9;10";
            var fileExecutorFactory = new FileExecutorFactory();

            var file = fileExecutorFactory.CreateExcelFileExecutor();

            var result = file.Load(textFile);

            Assert.IsTrue(result[0][0] == 2);
            Assert.IsTrue(result[0][1] == 3);
            Assert.IsTrue(result[0][2] == 4);
            Assert.IsTrue(result[1][0] == 5);
            Assert.IsTrue(result[1][1] == 6);
            Assert.IsTrue(result[1][2] == 7);
            Assert.IsTrue(result[2][0] == 8);
            Assert.IsTrue(result[2][1] == 9);
            Assert.IsTrue(result[2][2] == 10);
        }

        [Test]
        public void GetFromFileWrongValuesReturnFalse()
        {
            Assert.Catch<FormatException>(() =>
            {
                var textFile = @";
c;b;a
5;6;7
8;9;10";
                var fileExecutorFactory = new FileExecutorFactory();

                var file = fileExecutorFactory.CreateExcelFileExecutor();
                var result = file.Load(textFile);
            });
        }

        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void SaveMatrixReturnFileReturnTrue(int count)
        {
            var fileExecutorFactory = new FileExecutorFactory();

            var file = fileExecutorFactory.CreateExcelFileExecutor();

            var matrix = new int[count][];
            var random = new Random();

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new int[count];
                for (int j = 0; j < count; j++)
                {
                    matrix[i][j] = random.Next(100);
                }
            }

            var fileText = file.Save(matrix);

            Assert.IsNotNull(fileText);

        }

        [Test]
        public void SaveMatrixReturnNullReturnIsNull()
        {
            var fileExecutorFactory = new FileExecutorFactory();

            var file = fileExecutorFactory.CreateExcelFileExecutor();

            var matrix = new int[0][];


            var fileText = file.Save(matrix);

            Assert.IsNull(fileText);

        }

    }
}
