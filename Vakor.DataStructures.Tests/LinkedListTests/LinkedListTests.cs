using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vakor.DataStructures.LinkedLists;

namespace Vakor.DataStructures.Tests.LinkedListTests
{
    [TestClass]
    public class LinkedListTests
    {
        private ILinkedList<int> _linkedList;
        private Random _random;

        [TestInitialize]
        public void InitComponents()
        {
            _linkedList = new LinkedLists.LinkedList<int>();
            _random = new Random();
        }

        [TestCleanup]
        public void CleanUpComponents()
        {
            _linkedList.Clear();
        }

        [DataTestMethod]
        [DataRow(new[] {1})]
        [DataRow(new[] {1, 2, 3, 4, 5})]
        [DataRow(new[] {-1, 126, 22, 394})]
        public void InsertTest(int[] elements)
        {
            foreach (var element in elements)
            {
                _linkedList.Insert(element);
            }

            Assert.AreEqual(elements.Length, _linkedList.Length);
            Assert.AreEqual(elements[0], _linkedList.First.Data);
            Assert.AreEqual(elements[^1], _linkedList.Last.Data);
        }

        [TestMethod]
        public void RemoveFirstTest()
        {
            List<int> elements = GenerateRandomInts(12);

            foreach (var element in elements)
            {
                _linkedList.Insert(element);
            }

            _linkedList.Remove(elements[0]);

            Assert.AreEqual(elements[1], _linkedList.First.Data);
            Assert.AreEqual(elements.Count - 1, _linkedList.Length);
        }

        [TestMethod]
        public void RemoveLastTest()
        {
            List<int> elements = GenerateRandomInts(12);

            while (elements.Count(el => el == elements[^1]) > 1)
            {
                elements = GenerateRandomInts(12);
            }

            foreach (var element in elements)
            {
                _linkedList.Insert(element);
            }

            _linkedList.Remove(elements[^1]);

            Assert.AreEqual(elements[^2], _linkedList.Last.Data);
            Assert.AreEqual(null, _linkedList.Last.NextElement);
            Assert.AreEqual(elements.Count - 1, _linkedList.Length);
        }

        [TestMethod]
        public void RemoveNonExistElementTest()
        {
            List<int> elements = GenerateRandomInts(12);

            foreach (var element in elements)
            {
                _linkedList.Insert(element);
            }

            Assert.ThrowsException<ArgumentException>(() => _linkedList.Remove(-1));
        }

        [TestMethod]
        public void RemoveTest()
        {
            List<int> elements = GenerateRandomInts(12);

            foreach (var element in elements)
            {
                _linkedList.Insert(element);
            }

            for (int i = 0; i < elements.Count; i++)
            {
                if (_random.Next(0, 10) > 5)
                {
                    _linkedList.Remove(elements[i]);
                    elements.Remove(elements[i]);
                }
            }

            Assert.AreEqual(elements.Count, _linkedList.Length);
            Assert.AreEqual(elements[0], _linkedList.First.Data);


            Assert.AreEqual(elements[^1], _linkedList.Last.Data);
            Assert.AreEqual(null, _linkedList.Last.NextElement);

            for (int i = 0; i < elements.Count; i++)
            {
                Assert.AreEqual(elements[i], _linkedList[i].Data);

                if (i < elements.Count - 1)
                {
                    Assert.AreEqual(elements[i + 1], _linkedList[i].NextElement.Data);
                }
                else
                {
                    Assert.AreEqual(null, _linkedList[i].NextElement);
                }
            }
        }

        [TestMethod]
        public void SearchTest()
        {
            List<int> elements = GenerateRandomInts(12);

            foreach (var element in elements)
            {
                _linkedList.Insert(element);
            }

            var emptyNode = _linkedList.Search(-1);

            Assert.AreEqual(null, emptyNode);
            Assert.AreEqual(elements[3], _linkedList.Search(elements[3]).Data);
        }


