using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovableObject {

    GameObject RootObject { get; }
    Rigidbody2D RigidBody2d { get; }
    Collider2D Collider2d { get; }
    SpriteRenderer SpriteRenderer { get; }
}