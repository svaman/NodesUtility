using NodesUtility.Business;
using NodesUtility.Modals;
using NUnit.Framework;

namespace NodesUtilityTests
{
    [TestFixture]
    public class NodeTransformerTests
    {
        [Test]
        public void Transform_Given_SingleChildNode_Returns_SameNode()
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

        [Test]
        public void Transform_Given_ManyChildrenNode_And_NoChildren_Returns_NoChildrenNode()
        {
            //arrange
            var expected = new NoChildrenNode("root");
            var transformer = new NodeTransformer();
            var testInput = new ManyChildrenNode("root");
            //act
            var actual = transformer.Transform(testInput);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Transform_Given_ManyChildrenNode_And_OneChild_Returns_SingleChildNode()
        {
            //arrange
            var expected = new SingleChildNode("root",
                                new NoChildrenNode("leaf"));
            var transformer = new NodeTransformer();
            var testInput = new ManyChildrenNode("root",
                                new ManyChildrenNode("leaf"));
            //act
            var actual = transformer.Transform(testInput);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Transform_Given_ManyChildrenNode_And_ManyChildren_Returns_DerivedNodes()
        {
            var expected = new SingleChildNode("root",
                                new TwoChildrenNode("child1",
                                    new NoChildrenNode("leaf1"),
                                    new SingleChildNode("child2",
                                        new NoChildrenNode("leaf2"))));

            var transformer = new NodeTransformer();
            var testInput = new ManyChildrenNode("root",
                                new ManyChildrenNode("child1",
                                    new ManyChildrenNode("leaf1"),
                                    new ManyChildrenNode("child2",
                                        new ManyChildrenNode("leaf2"))));
            var actual = transformer.Transform(testInput);
            Assert.AreEqual(expected, actual);
        }

    }
}
