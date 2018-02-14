using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OperationManager.DataManager;
using PacmanGame.GameManager;
using PacmanGame.ReportManager;

namespace PacmanTest
{
    [TestClass]
    public class BeforeGameStartRunTest
    {
        [TestMethod]
        public void IsNewStartFalseTest()
        {
            var mockSqlConnect = new Mock<ISqLiteConnection>();
            mockSqlConnect.Setup(x => x.IfTableExist()).Returns(true);
            mockSqlConnect.Setup(x => x.GetLastGeneration()).Returns(2);

            var beforeGameStartRun = new BeforeGameStartRun(mockSqlConnect.Object, new ReportGenerate(mockSqlConnect.Object));
            var result = beforeGameStartRun.IsNewStart();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsNewStartTureTest()
        {
            var mockSqlConnect = new Mock<ISqLiteConnection>();
            mockSqlConnect.Setup(x => x.IfTableExist()).Returns(false);
            mockSqlConnect.Setup(x => x.GetLastGeneration()).Returns(0);

            var beforeGameStartRun = new BeforeGameStartRun(mockSqlConnect.Object, new ReportGenerate(mockSqlConnect.Object));
            var result = beforeGameStartRun.IsNewStart();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsNewStartTureTest2()
        {
            var mockSqlConnect = new Mock<ISqLiteConnection>();
            mockSqlConnect.Setup(x => x.IfTableExist()).Returns(true);
            mockSqlConnect.Setup(x => x.GetLastGeneration()).Returns(0);

            var beforeGameStartRun = new BeforeGameStartRun(mockSqlConnect.Object, new ReportGenerate(mockSqlConnect.Object));
            var result = beforeGameStartRun.IsNewStart();
            Assert.IsTrue(result);
        }
    }
}
