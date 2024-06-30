using Factory_System.singleton;

namespace Factory_System.std.@in;

public class StdRun
{
    public static void Run(string userInput)
    {
        var stdOut = Singleton<StdOutSingleton>.Instance;
        if (!string.IsNullOrEmpty(userInput))
            try
            {
                new Run(userInput).Try();
            }
            catch (ArgumentException ex)
            {
                stdOut.WriteLine("Invalid argument: " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                stdOut.WriteLine("Operation error: " + ex.Message);
            }
            catch (Exception ex)
            {
                stdOut.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        else
            stdOut.WriteLine("You must enter a command.");
    }
}