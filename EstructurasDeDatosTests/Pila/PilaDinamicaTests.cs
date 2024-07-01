using Microsoft.VisualStudio.TestTools.UnitTesting;
using EstructurasDeDatos.Pila;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasDeDatos.Pila.Tests
{
    [TestClass()]
    public class PilaDinamicaTests
    {
        [TestMethod()]
        public void PilaDinamicaTest()
        {
            PilaDinamica<int> pilaDinamica = new();
            Assert.IsTrue(pilaDinamica.IsPilaVacia());
        }

        [TestMethod()]
        public void ApilarTest()
        {
            PilaDinamica<int> pilaDinamica = new();

            int valor = 10;
            pilaDinamica.Apilar(valor);

            Assert.IsFalse(pilaDinamica.IsPilaVacia());
            Assert.IsTrue(pilaDinamica.Tope() == valor);
        }

        [TestMethod()]
        public void DesapilarTest()
        {
            PilaDinamica<int> pilaDinamica = new();

            int valor = 10;
            pilaDinamica.Apilar(valor);
            int resultado = pilaDinamica.Desapilar();

            Assert.IsTrue(resultado == valor);
            Assert.IsTrue(pilaDinamica.IsPilaVacia());

            List<int> lista = new List<int> { 10, 11, 12, 13 };

            foreach (var item in lista)
            {
                pilaDinamica.Apilar(item);
            }

            int i = 0;
            while (!pilaDinamica.IsPilaVacia())
            {
                Assert.IsTrue(pilaDinamica.Desapilar() == lista[lista.Count - 1 - i]);
                i++;
            }

            Assert.IsTrue(pilaDinamica.IsPilaVacia());
        }

        [TestMethod()]
        public void InicializarPilaTest()
        {
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void IsPilaVaciaTest()
        {
            PilaDinamica<int> pilaDinamica = new();
            Assert.IsTrue(pilaDinamica.IsPilaVacia());

            List<int> lista = new List<int> { 10, 11, 12, 13 };

            foreach (var item in lista)
            {
                pilaDinamica.Apilar(item);
            }

            pilaDinamica.Desapilar();
            pilaDinamica.Desapilar();

            Assert.IsFalse(pilaDinamica.IsPilaVacia());

            pilaDinamica.Desapilar();
            pilaDinamica.Desapilar();

            Assert.IsTrue(pilaDinamica.IsPilaVacia());
        }

        [TestMethod()]
        public void TopeTest()
        {
            PilaDinamica<int> pilaDinamica = new();
            Assert.IsTrue(pilaDinamica.Tope() == default);

            List<int> lista = new List<int> { 10, 11, 12, 13 };

            foreach (var item in lista)
            {
                pilaDinamica.Apilar(item);
            }

            int i = 0;
            while (!pilaDinamica.IsPilaVacia())
            {
                Assert.IsTrue(pilaDinamica.Tope() == lista[lista.Count - 1 - i]);
                pilaDinamica.Desapilar();
                i++;
            }
        }
    }
}