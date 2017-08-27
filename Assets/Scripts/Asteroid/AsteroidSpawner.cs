using System;
using Zenject;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawner : ITickable, IInitializable {
    private readonly Settings settings;
    private readonly AsteroidCommonSettings asteroidCommonSettings;
    private readonly ScreenBoundary screenBoundary;
    private readonly AsteroidFacade.Pool asteroidFactory;

    private int spawnedAsteroidCount;
    private float lastSpawnTime;


    public AsteroidSpawner(
        Settings settings, 
        AsteroidCommonSettings asteroidCommonSettings,
        ScreenBoundary screenBoundary,
        AsteroidFacade.Pool asteroidFactory

    ) {
        this.settings = settings;
        this.asteroidCommonSettings = asteroidCommonSettings;
        this.screenBoundary = screenBoundary;
        this.asteroidFactory = asteroidFactory;
    }

    public void Initialize() {
        // signal integration (maybe?)
    }

    public void Tick() {
        if (spawnedAsteroidCount < settings.MaxAsteroidCount &&
            Time.realtimeSinceStartup - lastSpawnTime > settings.MinDelayBetweenSpawns) {
            SpawnAsteroid();
            spawnedAsteroidCount++;
        }
    }

    private void SpawnAsteroid() {
        var tunables = CreateRandomAsteroidSettings();
        var asteroid = asteroidFactory.Spawn(tunables);
        asteroid.Position = ChooseRandomSpawnPosition(asteroid.Size);
        lastSpawnTime = Time.realtimeSinceStartup;
    }

    private AsteroidTunables CreateRandomAsteroidSettings() {
        var rotationDirection = Random.Range(0f, 1f) >= 0.5f 
            ? Asteroid.RotationDirection.CLOCKWISE
            : Asteroid.RotationDirection.COUNTER_CLOCKWISE;
        return new AsteroidTunables() {
            RotationDirection = rotationDirection,
            RotationVelocity = Random.Range(settings.MinRotationVelocity, settings.MaxRotationVelocity),
            Speed = Random.Range(settings.MinVelocity, settings.MaxVelocity),
            Health = asteroidCommonSettings.Health,
            HitPoint = asteroidCommonSettings.HitPoint,
            Score = asteroidCommonSettings.Score
        };
    }

    private Vector3 ChooseRandomSpawnPosition(Vector3 asteroidSize) {
        var topPadding = asteroidSize.y;
        var sidePadding = asteroidSize.x;
        return new Vector3(
            UnityEngine.Random.Range(screenBoundary.Left + sidePadding, screenBoundary.Right - sidePadding),
            screenBoundary.Top + topPadding,
            0
        );
    }


    [Serializable]
    public class Settings {
        public float MinVelocity;
        public float MaxVelocity;
        public float MinRotationVelocity;
        public float MaxRotationVelocity;
        public float MinDelayBetweenSpawns;
        public int MaxAsteroidCount;
    }
}
