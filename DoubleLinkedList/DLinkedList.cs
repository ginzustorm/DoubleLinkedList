using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace DoubleLinkedList
{
    public class DLinkedList<T> : IEnumerable<T>
    {
        /// <summary>
        /// Конец списка. 
        /// </summary>
        private Node<T>? tail;
        /// <summary>
        /// Начало списка. 
        /// </summary>
        private Node<T>? head;
        /// <summary>
        /// Размер списка. 
        /// </summary>
        private int size = 0;

        /// <summary>
        /// Добавление элемента в список. 
        /// </summary>
        /// <param name="value">Добавляемое значение. </param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Add(T value)
        {
            if (value == null) throw new ArgumentNullException("Значение не может быть равно null", nameof(value));
            Node<T> node = new Node<T>(value);
            if (size == 0)
            {
                head = node;
                size++;
            }
            else if (size == 1)
            {
                tail = head;
                tail.previous = node;
                node.next = tail;
                head = node;
                size++;
            }
            else
            {
                head.previous = node;
                node.next = head;
                head = node;
                size++;
            }
        }

        /// <summary>
        /// Вывод списка в консоль сверху-вниз. 
        /// </summary>
        public void PrintList()
        {
            if (getSize() == 0)
            {
                Console.WriteLine("Список пуст. ");
                return;
            }

            int index = 0;
            Node<T> spanNode = head;
            while(spanNode != null)
            {
                index++;
                Console.WriteLine($"Элемент списка: {index} \t Значение: {spanNode.data}");
                spanNode = spanNode.next;
            }
        }

        /// <summary>
        /// Вывод списка в консоль снизу-вверх. 
        /// </summary>
        public void ReversePrintList()
        {
            if (getSize() == 0)
            {
                Console.WriteLine("Список пуст. ");
                return;
            }

            int index = size + 1;
            Node<T> spanNode = tail;
            while (spanNode != null)
            {
                index--;
                Console.WriteLine($"Элемент списка: {index} \t Значение: {spanNode.data}");
                spanNode = spanNode.previous;
            }
        }

        /// <summary>
        /// Проверка наличия элемента в списке. 
        /// </summary>
        /// <param name="value">Значение для поиска. </param>
        /// <returns></returns>
        public bool IsInList(T value)
        {
            var currentNode = head;
            if (getSize() == 0)
            {
                Console.WriteLine("Список пуст. ");
                return false;
            }

            while (currentNode != null)
            {
                if (currentNode.data.Equals(value))
                {
                    Console.WriteLine($"Значение {value} имеется в списке");
                    return true;
                }
                currentNode = currentNode.next;
            }
            Console.WriteLine($"Значение {value} не имеется в списке");
            return false;
        }

        /// <summary>
        /// Метод, возвращающий размер списка. 
        /// </summary>
        /// <returns></returns>
        public int getSize()
        {
            return size;
        }

        /// <summary>
        /// Реализация интерфейса IEnumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            var current = head;
            while(current != null)
            {
                yield return current.data;
                current = current.next;
            }
        }

        public void Remove(T value)
        {
            if (!IsInList(value))
            {
                return;
            }
            else
            {
                var currentNode = head;
                while (currentNode != null)
                {
                    if (currentNode.data.Equals(value))
                    {
                        var tempNext = currentNode.next;
                        var tempPrev = currentNode.previous;
                        tempPrev.next = tempNext;
                        return;
                    }
                    else
                    {
                        currentNode = currentNode.next;
                    }
                }
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }
}
