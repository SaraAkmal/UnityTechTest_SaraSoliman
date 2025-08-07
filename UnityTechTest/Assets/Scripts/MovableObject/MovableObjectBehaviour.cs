using System;
using System.Collections;
using System.Collections.Generic;
using MovableObject;
using UnityEngine;

public class MovableObjectBehaviour : MonoBehaviour
{
    [SerializeField] private MovableObjectView movableObjectView;
    
    private MovableObjectController _movableObjectController;
    private bool _isInitialized;

    private void Start()
    {
        if (movableObjectView == null)
        {
            Debug.LogError("MovableObjectView is null");
            return;
        }
        
        var factory = new MovableObjectFactory();
        
        _movableObjectController = factory.CreateMovableObject(movableObjectView);

        if(_movableObjectController == null)
        {
            Debug.LogError("MovableObjectController is null");
            return;
        }

        _isInitialized = true;
    }

    private void OnDestroy()
    {
        _movableObjectController?.OnDestroyed();
    }

    private void Update()
    {
        if (!_isInitialized)
            return;

        _movableObjectController.HandleInput();
    }
}
