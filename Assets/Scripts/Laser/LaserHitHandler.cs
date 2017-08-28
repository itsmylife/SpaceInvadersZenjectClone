using System;
using UnityEngine;

public class LaserHitHandler {
    private readonly Settings settings;
    private readonly LaserFacade laser;
    private readonly LaserFacade.Pool laserPool;

    public LaserHitHandler(
        Settings settings,
        LaserFacade laser,
        LaserFacade.Pool laserPool

    ) {
        this.settings = settings;
        this.laserPool = laserPool;
        this.laser = laser;
    }

    public void LaserHit(Collider2D other) {
        var hit = other.GetComponent<IDamageable>();
        if (hit != null) {
            if (laser.Type == LaserType.ShipLaser && other.tag != "Ship" ||
                laser.Type == LaserType.EnemyLaser && other.tag == "Ship") {
                hit.TakeDamage(laser.HitPoint);
            }
            Debug.Log("Laser hit Sound!");
            laserPool.Despawn(laser);
        }
    }

    [Serializable]
    public class Settings {
        public AudioClip LaserHitSound;
        public float LaserHitSoundVolume = 1f;
    }
}


