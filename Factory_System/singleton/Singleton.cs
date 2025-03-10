namespace Factory_System.singleton;

public class Singleton<T> where T : new()
{
    private static T instance;
    private static readonly object lockObject = new();

    private Singleton()
    {
    }

    public static T Instance
    {
        get
        {
            if (instance == null)
                lock (lockObject)
                {
                    if (instance == null) instance = new T();
                }

            return instance;
        }
    }
}