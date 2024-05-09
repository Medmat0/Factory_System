using Factory_System;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Factory_System.Tests;

[TestClass]
public class Test
{

    [TestMethod]
    public void METHOD()
    {
        var cookBook = Singleton<CookBook>.Instance;
        var test = cookBook.GetOneStarShipWithName("hello");
        Assert.IsNull(test);
    }

    [TestMethod]
    public void test_argument_false()
    {
        string hello = "hello world";
        var command = new CommandProcess(hello);
        Assert.IsFalse(command.VerifyValidityOfCommand());
    }
    
    [TestMethod]
    public void test_argument_true()
    {
        string stocks = "STOCKS";
        var command = new CommandProcess(stocks);
        Assert.IsTrue(command.VerifyValidityOfCommand());
    }
}