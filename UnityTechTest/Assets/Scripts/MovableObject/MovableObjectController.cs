using System.Collections;
using System.Collections.Generic;
using MovableObject;
using UnityEngine;

// Controller facilitates communication between the model and view
public class MovableObjectController
{
    private readonly MovableObjectModel _movableObjectModel;
    private readonly MovableObjectView _movableObjectView;

    public MovableObjectController(MovableObjectModel movableObjectModel, MovableObjectView movableObjectView)
    {
        _movableObjectModel = movableObjectModel;
        _movableObjectView = movableObjectView;
        
        _movableObjectView.Initialize();
        
        _movableObjectModel.OnPositionChange += OnPositionUpdated;
        _movableObjectModel.OnScoreChange += OnScoredUpdated;
    }

    public void OnDestroyed()
    {
        _movableObjectModel.OnPositionChange -= OnPositionUpdated;
        _movableObjectModel.OnScoreChange -= OnScoredUpdated;
    }

    public void HandleInput()
    {
        var state = _movableObjectView.IsMovableObjectClicked();
        if (state)
        {
            UpdateModelData();
        }
    }

    private void UpdateModelData()
    {
        var newPosition = GetRandomPosition();
        var incrementAmount = 1;
            
        _movableObjectModel.ChangeObjectPosition(newPosition);
        _movableObjectModel.IncrementScore(incrementAmount);
    }

    private void OnPositionUpdated()
    {
        _movableObjectView.UpdateObjectPosition(_movableObjectModel.CurrentPosition);
    }
    
    private void OnScoredUpdated()
    {
        var score = _movableObjectModel.CurrentScore;
        _movableObjectView.UpdateScoreUI(score);
    }
    
    private Vector3 GetRandomPosition()
    {
        var randomXOffset = Random.Range(-1.0f, 1.0f);
        var randomZOffset = Random.Range(-1.0f, 1.0f);
        var randomPos = new Vector3(_movableObjectModel.CurrentPosition.x + randomXOffset, 0.5f,
            _movableObjectModel.CurrentPosition.z + randomZOffset);
        return randomPos;
    }
}
