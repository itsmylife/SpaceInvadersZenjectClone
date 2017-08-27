using System;
using UnityEngine;

public class Asteroid : MovableObject, IAsteroid {
    private AsteroidTunables asteroidTunables;


    public Asteroid(
        GameObject rootObject,
        Rigidbody2D rigidBody2d, 
        Collider2D collider2d, 
        SpriteRenderer spriteRenderer,
        AsteroidTunables asteroidTunables
    ) : base(
            rootObject, 
            rigidBody2d,
            collider2d,
            spriteRenderer
        ) {
        this.asteroidTunables = asteroidTunables;
    }

    public AsteroidTunables Tunables {
        get {
            return asteroidTunables;
        }
        set {
            asteroidTunables = value;
        }
    }

    public Vector3 Position {
        get {
            return rigidBody2d.transform.position;
        }
        set {
            rigidBody2d.transform.position = value;
        }
    }

    public Vector3 Size {
        get {
            return spriteRenderer.bounds.size;
        }
    }

    public void Rotate(Vector3 eulerAngles) {
        rigidBody2d.transform.Rotate(eulerAngles);
    }



    public enum RotationDirection {
        CLOCKWISE = 1,
        COUNTER_CLOCKWISE = -1,
    }
}
