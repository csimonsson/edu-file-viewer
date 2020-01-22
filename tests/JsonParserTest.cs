using System;
using edu_file_viewer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace edu_file_viewer_tests
{
    [TestClass]
    public class JsonParserTest
    {
        [TestMethod]
        public void TestMoviesParse()
        {
            var parser = new JsonFileTreeParser("data/movies.json");
            var root = parser.Parse();

            Assert.AreEqual("movies", root.Name);
            Assert.AreEqual(3, root.Children.Count);
            
            Assert.IsTrue(root.IsFolder);
            Assert.IsFalse(root.IsFile);

            Assert.IsTrue(root.Children.ContainsKey("marvel"));

            var marvel = root.Children["marvel"];

            Assert.AreEqual(3, marvel.Children.Count);
            Assert.IsTrue(marvel.IsFolder);
            Assert.IsFalse(marvel.IsFile);

            Assert.IsTrue(marvel.Children.ContainsKey("marvel_logo.png"));

            var logo = marvel.Children["marvel_logo.png"];

            Assert.AreEqual(0, logo.Children.Count);
            Assert.IsFalse(logo.IsFolder);
            Assert.IsTrue(logo.IsFile);
        }

        [TestMethod]
        public void TestParseMissing()
        {
            var parser = new JsonFileTreeParser("data/missing.json");
            Assert.ThrowsException<Exception>(() => parser.Parse());
        }

        [TestMethod]
        public void TestParseFaulty()
        {
            var parser = new JsonFileTreeParser("data/faulty.json");
            Assert.ThrowsException<JsonReaderException>(() => parser.Parse());
        }
    }
}
