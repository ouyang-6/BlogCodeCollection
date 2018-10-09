using ConsoleApp1;
using Moq;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UnitTestTestableProject
{
    [TestFixture]
    public class AClassTest1404
    {
        private Mock<IA> MockA;

        private Mock<IB> MockB;

        private Mock<IC> MockC;

        private AClassTestable1404 target;

        [SetUp]
        public void Setup()
        {
            MockA = new Mock<IA>();
            MockA.Setup(a => a.A()).Returns(1);
            MockB = new Mock<IB>();
            MockB.Setup(b => b.B()).Returns(1);
            MockC = new Mock<IC>();
            MockC.Setup(c => c.C()).Returns(1);
            target = new AClassTestable1404(MockA.Object, MockB.Object, MockC.Object);
        }

        [Test]
        public void ShouldReturnCorrectWhenCallABC()
        {
            Assert.AreEqual(target.CallABC(), 3);
        }

        [Test]
        public void ShouldReturnCorrectWhenCallAB()
        {
            Assert.AreEqual(target.CallBaseAB(), 2);
        }

        [Test]
        public void ShouldReturnCorrectWhenCallAC()
        {
            Assert.AreEqual(target.InvokeBaseNonPublicMethod<int>("CallAC", (object[]) null), 2);
        }
    }

    public class AClassTestable1404 : AClass
    {
        public AClassTestable1404(IA a, IB b, IC c)
        {
            A = a;
            B = b;
            C = c;
        }

        public int CallBaseAB()
        {
            return base.CallAB();
        }
    }
}