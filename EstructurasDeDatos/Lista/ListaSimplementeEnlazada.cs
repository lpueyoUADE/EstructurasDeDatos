using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasDeDatos.Lista
{
    public class ListaSimplementeEnlazada<T> : ILista<T> where T : IComparable
    {
        private Nodo<T>? cabeza;
        private int cantidad;

        public ListaSimplementeEnlazada()
        {
            cantidad = 0;
        }

        public T this[int indice]
        {
            get
            {
                if (indice < 0 || indice >= Cantidad())
                {
                    throw new ArgumentOutOfRangeException("El índice está fuera del rango de la lista.");
                }

                Nodo<T> actual = cabeza;
                for (int i = 0; i < indice; i++)
                {
                    actual = actual.Siguiente;
                }

                return actual.Valor;
            }
            set
            {
                if (indice < 0 || indice >= Cantidad())
                {
                    throw new ArgumentOutOfRangeException("El índice está fuera del rango de la lista.");
                }

                Nodo<T> actual = cabeza;
                for (int i = 0; i < indice; i++)
                {
                    actual = actual.Siguiente;
                }

                actual.Valor = value;
            }
        }

        public void Agregar(T item)
        {
            Nodo<T> nuevoNodo = new(item);

            if (cabeza == null)
            {
                cabeza = nuevoNodo;
            }
            else
            {
                Nodo<T> actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevoNodo;
            }

            cantidad++;
        }

        public void AgregarEnOrden(T item)
        {
            Nodo<T> nuevoNodo = new(item);

            if (cabeza == null || item.CompareTo(cabeza.Valor) < 0)
            {
                nuevoNodo.Siguiente = cabeza;
                cabeza = nuevoNodo;
                cantidad++;
                return;
            }

            Nodo<T> actual = cabeza;
            while (actual.Siguiente != null && item.CompareTo(actual.Siguiente.Valor) >= 0)
            {
                actual = actual.Siguiente;
            }

            nuevoNodo.Siguiente = actual.Siguiente;
            actual.Siguiente = nuevoNodo;
            cantidad++;
        }

        public int Cantidad()
        {
            return cantidad;
        }

        public List<T> ToList()
        {
            List<T> listaConvertida = new();
            Nodo<T>? actual = cabeza;
            while (actual != null)
            {
                listaConvertida.Add(actual.Valor);
                actual = actual.Siguiente;
            }
            return listaConvertida;
        }

        private void ToLSE(List<T> lista)
        {
            cabeza = null;

            foreach (T elemento in lista)
            {
                this.Agregar(elemento);
            }
        }
        public void Ordenar(bool desc = true)
        {
            List<T> lista = ToList();
            
            lista.Sort(); // TODO Eventualmente cambiar esta cochinada por un QuickSort caserito.

            if (desc)
            {
                lista.Reverse();
            }

            ToLSE(lista);
        }

        public void Remover()
        {
            RemoverEn(Cantidad() - 1);
        }

        public void RemoverEn(int indice)
        {
            if (indice < 0 || indice >= Cantidad())
                throw new ArgumentOutOfRangeException("El índice está fuera del rango de la lista.");


            Nodo<T>? anterior = null;
            Nodo<T>? actual = cabeza;

            if (indice == 0)
            {
                cabeza = cabeza.Siguiente;
                cantidad--;
                return;
            }

            for (int i = 0; i < indice; i++)
            {
                anterior = actual;
                actual = actual.Siguiente;
            }

            anterior.Siguiente = actual.Siguiente;

            cantidad--;
        }

        public bool Contiene(T item)
        {
            return IndexOf(item) != -1;
        }

        public int IndexOf(T item)
        {
            if (cabeza == null)
                return -1;

            Nodo<T>? actual = cabeza;
            int indice = 0;

            while (actual != null)
            {
                if (item.CompareTo(actual.Valor) == 0)
                    return indice;

                actual = actual.Siguiente;
                indice++;
            }

            return -1;
        }
    }
}