        [TestMethod]
        public void InsertAtFirstTest()
        {
            List<int> elements = GenerateRandomInts(10);

            for (int i = 0; i < elements.Count; i++)
            {
                _linkedList.InsertAt(elements[i], 0);

                Assert.AreEqual(i + 1, _linkedList.Length);
                Assert.AreEqual(elements[i], _linkedList.First.Data);
                Assert.AreEqual(elements[0], _linkedList.Last.Data);

                if (i > 0)
                {
                    Assert.AreEqual(elements[i - 1], _linkedList.First.NextElement.Data);
                }
            }
        }

        [TestMethod]
        public void GetNodeByWrongIndexerTest()
        {
            List<int> elements = GenerateRandomInts(12);

            foreach (var element in elements)
            {
                _linkedList.Insert(element);
            }

            Assert.ThrowsException<IndexOutOfRangeException>(() => _linkedList[-1]);
            Assert.ThrowsException<IndexOutOfRangeException>(() => _linkedList[12]);
        }
        
        [TestMethod]
        public void GetNodeByIndexerTest()
        {
            List<int> elements = GenerateRandomInts(12);

            foreach (var element in elements)
            {
                _linkedList.Insert(element);
            }

            for (int i = 0; i < elements.Count; i++)
            {
                Assert.AreEqual(elements[i], _linkedList[i].Data);
            }
        }

        [TestMethod]
        public void InsertAtTest()
        {
            List<int> elements = GenerateRandomInts(20);

            foreach (var element in elements)
            {
                _linkedList.InsertAt(element, _random.Next(0, _linkedList.Length));
            }

            Assert.AreEqual(20, elements.Count);
            Assert.AreNotEqual(null, _linkedList.First);
            Assert.AreNotEqual(null, _linkedList.Last);

            for (int i = 0; i < elements.Count - 1; i++)
            {
                Assert.AreNotEqual(null, _linkedList[i].NextElement);
            }
            
            Assert.AreEqual(null, _linkedList.Last.NextElement);
        }

        [TestMethod]
        public void InsertAtWrongIndexTest()
        {
            List<int> elements = GenerateRandomInts(10);

            foreach (var element in elements)
            {
                _linkedList.Insert(element);
            }

            Assert.ThrowsException<IndexOutOfRangeException>(() => _linkedList.InsertAt(_random.Next(), -1));
            Assert.ThrowsException<IndexOutOfRangeException>(() =>
                _linkedList.InsertAt(_random.Next(), elements.Count + 1));
        }
        
        [TestMethod]
        public void RemoveAtWrongIndexTest()
        {
            List<int> elements = GenerateRandomInts(10);

            foreach (var element in elements)
            {
                _linkedList.Insert(element);
            }

            Assert.ThrowsException<IndexOutOfRangeException>(() => _linkedList.RemoveAt(-1));
            Assert.ThrowsException<IndexOutOfRangeException>(() => _linkedList.RemoveAt(elements.Count));
        }

        [TestMethod]
        public void RemoveAtFirstIndexTest()
        {
            List<int> elements = GenerateRandomInts(10);

            foreach (var element in elements)
            {
                _linkedList.Insert(element);
            }
            
            _linkedList.RemoveAt(0);
            
            Assert.AreEqual(elements[1], _linkedList.First.Data);
            Assert.AreEqual(elements.Count -1,_linkedList.Length);
        }
        
        [TestMethod]
        public void RemoveAtLastIndexTest()
        {
            List<int> elements = GenerateRandomInts(10);

            foreach (var element in elements)
            {
                _linkedList.Insert(element);
            }
            
            _linkedList.RemoveAt(elements.Count-1);
            
            Assert.AreEqual(elements[^2], _linkedList.Last.Data);
            Assert.AreEqual(elements.Count -1,_linkedList.Length);
        }

        [TestMethod]

        private List<int> GenerateRandomInts(int elementsCount, int min = 0, int max = 100)
        {
            List<int> newList = new List<int>();

            for (int i = 0; i < elementsCount; i++)
            {
                newList.Add(_random.Next(min, max));
            }

            return newList;
        }
    }
}