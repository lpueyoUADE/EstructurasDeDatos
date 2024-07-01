using Microsoft.VisualStudio.TestTools.UnitTesting;
using EstructurasDeDatos.Lista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasDeDatos.Lista.Tests
{
    [TestClass()]
    public class ListaSimplementeEnlazadaTests
    {
        [TestMethod()]
        public void AgregarTest()
        {
            ListaSimplementeEnlazada<int> lista = new();
            Assert.AreEqual(0, lista.Cantidad());

            lista.Agregar(10);
            lista.Agregar(20);
            lista.Agregar(30);

            Assert.AreEqual(3, lista.Cantidad());
            Assert.AreEqual(lista[0], 10);
            Assert.AreEqual(lista[1], 20);
            Assert.AreEqual(lista[2], 30);
        }

        [TestMethod()]
        public void CantidadTest()
        {
            ListaSimplementeEnlazada<int> lista = new();
            Assert.AreEqual(0, lista.Cantidad());

            lista.Agregar(10);
            lista.Agregar(20);
            lista.Agregar(30);

            Assert.AreEqual(3, lista.Cantidad());

            lista.Remover();
            Assert.AreEqual(2, lista.Cantidad());

            lista.Remover();
            Assert.AreEqual(1, lista.Cantidad());

            lista.Remover();
            Assert.AreEqual(0, lista.Cantidad());


            lista.AgregarEnOrden(10);
            lista.AgregarEnOrden(20);
            lista.AgregarEnOrden(30);

            Assert.AreEqual(3, lista.Cantidad());

            lista.Remover();
            Assert.AreEqual(2, lista.Cantidad());

            lista.Remover();
            Assert.AreEqual(1, lista.Cantidad());

            lista.Remover();
            Assert.AreEqual(0, lista.Cantidad());

        }

        [TestMethod()]
        public void OrdenarTest()
        {
            ListaSimplementeEnlazada<int> lista = new();

            List<int> numeros = new List<int> { 9, 0, 1, 8, 2, 7, 3, 6, 4, 5 };

            foreach (int numero in numeros)
            {
                lista.Agregar(numero);
            }

            Assert.IsTrue(lista.Cantidad() == numeros.Count);

            lista.Ordenar(false);
            numeros.Sort();

            for (int i = 0; i < numeros.Count; i++)
            {
                Assert.IsTrue(lista[i] == numeros[i]);
            }
        }

        [TestMethod()]
        public void RemoverTest()
        {
            ListaSimplementeEnlazada<int> lista = new();
            Assert.AreEqual(0, lista.Cantidad());

            lista.Agregar(10);
            lista.Agregar(20);
            lista.Agregar(30);

            Assert.AreEqual(3, lista.Cantidad());

            lista.Remover();
            Assert.AreEqual(2, lista.Cantidad());
            lista.Remover();
            Assert.AreEqual(1, lista.Cantidad());
            lista.Remover();
            Assert.AreEqual(0, lista.Cantidad());
        }

        [TestMethod()]
        public void RemoverEnTest()
        {
            ListaSimplementeEnlazada<int> lista = new();
            Assert.AreEqual(0, lista.Cantidad());

            lista.Agregar(10);
            Assert.AreEqual(1, lista.Cantidad());

            lista.RemoverEn(0);

            Assert.AreEqual(0, lista.Cantidad());

            lista.Agregar(10);
            lista.Agregar(20);
            lista.Agregar(30);

            lista.RemoverEn(2);
            Assert.AreEqual(2, lista.Cantidad());

            lista = new();

            List<int> numeros = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            foreach (int numero in numeros)
            {
                lista.Agregar(numero);
            }

            // Remuevo el 0, el 4 y el 9
            lista.RemoverEn(0);
            lista.RemoverEn(lista.Cantidad() - 1);
            lista.RemoverEn(3);

            CollectionAssert.DoesNotContain(lista.ToList(), new List<int> { 1, 2, 3, 5, 6, 7, 8 });
        }

        [TestMethod()]
        public void AgregarEnOrdenTest()
        {
            ListaSimplementeEnlazada<int> lista = new ListaSimplementeEnlazada<int>();
            lista.Agregar(10);
            lista.Agregar(20);
            lista.Agregar(30);

            lista.AgregarEnOrden(15);

            List<int> listaEsperada = new List<int> { 10, 15, 20, 30 };
            CollectionAssert.AreEqual(listaEsperada, lista.ToList());
        }

        [TestMethod()]
        public void ContieneTest()
        {
            ListaSimplementeEnlazada<int> lista = new ListaSimplementeEnlazada<int>();

            Assert.IsFalse(lista.Contiene(10));
            Assert.IsFalse(lista.Contiene(20));
            Assert.IsFalse(lista.Contiene(30));

            lista.Agregar(10);
            lista.Agregar(20);
            lista.Agregar(30);

            Assert.IsTrue(lista.Contiene(10));
            Assert.IsTrue(lista.Contiene(20));
            Assert.IsTrue(lista.Contiene(30));

        }

        [TestMethod()]
        public void IndexOfTest()
        {
            ListaSimplementeEnlazada<int> lista = new ListaSimplementeEnlazada<int>();

            Assert.IsTrue(lista.IndexOf(10) == -1);
            Assert.IsTrue(lista.IndexOf(20) == -1);
            Assert.IsTrue(lista.IndexOf(30) == -1);

            lista.Agregar(10);
            lista.Agregar(20);
            lista.Agregar(30);

            Assert.IsTrue(lista.IndexOf(10) == 0);
            Assert.IsTrue(lista.IndexOf(20) == 1);
            Assert.IsTrue(lista.IndexOf(30) == 2);
        }
    }
}