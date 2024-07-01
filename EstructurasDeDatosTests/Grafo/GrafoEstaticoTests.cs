using Microsoft.VisualStudio.TestTools.UnitTesting;
using EstructurasDeDatos.Grafo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasDeDatos.Grafo.Tests
{
    [TestClass()]
    public class GrafoEstaticoTests
    {
        [TestMethod()]
        public void GrafoEstaticoTest()
        {
            GrafoEstatico<string> grafo = new GrafoEstatico<string>(5);
            Assert.AreEqual(grafo.VerticesCount, 0);
        }

        [TestMethod()]
        public void AddVertexTest()
        {
            GrafoEstatico<string> grafo = new GrafoEstatico<string>(5);
            grafo.AddVertex("A");
            grafo.AddVertex("B");
            grafo.AddVertex("C");

            Assert.AreEqual(grafo.VerticesCount, 3);

            grafo.AddVertex("D");

            Assert.IsTrue(grafo.HasVertex("D"));
            Assert.AreEqual(grafo.VerticesCount, 4);

            grafo.AddVertex("E");
            Assert.AreEqual(grafo.VerticesCount, 5);

            Assert.ThrowsException<InvalidOperationException>(() => grafo.AddVertex("F"));
        }

        [TestMethod()]
        public void AddEdgeTest()
        {
            GrafoEstatico<string> grafo = new GrafoEstatico<string>(5);
            grafo.AddVertex("A");
            grafo.AddVertex("B");
            grafo.AddVertex("C");

            Assert.IsFalse(grafo.HasEdge("A", "B"));
            Assert.ThrowsException<ArgumentException>(() => grafo.GetEdgeWeight("A", "B"));

            grafo.AddEdge("A", "B", 1);
            grafo.AddEdge("A", "C", 2);

            Assert.IsTrue(grafo.HasEdge("A", "B"));
            Assert.AreEqual(1, grafo.GetEdgeWeight("A", "B"));

            Assert.IsTrue(grafo.HasEdge("A", "C"));
            Assert.AreEqual(2, grafo.GetEdgeWeight("A", "C"));

            Assert.IsFalse(grafo.HasEdge("B", "C"));
            Assert.ThrowsException<ArgumentException>(() => grafo.GetEdgeWeight("B", "C"));
        }

        [TestMethod()]
        public void HasVertexTest()
        {
            GrafoEstatico<string> grafo = new GrafoEstatico<string>(5);
            grafo.AddVertex("A");
            grafo.AddVertex("B");
            grafo.AddVertex("C");

            Assert.IsTrue(grafo.HasVertex("A"));
            Assert.IsTrue(grafo.HasVertex("B"));
            Assert.IsTrue(grafo.HasVertex("C"));

            Assert.IsFalse(grafo.HasVertex("D"));
        }

        [TestMethod()]
        public void HasEdgeTest()
        {
            GrafoEstatico<string> grafo = new GrafoEstatico<string>(5);
            grafo.AddVertex("A");
            grafo.AddVertex("B");
            grafo.AddVertex("C");

            Assert.IsFalse(grafo.HasEdge("A", "B"));
            Assert.IsFalse(grafo.HasEdge("A", "C"));
            Assert.IsFalse(grafo.HasEdge("B", "C"));

            grafo.AddEdge("A", "B", 1);
            grafo.AddEdge("A", "C", 2);

            Assert.IsTrue(grafo.HasEdge("A", "B"));

            Assert.IsTrue(grafo.HasEdge("A", "C"));

            Assert.IsFalse(grafo.HasEdge("B", "C"));
        }

        [TestMethod()]
        public void GetEdgeWeightTest()
        {
            GrafoEstatico<string> grafo = new GrafoEstatico<string>(5);
            grafo.AddVertex("A");
            grafo.AddVertex("B");
            grafo.AddVertex("C");

            Assert.IsFalse(grafo.HasEdge("A", "B"));
            Assert.ThrowsException<ArgumentException>(() => grafo.GetEdgeWeight("A", "B"));

            grafo.AddEdge("A", "B", 1);

            Assert.IsTrue(grafo.HasEdge("A", "B"));
            Assert.AreEqual(1, grafo.GetEdgeWeight("A", "B"));

        }

        [TestMethod()]
        public void GetVerticesTest()
        {
            GrafoEstatico<string> grafo = new GrafoEstatico<string>(5);
            grafo.AddVertex("A");
            grafo.AddVertex("B");
            grafo.AddVertex("C");

            var expectedVertices = new HashSet<string> { "A", "B", "C" };
            var vertices = grafo.GetVertices();

            Assert.AreEqual(expectedVertices.Count, vertices.Count);
            Assert.IsTrue(vertices.Contains("A"));
            Assert.IsTrue(vertices.Contains("B"));
            Assert.IsTrue(vertices.Contains("C"));
        }

        [TestMethod()]
        public void GetNeighborsTest()
        {
            GrafoEstatico<string> grafo = new GrafoEstatico<string>(5);
            grafo.AddVertex("A");
            grafo.AddVertex("B");
            grafo.AddVertex("C");

            grafo.AddEdge("A", "B", 1);
            grafo.AddEdge("A", "C", 2);

            var neighborsOfA = grafo.GetNeighbors("A");

            Assert.IsTrue(neighborsOfA.Contains("B"));
            Assert.IsTrue(neighborsOfA.Contains("C"));
            Assert.AreEqual(2, neighborsOfA.Count);

            Assert.ThrowsException<ArgumentException>(() => grafo.GetNeighbors("D"));
        }

        [TestMethod()]
        public void DijkstraTest()
        {
            GrafoEstatico<string> grafo = new GrafoEstatico<string>(5);
            grafo.AddVertex("A");
            grafo.AddVertex("B");
            grafo.AddVertex("C");

            grafo.AddEdge("A", "B", 1);
            grafo.AddEdge("A", "C", 2);

            var paths = grafo.Dijkstra("A");

            Assert.IsTrue(paths.ContainsKey("A"));
            Assert.IsTrue(paths.ContainsKey("B"));
            Assert.IsTrue(paths.ContainsKey("C"));

            CollectionAssert.AreEqual(new List<string> { "A" }, paths["A"]);
            CollectionAssert.AreEqual(new List<string> { "A", "B" }, paths["B"]);
            CollectionAssert.AreEqual(new List<string> { "A", "C" }, paths["C"]);
        }
    }
}