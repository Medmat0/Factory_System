namespace Factory_System;

public class StdInTxt : SdtInInterface
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