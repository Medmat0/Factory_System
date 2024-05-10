using System;
using Factory_System.singleton;
using Factory_System.structure.data;
using Factory_System.structure.@enum;
using Factory_System.structure.piece;
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
        Assert.ThrowsException<Exception>(commandBuilder.SplitIntoCommandAndArgs);
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
        Assert.ThrowsException<Exception>(commandBuilder.VerifyByCommand);
    }

    [TestMethod]
    public void test_VerifyByCommand_STOCKS()
    {
        var commandBuilder = new CommandValidation("STOCKS ");
        commandBuilder
            .SplitIntoCommandAndArgs()
            .VerifyByCommand();
    }


    [TestMethod]
    public void test_Database_RemoveAndAddPiece()
    {
        var database = Singleton<Database>.Instance;
        database.AddNewPiece(Wing.Wings_WC1);
        database.AddNewPiece(Wing.Wings_WC1);
        database.AddNewPiece(Wing.Wings_WC1);
        database.AddNewPiece(Wing.Wings_WE1);
        Assert.IsTrue(database.ListWings.Count == 2);
        database.DeletePieces(Wing.Wings_WC1, 1);
        Assert.IsTrue(database.ListWings.Count == 2);
        Assert.IsTrue(database.ListWings[1].Number == 2);
        database.DeletePieces(Wing.Wings_WE1, 1);
        Assert.IsTrue(database.ListWings.Count == 1);
    }

    [TestMethod]
    public void test_Database_AddStarShip()
    {
        var database = Singleton<Database>.Instance;
        var cookBook = Singleton<CookBook>.Instance;
        database.AddNewStarShip(cookBook.GetStarShipsWithEnum(StartShipName.Cargo));
        database.AddNewStarShip(cookBook.GetStarShipsWithEnum(StartShipName.Cargo));
        database.AddNewStarShip(cookBook.GetStarShipsWithEnum(StartShipName.Cargo));
        database.AddNewStarShip(cookBook.GetStarShipsWithEnum(StartShipName.Speeder));
        Assert.IsTrue(database.StarShipStructs.Count == 2);
    }

    [TestMethod]
    public void test_Database_AddAndRemoveAssembly()
    {
        var hello = "hello";
        var database = Singleton<Database>.Instance;
        var test = new StructAssembly();
        test.Engine = Engine.Engine_EC1;
        test.Thruster = Thruster.Thruster_TC1;
        database.AddNewAssembly(test, hello);
        Assert.IsTrue(database.Assemblies.ContainsKey("hello"));
        database.RemoveAssembly("hello");
        Assert.IsFalse(database.Assemblies.ContainsKey("hello"));
    }

    [TestMethod]
    public void test_Database_AddAndRemoveAssemblyNoName()
    {
        var database = Singleton<Database>.Instance;
        var test = new StructAssembly();
        test.Engine = Engine.Engine_EC1;
        test.Thruster = Thruster.Thruster_TC1;
        database.AddNewAssembly(test);
        Assert.IsTrue(database.Assemblies.ContainsKey("[Engine_EC1, Thruster_TC1]"));
        database.RemoveAssembly("[Engine_EC1, Thruster_TC1]");
        Assert.IsFalse(database.Assemblies.ContainsKey("[Engine_EC1, Thruster_TC1]"));
    }

    [TestMethod]
    public void test_Database_toString()
    {
        var database = Singleton<Database>.Instance;
        database.AddNewPiece(Wing.Wings_WC1);
        database.AddNewPiece(Wing.Wings_WC1);
        var test = new StructAssembly();
        test.Engine = Engine.Engine_EC1;
        test.Thruster = Thruster.Thruster_TC1;
        database.AddNewAssembly(test);
        const string hello = "hello";
        var assembly = new StructAssembly();
        assembly.Engine = Engine.Engine_EC1;
        assembly.Thruster = Thruster.Thruster_TC1;
        database.AddNewAssembly(test, hello);
        var cookBook = Singleton<CookBook>.Instance;
        database.AddNewStarShip(cookBook.GetStarShipsWithEnum(StartShipName.Cargo));
        const string expected = "1 Cargo\n2 Wings_WC1\n1 [Engine_EC1, Thruster_TC1]\n1 hello\n";
        Console.Write(database.ToString());
        Console.Write(expected);
        Assert.IsTrue(expected == database.ToString());
    }

    [TestMethod]
    public void test_Database()
    {
        var database = Singleton<Database>.Instance;
        database.AddNewPiece(Wing.Wings_WC1,3);
        database.AddNewPiece(Wing.Wings_WC1 ,10);
        Assert.IsTrue(13  == database.NumberPiece(Wing.Wings_WC1));
    }
}