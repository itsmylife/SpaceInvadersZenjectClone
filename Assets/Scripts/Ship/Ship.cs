using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MovableObject, IInteractiveObject {

    private readonly GameObject holdDownMessage;
    private readonly Transform laserSpawnPoint;

    public Ship(
        GameObject rootObject,
        Rigidbody2D rigidBody2d,
        Collider2D collider2d,
        SpriteRenderer spriteRenderer,
        GameObject holdDownMessage,
        Transform spawnPoint
    ) : base(
            rootObject,
            rigidBody2d,
            collider2d,
            spriteRenderer
        ) {

        this.holdDownMessage = holdDownMessage;
        this.laserSpawnPoint = spawnPoint;
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

    public Transform LaserSpawnPoint {
        get {
            return laserSpawnPoint;
        }
    }


    public void HideHoldDownMessage() {
        if (!holdDownMessage.activeSelf) {
            return;
        }
        holdDownMessage.SetActive(false);
    }
}