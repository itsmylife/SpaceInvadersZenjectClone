using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AsteroidFacade : MonoBehaviour, IDamageable {
    private IAsteroid asteroid;
    private Pool asteroidPool;
    private AsteroidCommonSettings asteroidCommonSettings;

    private int currentHealth;

    [Inject]
    public void Construct(
        IAsteroid asteoid,
        Pool asteroidPool,
        AsteroidCommonSettings asteroidCommonSettings
    ) {
        this.asteroid = asteoid;
        this.asteroidPool = asteroidPool;
        this.asteroidCommonSettings = asteroidCommonSettings;
        currentHealth = asteroidCommonSettings.Health;
    }

    public Vector3 Position {
        get {
            return asteroid.Position;
        }
        set {
            asteroid.Position = value;
        }
    }

    public Vector3 Size {
        get {
            return asteroid.Size;
        }
    }
    /*
    private void OnTriggerEnter2D(Collider2D other) {
        var laser = other.GetComponent<Laser>();
        if (laser.Type == LaserType.ShipLaser) {
            
        }
        Debug.Log("Show Explosion!");
    }
     */
    public void TakeDamage(int damageAmount) {
        currentHealth -= damageAmount;

        if (currentHealth <= 0) {
            // TODO asteroidExplodedSignal.Fire(asteroidCommonSettings, asteroid.Position);
            asteroidPool.Despawn(this);
        }
    }

    public void ResetTunables(AsteroidTunables newTunables) {
        asteroid.Tunables = newTunables;
    }

    public class Pool : MonoMemoryPool<AsteroidTunables, AsteroidFacade> {
        protected override void Reinitialize(
            AsteroidTunables tunables, 
            AsteroidFacade asteroidFacade
        ) {
            asteroidFacade.ResetTunables(tunables);
        }
    }
}
