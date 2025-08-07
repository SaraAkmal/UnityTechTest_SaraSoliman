using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class ServiceLocator
{
   private static ServiceLocator _instance;
   private Dictionary<Type, object> _services = new Dictionary<Type, object>();
   
   public static ServiceLocator Instance
   {
      get
      {
         return _instance ??= new ServiceLocator();
      }
   }
   
   public bool TryGetService <T>(out T service)
   {
      service = default;
      if (_services.TryGetValue(typeof(T), out var value))
      {
         service = (T)value;
         return true;
      }
    
      return false;
   }
   
   // Register service
   public void Provide<T>(T interfaceInstance)
   {
      _services.TryAdd(typeof(T), interfaceInstance);
   }
}
