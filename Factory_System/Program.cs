// See https://aka.ms/new-console-template for more information

using Factory_System.parse;

namespace Factory_System;

internal class Program
{
    private static void Main(string[] args)
    {
        var parseArgumentConsole = new ParseArgumentConsole(args);
        parseArgumentConsole.BuildSdout();
    }
}