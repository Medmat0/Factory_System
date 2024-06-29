namespace Factory_System;

public class StdInXml : SdtInInterface
{
    public void execute(string? path)
    {
        if (path == null)
        {
            throw new Exception();
        }
    }
}