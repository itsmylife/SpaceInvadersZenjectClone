using System;
using Zenject;
using UnityEngine;

public class LaserFacade : MonoBehaviour {
    
    private Laser laser;
    private Pool laserPool;
    private LaserTunables laserTunables;
    private ScreenBoundary screenBoundary;
    private LaserHitHandler laserHitHandler;


    [Inject]
    public void Construct(
        Laser laser,
        Pool laserPool,
        ScreenBoundary screenBoundary,
        LaserHitHandler laserHitHandler
    ) {
        this.laser = laser;
        this.laserPool = laserPool;
        this.screenBoundary = screenBoundary;
        this.laserHitHandler = laserHitHandler;
    }

    public LaserType Type {
        get {
            return laserTunables.Type;
        }
    }

    public int HitPoint {
        get {
            return laserTunables.HitPoint;
        }
    }

    public void ReInit(LaserTunables tunables) {
        this.laserTunables = tunables;
        laser.ChangeType(tunables.Type);
    }


    public void OnTriggerEnter2D(Collider2D other) {
        laserHitHandler.LaserHit(other);
    }


    private void Update() {
        if (laserTunables.Type == LaserType.ShipLaser) {
            var newPosition = this.transform.position;
            newPosition.y += Time.fixedDeltaTime * laserTunables.Velocity; 
            this.transform.position = newPosition;
        }

        if (this.transform.position.y < screenBoundary.Bottom ||
            this.transform.position.y > screenBoundary.Top) {
            laserPool.Despawn(this);
        }
    }

    public class Pool : MonoMemoryPool<LaserTunables, LaserFacade> {
        protected override void Reinitialize(LaserTunables laserTunables, LaserFacade laser) {
            base.Reinitialize(laserTunables, laser);
            laser.transform.position = laserTunables.SpawnPoint;
            laser.ReInit(laserTunables);
        }
    }
}


