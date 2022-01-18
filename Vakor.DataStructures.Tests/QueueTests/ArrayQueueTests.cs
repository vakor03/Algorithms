using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vakor.DataStructures.Queues;

namespace Vakor.DataStructures.Tests.QueueTests
{
    [TestClass]
    public class ArrayQueueTests
    {
        private IQueue<int> _queue;

        [TestCleanup]
        public void TestClean()
        {
            _queue.Clear();
        }

        [TestInitialize]
        public void TestInit()
        {
            _queue = new ArrayQueue<int>();
        }

        [TestMethod]
        public void PushTest()
        {
            _queue.Enqueue(24);
            _queue.Enqueue(12);
            _queue.Enqueue(23);

            Assert.AreEqual(3, _queue.Length);
            Assert.AreEqual(24, _queue.Dequeue());

            _queue.Enqueue(23);
            Assert.AreEqual(12, _queue.Dequeue());
            Assert.AreEqual(23, _queue.Dequeue());
            Assert.AreEqual(23, _queue.Dequeue());
        }

        [TestMethod]
        public void EmptyStackPopTest()
        {
            Assert.ThrowsException<IndexOutOfRangeException>(() => _queue.Dequeue());
        }
    }
}