using Microsoft.VisualStudio.TestTools.UnitTesting;
using EstructurasDeDatos.AVL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasDeDatos.AVL.Tests
{
    [TestClass()]
    public class AVLTests
    {
        [TestMethod()]
        public void AVLTest()
        {
            AVL<int> avlTree = new();
            Assert.AreEqual(avlTree.Length, 0);
        }

        [TestMethod()]
        public void LengthTest()
        {
            AVL<int> avlTree = new();
            Assert.AreEqual(avlTree.Length, 0);

            avlTree.Insert(10);
            avlTree.Insert(20);
            avlTree.Insert(30);

            Assert.AreEqual(avlTree.Length, 3);

            avlTree.Delete(10);
            Assert.AreEqual(avlTree.Length, 2);

            avlTree.Delete(20);
            Assert.AreEqual(avlTree.Length, 1);

            avlTree.Delete(30);
            Assert.AreEqual(avlTree.Length, 0);
        }

        [TestMethod()]
        public void SearchTest()
        {
            AVL<int> avlTree = new();

            Assert.IsFalse(avlTree.Search(10));

            avlTree.Insert(10);
            avlTree.Insert(20);
            avlTree.Insert(30);

            avlTree.Delete(30);

            Assert.IsTrue(avlTree.Search(10));
        }

        [TestMethod()]
        public void InsertTest()
        {
            // Un valor
            AVL<int> avlTree = new();
            avlTree.Insert(10);

            Assert.IsTrue(avlTree.Search(10));
            Assert.AreEqual(1, avlTree.Length);

            // Muchos valores
            avlTree = new();
            avlTree.Insert(10);
            avlTree.Insert(20);
            avlTree.Insert(5);

            Assert.IsTrue(avlTree.Search(10));
            Assert.IsTrue(avlTree.Search(20));
            Assert.IsTrue(avlTree.Search(5));
            Assert.AreEqual(3, avlTree.Length);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Borrar con AVL vacio
            AVL<int> avl = new();
            avl.Insert(10);
            avl.Delete(10);

            Assert.IsFalse(avl.Search(10));
            Assert.AreEqual(0, avl.Length);

            // Borrar elemento no existente => sin efecto.
            avl = new();
            avl.Insert(10);
            avl.Delete(20);

            Assert.IsTrue(avl.Search(10));
            Assert.IsFalse(avl.Search(20));
            Assert.AreEqual(1, avl.Length);

            // Borrar un elemento, el resto OK.
            avl = new();
            avl.Insert(10);
            avl.Insert(20);
            avl.Insert(5);
            avl.Delete(10);

            Assert.IsFalse(avl.Search(10));
            Assert.IsTrue(avl.Search(20));
            Assert.IsTrue(avl.Search(5));
            Assert.AreEqual(2, avl.Length);
        }

        [TestMethod()]
        public void InOrderTraversalTest()
        {
            AVL<int> avl = new();

            List<int> initialvalues = new List<int> { 5, 10, 20 };

            foreach (int i in initialvalues)
            {
                avl.Insert(i);
            }

            List<int> result = avl.InOrderTraversal();

            Assert.AreEqual(result.Count, initialvalues.Count);

            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(result[i], initialvalues[i]);
            }
        }

        [TestMethod()]
        public void PreOrderTraversalTest()
        {
            AVL<int> avl = new();

            List<int> initialvalues = new List<int> { 10, 5, 20 };

            foreach (int i in initialvalues)
            {
                avl.Insert(i);
            }

            List<int> result = avl.PreOrderTraversal();

            Assert.AreEqual(result.Count, initialvalues.Count);

            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(result[i], initialvalues[i]);
            }
        }

        [TestMethod()]
        public void PostOrderTraversalTest()
        {
            AVL<int> avl = new();

            List<int> initialvalues = new List<int> { 5, 20, 10 };

            foreach (int i in initialvalues)
            {
                avl.Insert(i);
            }

            List<int> result = avl.PostOrderTraversal();

            Assert.AreEqual(result.Count, initialvalues.Count);

            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(result[i], initialvalues[i]);
            }
        }

        [TestMethod()]
        public void ConsoleDisplayTest()
        {
            AVL<int> avl = new();

            List<int> initialvalues = new List<int> { 10, 20, 30, 40, 50, 60, 70, 80 };

            foreach (int i in initialvalues)
            {
                avl.Insert(i);
            }

            avl.ConsoleDisplay();
        }
    }
}