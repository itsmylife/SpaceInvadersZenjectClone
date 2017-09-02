using Zenject;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner :  ITickable, IInitializable {
    private readonly Settings settings;
    private readonly ScreenBoundary screenBoundary;
    private readonly EnemyFacade.Pool enemyFactory;
    private readonly EnemyCommonSettings enemyCommonSettings;

    private int spawnedEnemyCount;
    private float lastSpawnTime;


    public EnemySpawner(
        Settings settings, 
        EnemyCommonSettings enemyCommonSettings,
        ScreenBoundary screenBoundary,
        EnemyFacade.Pool enemyFactory
    ) {
        this.settings = settings;
        this.enemyCommonSettings = enemyCommonSettings;
        this.screenBoundary = screenBoundary;
        this.enemyFactory = enemyFactory;
    }

    public void Initialize() {
        // signal integration (maybe?)
    }

    public void Tick() {
        if (spawnedEnemyCount < settings.MaxEnemyCount &&
            Time.realtimeSinceStartup - lastSpawnTime > settings.MinDelayBetweenSpawns) {
            SpawnEnemy();
            spawnedEnemyCount++;
        }
    }

    private void SpawnEnemy() {
        var tunables = CreateRandomEnemySettings();
        var enemy = enemyFactory.Spawn(tunables);
        enemy.Position = ChooseRandomSpawnPosition(enemy.Size);
        lastSpawnTime = Time.realtimeSinceStartup;
    }

    private EnemyTunables CreateRandomEnemySettings() {
        return new EnemyTunables {
            Speed = Random.Range(settings.MinVelocity, settings.MaxVelocity),
            Health = enemyCommonSettings.Health,
            HitPoint = enemyCommonSettings.HitPoint,
            Score = enemyCommonSettings.Score
        };
    }

    private Vector3 ChooseRandomSpawnPosition(Vector3 enemySize) {
        var topPadding = enemySize.y;
        var sidePadding = enemySize.x;
        return new Vector3(
            UnityEngine.Random.Range(screenBoundary.Left + sidePadding, screenBoundary.Right - sidePadding),
            screenBoundary.Top + topPadding,
            0
        );
    }

    [System.Serializable]
    public class Settings {
        public float MinVelocity;
        public float MaxVelocity;
        public float MinDelayBetweenSpawns;
        public int MaxEnemyCount;
    }
}
