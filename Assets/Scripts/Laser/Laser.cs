using System;
using Zenject;
using UnityEngine;

public enum LaserType {
    ShipLaser,
    EnemyLaser
}


public class Laser : MonoBehaviour {

    [SerializeField]
    private SpriteRenderer SpriteRenderer;

    [SerializeField]
    private Sprite ShipLaserSprite;

    [SerializeField]
    private Sprite EnemyLaserSprite;

    [Inject]
    private ScreenBoundary screenBoundary;

    [Inject]
    private Pool laserPool;

    private LaserTunables tunables;

    public void ReInit(LaserTunables tunables) {
        Debug.Log("Started to live");
        this.tunables = tunables;
    }

    public void OnTriggerEnter(Collider other) {
        Debug.Log("hit!");
    }

    private void Update() {
        Debug.Log("I am laser " + this.tunables.Type);
        if (tunables.Type == LaserType.ShipLaser) {
            var newPosition = this.transform.position;
            newPosition.y += Time.fixedDeltaTime * tunables.Velocity; 
            this.transform.position = newPosition;
        }

        if (this.transform.position.y < screenBoundary.Bottom ||
            this.transform.position.y > screenBoundary.Top) {
            laserPool.Despawn(this);
        }
    }


    public class Pool : MonoMemoryPool<LaserTunables, Laser> {
        protected override void Reinitialize(LaserTunables laserTunables, Laser laser) {
            base.Reinitialize(laserTunables, laser);
            laser.transform.position = laserTunables.SpawnPoint;
            laser.ReInit(laserTunables);
        }
    }
}


