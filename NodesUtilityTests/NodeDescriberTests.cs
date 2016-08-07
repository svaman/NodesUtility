using NodesUtility.Business;
using NodesUtility.Modals;
using NUnit.Framework;

namespace NodesUtilityTests
{
    [TestFixture]
    public class NodeDescriberTests
    {
        private NodeDescriber _nodeDescriber;
        private const string Indentation = "    ";

        [SetUp]
        public void Setup()
        {
            _nodeDescriber = new NodeDescriber(Indentation);
        }

        [Test]
        public void Describe_Given_NoChildrenNode_Returns_NoChildrenNodeDescription()
        {
            //arrange
            var expected = "new NoChildrenNode(\"root\")";
            var testInput = new NoChildrenNode("root");
            //act
            var actual = _nodeDescriber.Describe(testInput);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Describe_Given_SingleChildNode_Returns_SingleChildNodeDescription()
        {
            //arrange
            var expected = "new SingleChildNode(\"root\",\n" + Indentation + "new NoChildrenNode(\"leaf1\"))";
            var testData = new SingleChildNode("root", new NoChildrenNode("leaf1"));
            //act
            var actual = _nodeDescriber.Describe(testData);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Describe_Given_TwoChildrenNode_Returns_TwoChildrenNodeDescription()
        {
            //arrange
            var expected = "new TwoChildrenNode(\"root\",\n"
                            + Indentation + "new NoChildrenNode(\"leaf1\"),\n"
                            + Indentation + "new NoChildrenNode(\"leaf2\"))";
            var testData = new TwoChildrenNode("root",
                                new NoChildrenNode("leaf1"),
                                new NoChildrenNode("leaf2"));
            //act
            var actual = _nodeDescriber.Describe(testData);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Describe_Given_ThreeLevelsOfNestedNodes_Returns_ThreeLevelsOfNestedNodesDescription()
        {
            //arrange
            var expected = "new SingleChildNode(\"root\",\n"
                                + Indentation + "new TwoChildrenNode(\"child1\",\n"
                                + Indentation + Indentation + "new NoChildrenNode(\"leaf1\"),\n"
                                + Indentation + Indentation + "new SingleChildNode(\"child2\",\n"
                                + Indentation + Indentation + Indentation + "new NoChildrenNode(\"leaf2\"))))";
            var testData = new SingleChildNode("root",
                                new TwoChildrenNode("child1",
                                    new NoChildrenNode("leaf1"),
                                    new SingleChildNode("child2",
                                        new NoChildrenNode("leaf2"))));
            //act
            var actual = _nodeDescriber.Describe(testData);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Describe_Given_ManyChildrenNode_Returns_ManyChildrenNodeDescription()
        {
            //arrange
            var expected = "new ManyChildrenNode(\"root\",\n"
                            + Indentation + "new NoChildrenNode(\"leaf1\"))";
            var testData = new ManyChildrenNode("root",
                                new NoChildrenNode("leaf1"));
            //act
            var actual = _nodeDescriber.Describe(testData);
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
