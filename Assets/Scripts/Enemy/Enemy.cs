using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MovableObject, IEnemy {
    private EnemyTunables enemyTunables;

    public Enemy(
        GameObject rootObject,
        Rigidbody2D rigidBody2d, 
        Collider2D collider2d, 
        SpriteRenderer spriteRenderer,
        EnemyTunables enemyTunables
    ) : base(
        rootObject, 
        rigidBody2d,
        collider2d,
        spriteRenderer
    ) {
        this.enemyTunables = enemyTunables;
    }

    public EnemyTunables Tunables {
        get {
            return enemyTunables;
        }
        set {
            enemyTunables = value;
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
}
