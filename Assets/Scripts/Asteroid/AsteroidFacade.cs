using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AsteroidFacade : MonoBehaviour {
    private IAsteroid asteroid;


    [Inject]
    public void Construct(
        IAsteroid asteoid
    ) {
        this.asteroid = asteoid;
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
     
    public void Die() {
        Debug.Log("it should die!");
        // TODO implement
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
