using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodesUtility.Business;
using NodesUtility.Modals;
using NUnit.Framework;

namespace NodesUtilityTests
{
    [TestFixture]
    public class NodeTransformerTests
    {

        [Test]
        public void Test_Input_SingleChildNode_Returns_SameNode()
        {
            //arrange
            var expected = new SingleChildNode("root",
                                new NoChildrenNode("leaf"));
            var transformer = new NodeTransformer();
            var testInput = new SingleChildNode("root",
                                new NoChildrenNode("leaf"));
            //act
            var actual = transformer.Transform(testInput);
            //assert
            Assert.AreEqual(expected, actual);
        }

    }
}
