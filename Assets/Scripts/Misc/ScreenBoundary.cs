﻿using System;
using UnityEngine;

public class ScreenBoundary {

    private readonly Camera camera;

    public ScreenBoundary(Camera camera) {
        this.camera = camera;
    }

    public float Top {
        get {
            return camera.orthographicSize;
        }
    }

    public float Bottom {
        get {
            return -camera.orthographicSize;
        }
    }

    public float Left {
        get {
            return -camera.aspect * camera.orthographicSize;
        }
    }

    public float Right {
        get {
            return camera.aspect * camera.orthographicSize;
        }
    }

    public bool IsBelowBottom(IInteractiveObject interactiveObject) {
        if (interactiveObject.Position.y < Bottom - interactiveObject.Size.y) {
            return false;
        }
        return true;
    } 

    public bool IsOnScreen(IInteractiveObject interactiveObject) {
        return interactiveObject.Position.y < Top;
    } 
}
