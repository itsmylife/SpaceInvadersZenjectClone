using System;
using UnityEngine;

public abstract class MovableObject : IMovableObject {
    protected readonly GameObject rootObject;
    protected readonly Rigidbody2D rigidBody2d;
    protected readonly Collider2D collider2d;
    protected readonly SpriteRenderer spriteRenderer;

    public MovableObject(
        GameObject rootObject,
        Rigidbody2D rigidBody2d, 
        Collider2D collider2d, 
        SpriteRenderer spriteRenderer
    ) {
        this.rootObject = rootObject;
        this.rigidBody2d = rigidBody2d;
        this.collider2d = collider2d;
        this.spriteRenderer = spriteRenderer;
    }

    public GameObject RootObject {
        get {
            return rootObject;
        }
    }
       
    public Rigidbody2D RigidBody2d {
        get {
            return rigidBody2d;
        }
    }

    public Collider2D Collider2d {
        get {
            return collider2d;
        }
    }

    public SpriteRenderer SpriteRenderer {
        get {
            return spriteRenderer;
        }
    }
}
