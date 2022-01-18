using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vakor.DataStructures.DoubleLinkedLists;

namespace Vakor.DataStructures.Tests.LinkedListTests
{
    [TestClass]
    public class DoubleLinkedListTests
    {
        private IDoubleLinkedList<int> _linkedList;
        private Random _random;

        [TestInitialize]
        public void InitComponents()
        {
            _linkedList = new DoubleLinkedList<int>();
            _random = new Random();
        }

        [TestCleanup]
        public void CleanUpComponents()
        {
            _linkedList.Clear();
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
        public void InsertTest()
        {
            List<int> elements = GenerateRandomInts(24);

            foreach (var element in elements)
            {
                _linkedList.Insert(element);
            }

            Assert.AreEqual(24, _linkedList.Length);
            Assert.AreEqual(elements[0], _linkedList.First.Data);
            Assert.AreEqual(elements[^1], _linkedList.Last.Data);

            for (int i = 0; i < elements.Count; i++)
            {
                Assert.AreEqual(elements[i], _linkedList[i].Data);

                if (i > 0)
                {
                    Assert.AreEqual(elements[i - 1], _linkedList[i].PrevElement.Data);
                }
                else
                {
                    Assert.AreEqual(null, _linkedList[i].PrevElement);
                }

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
        public void InsertAtWrongIndexTest()
        {
            List<int> elements = GenerateRandomInts(24);

            foreach (var element in elements)
            {
                _linkedList.Insert(element);
            }

            Assert.ThrowsException<IndexOutOfRangeException>(() => _linkedList.InsertAt(elements[0], -1));
            Assert.ThrowsException<IndexOutOfRangeException>(
                () => _linkedList.InsertAt(elements[0], elements.Count + 1));
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

            for (int i = 0; i < elements.Count; i++)
            {
                Assert.AreNotEqual(null, _linkedList[i]);

                if (i > 0)
                {
                    Assert.AreNotEqual(null, _linkedList[i].PrevElement);
                }
                else
                {
                    Assert.AreEqual(null, _linkedList[i].PrevElement);
                }

                if (i < elements.Count - 1)
                {
                    Assert.AreNotEqual(null, _linkedList[i].NextElement);
                }
                else
                {
                    Assert.AreEqual(null, _linkedList[i].NextElement);
                }
            }
        }

        [TestMethod]
        public void RemoveUnexistedElementTest()
        {
            List<int> elements = GenerateRandomInts(20, 0, 10);

            foreach (var element in elements)
            {
                _linkedList.InsertAt(element, _random.Next(0, _linkedList.Length));
            }

            Assert.ThrowsException<ArgumentException>(() => _linkedList.Remove(11));
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

            for (int i = 0; i < elements.Count; i++)
            {
                Assert.AreEqual(elements[i], _linkedList[i].Data);

                if (i > 0)
                {
                    Assert.AreEqual(elements[i - 1], _linkedList[i].PrevElement.Data);
                }
                else
                {
                    Assert.AreEqual(null, _linkedList[i].PrevElement);
                }

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
        public void RemoveFirstTest()
        {
            List<int> elements = GenerateRandomInts(12);

            foreach (var element in elements)
            {
                _linkedList.Insert(element);
            }

            _linkedList.Remove(elements[0]);

            Assert.AreEqual(11, _linkedList.Length);
            Assert.AreEqual(elements[1], _linkedList.First.Data);
            Assert.AreEqual(null, _linkedList.First.PrevElement);
            Assert.AreEqual(elements[2], _linkedList.First.NextElement.Data);
        }

        [TestMethod]
        public void RemoveAllTest()
        {
            List<int> elements = GenerateRandomInts(10);

            foreach (var element in elements)
            {
                _linkedList.Insert(element);
            }

            foreach (var element in elements)
            {
                _linkedList.Remove(element);
            }

            Assert.AreEqual(null, _linkedList.First);
            Assert.AreEqual(null, _linkedList.Last);
            Assert.AreEqual(0, _linkedList.Length);
        }
        
        [TestMethod]
        public void RemoveAtAllTest()
        {
            List<int> elements = GenerateRandomInts(10);

            foreach (var element in elements)
            {
                _linkedList.Insert(element);
            }

            foreach (var _ in elements)
            {
                _linkedList.RemoveAt(0);
            }

            Assert.AreEqual(null, _linkedList.First);
            Assert.AreEqual(null, _linkedList.Last);
            Assert.AreEqual(0, _linkedList.Length);
        }

        [TestMethod]
        public void RemoveLastTest()
        {
            List<int> elements = GenerateRandomInts(12);
            
            // for this test I need only one element with value of the last
            while (elements.Count(el => el == elements[^1]) > 1)
            {
                elements = GenerateRandomInts(12);
            }

            foreach (var element in elements)
            {
                _linkedList.Insert(element);
            }

            _linkedList.Remove(elements[11]);

            Assert.AreEqual(11, _linkedList.Length);
            Assert.AreEqual(elements[^2], _linkedList.Last.Data);
            Assert.AreEqual(null, _linkedList.Last.NextElement);
            Assert.AreEqual(elements[^3], _linkedList.Last.PrevElement.Data);
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
            Assert.AreEqual(elements[2], _linkedList.First.NextElement.Data);
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
            Assert.AreEqual(elements[^3], _linkedList.Last.PrevElement.Data);
            Assert.AreEqual(elements.Count -1,_linkedList.Length);
        }
        
        [TestMethod]
        public void RemoveAtTest()
        {
            List<int> elements = GenerateRandomInts(10);

            foreach (var element in elements)
            {
                _linkedList.Insert(element);
            }
            
            _linkedList.RemoveAt(2);
            
            Assert.AreEqual(elements[3], _linkedList[2].Data);
            Assert.AreEqual(elements[1], _linkedList[2].PrevElement.Data);
            Assert.AreEqual(elements[4], _linkedList[2].NextElement.Data);
            Assert.AreEqual(elements.Count -1,_linkedList.Length);
        }

        private List<int> GenerateRandomInts(int count, int min = 0, int max = 20)
        {
            List<int> list = new List<int>();

            for (int i = 0; i < count; i++)
            {
                list.Add(_random.Next(min, max));
            }

            return list;
        }
    }
}