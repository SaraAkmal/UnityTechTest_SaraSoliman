using UnityEngine;

public interface ILoggerService
{
  public void LogMessage(string message);
}

public class LoggerService : ILoggerService
{
  public void LogMessage(string message)
  {
    Debug.Log(message);
  }
}

public class NullLoggerService : ILoggerService
{
  public void LogMessage(string message)
  {
    Debug.Log("Logger service is not available");
  }
}
