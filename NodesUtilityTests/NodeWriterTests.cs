using System.IO;
using System.Text;
using System.Threading.Tasks;
using NodesUtility.Infrastructure;
using NodesUtility.Interfaces;
using NodesUtility.Modals;
using NUnit.Framework;

namespace NodesUtilityTests
{
    [TestFixture]
    public class NodeWriterTests
    {

        private const string Indentation = "    ";
        private INodeWriter _nodeWriter;

        [SetUp]
        public void Setup()
        {
            _nodeWriter = NinjectFactory.GetInstance<INodeWriter>();
        }

        [Test]
        public async Task WriteToFileAsync_Given_NoChildrenNode_Writes_To_File_NoChildrenNode()
        {
            //arrange
            var filePath = "tester.txt";
            var testData = new NoChildrenNode("root");
            var expected = "new NoChildrenNode(\"root\")";
            //act
            await _nodeWriter.WriteToFileAsync(testData, filePath);
            var actual = File.ReadAllText(filePath, Encoding.Unicode);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task WriteToFileAsync_Given_MultipleNodes_Writes_To_File_MultipleNodes()
        {
            //arrange
            var filePath = "tester.txt";
            var testData = new SingleChildNode("root",
                                new TwoChildrenNode("child1",
                                    new NoChildrenNode("leaf1"),
                                    new SingleChildNode("child2",
                                        new NoChildrenNode("leaf2"))));
            var expected = "new SingleChildNode(\"root\",\n"
                                + Indentation + "new TwoChildrenNode(\"child1\",\n"
                                + Indentation + Indentation + "new NoChildrenNode(\"leaf1\"),\n"
                                + Indentation + Indentation + "new SingleChildNode(\"child2\",\n"
                                + Indentation + Indentation + Indentation + "new NoChildrenNode(\"leaf2\"))))";
            //act
            await _nodeWriter.WriteToFileAsync(testData, filePath);
            var actual = File.ReadAllText(filePath, Encoding.Unicode);
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
