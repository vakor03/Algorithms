using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vakor.DataStructures.Stacks;

namespace Vakor.DataStructures.Tests.StackTests
{
    [TestClass]
    public class ArrayStackTests
    {
        private IStack<int> _stack;

        [TestCleanup]
        public void TestClean()
        {
            _stack = new ArrayStack<int>();
        }

        [TestInitialize]
        public void TestInit()
        {
            _stack = new ArrayStack<int>();
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
            Assert.ThrowsException<ArgumentException>(() => _stack.Pop());
        }
    }
}