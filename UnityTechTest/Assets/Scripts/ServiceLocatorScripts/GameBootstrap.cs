using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
   private void Start()
   {
      Initialize();
   }

   private void Initialize()
   {
      ServiceLocator.Instance.Provide<IloggerService>(new LoggerService());
   }
}
