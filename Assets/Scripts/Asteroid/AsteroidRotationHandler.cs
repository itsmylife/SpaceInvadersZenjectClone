using System;
using UnityEngine;

public class AsteroidRotationHandler : Zenject.IFixedTickable {
    private IAsteroid asteroid;

    public AsteroidRotationHandler(IAsteroid asteroid) {
        this.asteroid = asteroid;
    }


    public void FixedTick() {
        var direction = (int) asteroid.Tunables.RotationDirection;
        var rotationSpeed = asteroid.Tunables.RotationVelocity;
      
        asteroid.Rotate(Vector3.back * direction * rotationSpeed * Time.fixedDeltaTime);
    }
}


