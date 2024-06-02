using System;
using Factory_System.singleton;
using Factory_System.structure.@enum;
using Factory_System.validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Factory_System.Tests;

[TestClass]
public class Test
{
    [TestMethod]
    public void test_GetOneStarShipWithName()
    {
        var cookBook = Singleton<CookBook>.Instance;
        var test = cookBook.GetOneStarShipWithName("hello");
        Assert.IsNull(test);
    }


    [TestMethod]
    public void test_splitCommand_Wrong()
    {
        var commandBuilder = new CommandValidation("hello");
        Assert.ThrowsException<ArgumentException>(commandBuilder.SplitIntoCommandAndArgs);
    }

    [TestMethod]
    public void test_splitCommand_Good()
    {
        var commandBuilder = new CommandValidation("STOCKS ");
        commandBuilder.SplitIntoCommandAndArgs();
        Assert.IsTrue(commandBuilder.CommandAndArgs.CommandEnum == CommandEnum.Stocks);
        Assert.IsTrue(commandBuilder.CommandAndArgs.Args == null);
    }

    [TestMethod]
    public void test_splitCommand_Good_NOTRIM()
    {
        var commandBuilder = new CommandValidation("STOCKS");
        commandBuilder.SplitIntoCommandAndArgs();
        Assert.IsTrue(commandBuilder.CommandAndArgs.CommandEnum == CommandEnum.Stocks);
        Assert.IsTrue(commandBuilder.CommandAndArgs.Args == null);
    }

    [TestMethod]
    public void test_VerifyByCommand()
    {
        var commandBuilder = new CommandValidation("PRODUCE ");
        commandBuilder.SplitIntoCommandAndArgs();
        Assert.ThrowsException<ArgumentNullException>(commandBuilder.VerifyByCommand);
    }

    [TestMethod]
    public void test_VerifyByCommand_STOCKS()
    {
        var commandBuilder = new CommandValidation("STOCKS ");
        commandBuilder
            .SplitIntoCommandAndArgs()
            .VerifyByCommand();
    }
}