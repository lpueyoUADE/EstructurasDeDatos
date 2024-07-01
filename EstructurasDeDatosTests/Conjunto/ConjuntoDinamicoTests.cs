using Microsoft.VisualStudio.TestTools.UnitTesting;
using EstructurasDeDatos.Conjunto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasDeDatos.Conjunto.Tests
{
    [TestClass()]
    public class ConjuntoDinamicoTests
    {
        [TestMethod()]
        public void ConjuntoDinamicoTest()
        {
            ConjuntoDinamico<int> conjunto = new();

            Assert.IsTrue(conjunto.Vacio());
        }

        [TestMethod()]
        public void AgregarTest()
        {
            ConjuntoDinamico<int> conjunto = new();

            conjunto.Agregar(10);

            Assert.IsFalse(conjunto.Vacio());
        }

        [TestMethod()]
        public void ElegirTest()
        {
            ConjuntoDinamico<int> conjunto = new();

            conjunto.Agregar(10);
            conjunto.Agregar(20);
            conjunto.Agregar(30);

            List<int> posibles_valores = new List<int> { 10, 20, 30 };

            CollectionAssert.Contains(posibles_valores, conjunto.Elegir());
        }

        [TestMethod()]
        public void PerteneceTest()
        {
            ConjuntoDinamico<int> conjunto = new();

            Assert.IsFalse(conjunto.Pertenece(10));
            Assert.IsFalse(conjunto.Pertenece(20));
            Assert.IsFalse(conjunto.Pertenece(30));

            conjunto.Agregar(10);
            conjunto.Agregar(20);
            conjunto.Agregar(30);

            Assert.IsTrue(conjunto.Pertenece(10));
            Assert.IsTrue(conjunto.Pertenece(20));
            Assert.IsTrue(conjunto.Pertenece(30));
        }

        [TestMethod()]
        public void QuitarTest()
        {
            ConjuntoDinamico<int> conjunto = new();
            conjunto.Agregar(10);
            conjunto.Agregar(20);
            conjunto.Agregar(30);

            Assert.IsTrue(conjunto.Pertenece(10));
            Assert.IsTrue(conjunto.Pertenece(20));
            Assert.IsTrue(conjunto.Pertenece(30));

            conjunto.Quitar(10);
            conjunto.Quitar(20);
            conjunto.Quitar(30);

            Assert.IsFalse(conjunto.Pertenece(10));
            Assert.IsFalse(conjunto.Pertenece(20));
            Assert.IsFalse(conjunto.Pertenece(30));
            Assert.IsTrue(conjunto.Vacio());
        }

        [TestMethod()]
        public void VacioTest()
        {
            ConjuntoDinamico<int> conjunto = new();
            Assert.IsTrue(conjunto.Vacio());

            conjunto.Agregar(10);

            Assert.IsFalse(conjunto.Vacio());

            conjunto.Quitar(10);

            Assert.IsTrue(conjunto.Vacio());
        }

        [TestMethod()]
        public void ToListTest()
        {
            ConjuntoDinamico<int> conjunto = new();
            conjunto.Agregar(10);
            conjunto.Agregar(20);
            conjunto.Agregar(30);

            List<int> resultado = conjunto.ToList();
            Assert.AreEqual(resultado.Count(), conjunto.Cantidad());

            foreach (int valor in resultado)
            {
                Assert.IsTrue(conjunto.Pertenece(valor));
            }
        }

        [TestMethod()]
        public void CantidadTest()
        {
            ConjuntoDinamico<int> conjunto = new();
            Assert.AreEqual(conjunto.Cantidad(), 0);

            conjunto.Agregar(10);
            conjunto.Agregar(20);
            conjunto.Agregar(30);

            Assert.AreEqual(conjunto.Cantidad(), 3);

            conjunto.Quitar(10);
            Assert.AreEqual(conjunto.Cantidad(), 2);

            conjunto.Quitar(20);
            Assert.AreEqual(conjunto.Cantidad(), 1);

            conjunto.Quitar(30);
            Assert.AreEqual(conjunto.Cantidad(), 0);
        }
    }
}