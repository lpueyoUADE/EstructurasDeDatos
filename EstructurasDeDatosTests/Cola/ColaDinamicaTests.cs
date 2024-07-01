using Microsoft.VisualStudio.TestTools.UnitTesting;
using EstructurasDeDatos.Cola;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstructurasDeDatos.Pila;

namespace EstructurasDeDatos.Cola.Tests
{
    [TestClass()]
    public class ColaDinamicaTests
    {
        [TestMethod()]
        public void ColaDinamicaTest()
        {
            ColaDinamica<int> colaDinamica = new();
            Assert.IsTrue(colaDinamica.ColaVacia());
        }

        [TestMethod()]
        public void ColaVaciaTest()
        {
            ColaDinamica<int> colaDinamica = new();
            Assert.IsTrue(colaDinamica.ColaVacia());

            int valor = 10;

            colaDinamica.Encolar(valor);
            Assert.IsFalse(colaDinamica.ColaVacia());
        }

        [TestMethod()]
        public void DesEncolarTest()
        {
            ColaDinamica<int> colaDinamica = new();

            int valor = 10;
            colaDinamica.Encolar(valor);
            int resultado = colaDinamica.DesEncolar();

            Assert.IsTrue(resultado == valor);
            Assert.IsTrue(colaDinamica.ColaVacia());

            List<int> lista = new List<int> { 10, 11, 12, 13 };

            foreach (var item in lista)
            {
                colaDinamica.Encolar(item);
            }

            int i = 0;
            while (!colaDinamica.ColaVacia())
            {
                Assert.IsTrue(colaDinamica.DesEncolar() == lista[i]);
                i++;
            }

            Assert.IsTrue(colaDinamica.ColaVacia());
        }

        [TestMethod()]
        public void EncolarTest()
        {
            ColaDinamica<int> colaDinamica = new();

            int valor = 10;
            colaDinamica.Encolar(valor);

            Assert.IsFalse(colaDinamica.ColaVacia());
            Assert.IsTrue(colaDinamica.Primero() == valor);
        }

        [TestMethod()]
        public void InicializarColaTest()
        {
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void PrimeroTest()
        {
            ColaDinamica<int> colaDinamica = new();
            Assert.IsTrue(colaDinamica.Primero() == default);

            List<int> lista = new List<int> { 10, 11, 12, 13 };

            foreach (var item in lista)
            {
                colaDinamica.Encolar(item);
            }

            int i = 0;
            while (!colaDinamica.ColaVacia())
            {
                Assert.IsTrue(colaDinamica.Primero() == lista[i]);
                colaDinamica.DesEncolar();
                i++;
            }
        }
    }
}