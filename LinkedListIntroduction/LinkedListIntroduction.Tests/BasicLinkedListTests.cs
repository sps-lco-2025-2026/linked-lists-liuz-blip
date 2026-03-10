using LinkedListIntroduction.Lib;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;

namespace LinkedListIntroduction.Tests;

[TestClass]
public sealed class BasicLinkedListTests
{
    [TestMethod]
    public void TestToString()
    {
        IntegerLinkedList ill = new IntegerLinkedList(1);
        ill.Append(2);
        ill.Append(3);

        string result = ill.ToString();
        Assert.AreEqual("{1, 2, 3}", result);
    }

    [TestMethod]
    public void TestEmpty()
    {
        IntegerLinkedList ill = new IntegerLinkedList();
        Assert.AreEqual(0, ill.Count);
    }

    [TestMethod]
    public void TestCount()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(9);
        Assert.AreEqual(3, ill.Count);
    }

    [TestMethod]
    public void TestSum()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(9);
        Assert.AreEqual(21, ill.Sum);
    }

    [TestMethod]
    public void TestToStringExplicit()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(9);
        Assert.AreEqual("{5, 7, 9}", ill.ToString());
    }

    [TestMethod]
    public void TestPrepend()
    {
        var ill = new IntegerLinkedList(2);
        ill.Append(3);
        ill.Append(4);
        ill.Prepend(1);
        Assert.AreEqual("{1, 2, 3, 4}", ill.ToString());
    }

    [TestMethod]
    public void TestDelete()
    {
        var ill = new IntegerLinkedList(0);
        ill.Append(1);
        ill.Append(2);
        ill.Append(3);
        Assert.IsTrue(ill.Delete(0));
    }

    [TestMethod]
    public void TestInsert()
    {
        var ill = new IntegerLinkedList(0);
        ill.Append(1);
        ill.Append(2);
        ill.Append(4);
        ill.Insert(3,3);
        Assert.AreEqual("{0, 1, 2, 3, 4}", ill.ToString());
    }

    [TestMethod]
    public void TestJoin()
    {
        var ill1 = new IntegerLinkedList();
        ill1.Append(1);
        ill1.Append(2);
        ill1.Append(3);
        var ill2 = new IntegerLinkedList();
        ill2.Append(4);
        ill2.Append(5);
        ill2.Append(6);
        ill1.Join(ill2);

        Assert.AreEqual("{1, 2, 3, 4, 5, 6}", ill1.ToString());
    }

    [TestMethod]
    public void TestContains()
    {
        var ill = new IntegerLinkedList(0);
        ill.Append(1);
        ill.Append(2);
        ill.Append(3);
        Assert.IsTrue(ill.Contains(3));
    }

    [TestMethod]
    public void TestRemoveDuplicates()
    {
        var ill = new IntegerLinkedList(1);
        ill.Append(2);
        ill.Append(1); // Duplicate
        ill.Append(3);
        ill.Append(2); // Duplicate
        ill.Append(2); // Triple Duplicate

        ill.RemoveDupes();

        Assert.AreEqual("{1, 2, 3}", ill.ToString());
    }

    [TestMethod]
    public void TestMergeAlternating()
    {
        var ill1 = new IntegerLinkedList(1);
        ill1.Append(3);
        ill1.Append(5);
        var ill2 = new IntegerLinkedList(2);
        ill2.Append(4);
        ill2.Append(6);

        ill1.Merge(ill2);
        Assert.AreEqual("{1, 2, 3, 4, 5, 6}", ill1.ToString());
    }

    [TestMethod]
    public void TestReverse()
    {
        var ill = new IntegerLinkedList(1);
        ill.Append(2);
        ill.Append(3);
        IntegerLinkedList reversed = ill.Reverse();
        Assert.AreEqual("{3, 2, 1}", reversed.ToString());
    }



}
