using System;
using UnityEngine;

public class AsteroidMoveHandler : Zenject.IFixedTickable {
    private IAsteroid asteroid;
    private AsteroidFacade asteroidFacade;
    private AsteroidFacade.Pool selfFactory;
    private ScreenBoundary screenBoundary;

    public AsteroidMoveHandler(
        IAsteroid asteroid,
        AsteroidFacade asteroidFacade,
        AsteroidFacade.Pool selfFactory,
        ScreenBoundary screenBoundary
    ) {
        this.asteroid = asteroid;
        this.asteroidFacade = asteroidFacade;
        this.selfFactory = selfFactory;
        this.screenBoundary = screenBoundary;
    }

    public void FixedTick() {
        var newPosition = asteroid.Position;
        newPosition.y -= asteroid.Tunables.Speed * Time.fixedDeltaTime; 
        asteroid.Position = newPosition;

        if (!isOnScreen()) {
            selfFactory.Despawn(asteroidFacade);
        }
    }


    private bool isOnScreen() {
        if (asteroid.Position.y < screenBoundary.Bottom - asteroid.Size.y) {
            return false;
        }
        return true;
    }

}


