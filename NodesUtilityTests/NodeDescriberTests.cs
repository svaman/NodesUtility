using NodesUtility.Business;
using NodesUtility.Modals;
using NUnit.Framework;

namespace NodesUtilityTests
{
    [TestFixture]
    public class NodeDescriberTests
    {

        [Test]
        public void Describe_InputNoChildrenNode_OutputsSameDescription()
        {
            var expected = "new NoChildrenNode(\"root\")";

            var nodeDescriber = new NodeDescriber();
            var testInput = new NoChildrenNode("root");
            var actual = nodeDescriber.Describe(testInput);
            Assert.AreEqual(expected, actual);
        }
    }
}
