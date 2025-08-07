using System;
using System.Collections;
using System.Collections.Generic;
using MovableObject;

public class MovableObjectFactory
{
    public MovableObjectController CreateMovableObject(MovableObjectView movableObjectView)
    {
        var movableModelController = new MovableObjectModel();
        var movableViewController = movableObjectView;

        var movableController = new MovableObjectController(movableModelController, movableViewController);
        return movableController;
    }
}
