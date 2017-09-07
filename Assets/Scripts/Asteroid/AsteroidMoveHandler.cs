using System;
using UnityEngine;

public class AsteroidMoveHandler : Zenject.IFixedTickable {
    private readonly IAsteroid asteroid;
    private readonly AsteroidFacade asteroidFacade;
    private readonly AsteroidFacade.Pool asteroidFactory;
    private readonly ScreenBoundary screenBoundary;

    public AsteroidMoveHandler(
        IAsteroid asteroid,
        AsteroidFacade asteroidFacade,
        AsteroidFacade.Pool asteroidFactory,
        ScreenBoundary screenBoundary
    ) {
        this.asteroid = asteroid;
        this.asteroidFacade = asteroidFacade;
        this.asteroidFactory = asteroidFactory;
        this.screenBoundary = screenBoundary;
    }

    public void FixedTick() {
        var newPosition = asteroid.Position;
        newPosition.y -= asteroid.Tunables.Speed * Time.fixedDeltaTime; 
        asteroid.Position = newPosition;

        if (!screenBoundary.IsOnScreen(asteroid)) {
            asteroidFactory.Despawn(asteroidFacade);
        }
    }
}


