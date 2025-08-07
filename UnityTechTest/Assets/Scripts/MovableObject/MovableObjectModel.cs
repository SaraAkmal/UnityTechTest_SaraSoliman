using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Model class holds data
public class MovableObjectModel
{
   private Vector3 _position;
   private int _score;

   public Vector3 CurrentPosition => _position;
   public int CurrentScore => _score;

   public event Action OnPositionChange;
   public event Action OnScoreChange;

   public void ChangeObjectPosition(Vector3 newPosition)
   {
      _position = newPosition;
      UpdateObjectPosition();
   }
   
   public void IncrementScore(int amount)
   {
      _score += amount;
      UpdateScore();
   }
   
   //Dispatch events
   private void UpdateObjectPosition()
   {
      OnPositionChange?.Invoke();
   }
   
   private void UpdateScore()
   {
      OnScoreChange?.Invoke();
   }
}
