using NodesUtility.Business;
using NodesUtility.Modals;
using NUnit.Framework;

namespace NodesUtilityTests
{
    [TestFixture]
    public class NodeDescriberTests
    {
        private const string Indentation = "    ";

        [Test]
        public void Describe_InputNoChildrenNode_OutputsSameDescription()
        {
            var expected = "new NoChildrenNode(\"root\")";

            var nodeDescriber = new NodeDescriber(Indentation);
            var testInput = new NoChildrenNode("root");
            var actual = nodeDescriber.Describe(testInput);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Describe_InputSingleChildNode_OutputsSameDescription()
        {
            var expected = "new SingleChildNode(\"root\",\n" + Indentation + "new NoChildrenNode(\"leaf1\"))";

            var nodeDescriber = new NodeDescriber(Indentation);
            var testData = new SingleChildNode("root", new NoChildrenNode("leaf1"));
            var actual = nodeDescriber.Describe(testData);
            Assert.AreEqual(expected, actual);
        }
    }
}
