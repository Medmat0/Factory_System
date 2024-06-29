namespace Factory_System;

public class StdInJson : SdtInInterface
{
    public void execute(string? path)
    {
        if (path == null)
        {
            throw new Exception();
        }
        throw new NotImplementedException();
    }
}