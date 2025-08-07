using UnityEngine;

public interface IloggerService
{
  public void LogMessage(string message);
}

public class LoggerService : IloggerService
{
  public void LogMessage(string message)
  {
    Debug.Log(message);
  }
}

