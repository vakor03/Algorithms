using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vakor.DataStructures.Stacks;

namespace Vakor.DataStructures.Tests.StackTests
{
    [TestClass]
    public class LinkedStackTests
    {
        private IStack<int> _stack;

        [TestCleanup]
        public void TestClean()
        {
            _stack.Clear();
        }

        [TestInitialize]
        public void TestInit()
        {
            _stack = new LinkedListStack<int>();
        }

        [TestMethod]
        public void PushTest()
        {
            _stack.Push(24);
            _stack.Push(12);
            _stack.Push(23);

            Assert.AreEqual(3, _stack.Length);
            Assert.AreEqual(23, _stack.Pop());

            _stack.Push(23);
            Assert.AreEqual(23, _stack.Pop());
            Assert.AreEqual(12, _stack.Pop());
            Assert.AreEqual(24, _stack.Pop());
        }

        [TestMethod]
        public void EmptyStackPopTest()
        {
            Assert.ThrowsException<IndexOutOfRangeException>(() => _stack.Pop());
        }
    }
}