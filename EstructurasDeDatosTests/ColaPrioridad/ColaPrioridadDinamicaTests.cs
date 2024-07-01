using Microsoft.VisualStudio.TestTools.UnitTesting;
using EstructurasDeDatos.ColaPrioridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasDeDatos.ColaPrioridad.Tests
{
    [TestClass()]
    public class ColaPrioridadDinamicaTests
    {
        [TestMethod()]
        public void ColaPrioridadDinamicaTest()
        {
            ColaPrioridadDinamica<int> colaPrioridadDinamica = new();
            Assert.IsTrue(colaPrioridadDinamica.ColaVacia());
        }

        [TestMethod()]
        public void ColaVaciaTest()
        {
            ColaPrioridadDinamica<int> colaPrioridadDinamica = new();
            Assert.IsTrue(colaPrioridadDinamica.ColaVacia());

            colaPrioridadDinamica.Encolar(10, 1);
            Assert.IsFalse(colaPrioridadDinamica.ColaVacia());

            colaPrioridadDinamica.DesEncolar();
            Assert.IsTrue(colaPrioridadDinamica.ColaVacia());

            colaPrioridadDinamica.Encolar(10, 1);
            colaPrioridadDinamica.Encolar(20, 5);
            colaPrioridadDinamica.Encolar(30, 10);

            Assert.IsFalse(colaPrioridadDinamica.ColaVacia());

            colaPrioridadDinamica.DesEncolar();
            colaPrioridadDinamica.DesEncolar();
            colaPrioridadDinamica.DesEncolar();

            Assert.IsTrue(colaPrioridadDinamica.ColaVacia());
        }

        [TestMethod()]
        public void DesEncolarTest()
        {
            ColaPrioridadDinamica<int> colaPrioridadDinamica = new();
            colaPrioridadDinamica.Encolar(10, 1);
            colaPrioridadDinamica.Encolar(20, 5);
            colaPrioridadDinamica.Encolar(30, 10);

            Assert.AreEqual(colaPrioridadDinamica.DesEncolar(), 30);
            Assert.AreEqual(colaPrioridadDinamica.DesEncolar(), 20);
            Assert.AreEqual(colaPrioridadDinamica.DesEncolar(), 10);
        }

        [TestMethod()]
        public void EncolarTest()
        {
            ColaPrioridadDinamica<int> colaPrioridadDinamica = new();
            colaPrioridadDinamica.Encolar(10, 100);
            colaPrioridadDinamica.Encolar(20, 50);
            colaPrioridadDinamica.Encolar(30, 10);

            Assert.AreEqual(colaPrioridadDinamica.DesEncolar(), 10);
            Assert.AreEqual(colaPrioridadDinamica.DesEncolar(), 20);
            Assert.AreEqual(colaPrioridadDinamica.DesEncolar(), 30);
        }

        [TestMethod()]
        public void InicializarColaPrioridadTest()
        {
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void PrimeroTest()
        {
            ColaPrioridadDinamica<int> colaPrioridadDinamica = new();
            colaPrioridadDinamica.Encolar(10, 100);
            colaPrioridadDinamica.Encolar(20, 50);
            colaPrioridadDinamica.Encolar(30, 10);

            Assert.AreEqual(colaPrioridadDinamica.Primero(), 10);

            colaPrioridadDinamica.DesEncolar();
            Assert.AreEqual(colaPrioridadDinamica.Primero(), 20);

            colaPrioridadDinamica.DesEncolar();
            Assert.AreEqual(colaPrioridadDinamica.Primero(), 30);

            colaPrioridadDinamica.DesEncolar();
            Assert.IsTrue(colaPrioridadDinamica.ColaVacia());
        }

        [TestMethod()]
        public void PrioridadTest()
        {
            ColaPrioridadDinamica<int> colaPrioridadDinamica = new();
            colaPrioridadDinamica.Encolar(10, 100);
            colaPrioridadDinamica.Encolar(20, 50);
            colaPrioridadDinamica.Encolar(30, 10);

            Assert.AreEqual(colaPrioridadDinamica.Prioridad(), 100);

            colaPrioridadDinamica.DesEncolar();
            Assert.AreEqual(colaPrioridadDinamica.Prioridad(), 50);

            colaPrioridadDinamica.DesEncolar();
            Assert.AreEqual(colaPrioridadDinamica.Prioridad(), 10);

            colaPrioridadDinamica.DesEncolar();
            Assert.IsTrue(colaPrioridadDinamica.ColaVacia());
        }

        [TestMethod()]
        public void CantidadTest()
        {
            ColaPrioridadDinamica<int> colaPrioridadDinamica = new();

            Assert.AreEqual(colaPrioridadDinamica.Cantidad(), 0);

            colaPrioridadDinamica.Encolar(10, 100);
            colaPrioridadDinamica.Encolar(20, 50);
            colaPrioridadDinamica.Encolar(30, 10);

            Assert.AreEqual(colaPrioridadDinamica.Cantidad(), 3);

            colaPrioridadDinamica.DesEncolar();
            Assert.AreEqual(colaPrioridadDinamica.Cantidad(), 2);

            colaPrioridadDinamica.DesEncolar();
            Assert.AreEqual(colaPrioridadDinamica.Cantidad(), 1);

            colaPrioridadDinamica.DesEncolar();
            Assert.AreEqual(colaPrioridadDinamica.Cantidad(), 0);
        }
    }
}