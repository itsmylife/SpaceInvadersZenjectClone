using System;
using Zenject;
using UnityEngine;

public class EnemyLaserHandler : IFixedTickable {
    private readonly EnemyCommonSettings enemyCommonSettings;
    private readonly LaserFacade.Pool laserPool;   
    private readonly Settings settings;
    private readonly Enemy enemy;
    private readonly ScreenBoundary screenBoundary;

    private float lastShootTime;

    public EnemyLaserHandler(
        Enemy enemy,
        Settings settings,
        LaserFacade.Pool laserPool,
        ScreenBoundary screenBoundary,
        EnemyCommonSettings enemyCommonSettings
    ) {
        this.enemy = enemy;
        this.settings = settings;
        this.laserPool = laserPool;
        this.screenBoundary = screenBoundary;
        this.enemyCommonSettings = enemyCommonSettings;
    }

    public void FixedTick() {
        if (Time.realtimeSinceStartup - lastShootTime > settings.MinDelayBetweenShoots &&
            screenBoundary.IsOnScreen(enemy)
        ) {
            lastShootTime = Time.realtimeSinceStartup;
            Shoot();
        }
    }
    private void Shoot() {
        var tunables = new LaserTunables {
            Type = LaserType.EnemyLaser,
            SpawnPoint = enemy.LaserSpawnPoint.position,
            Velocity = -settings.Velocity,
            HitPoint = enemyCommonSettings.HitPoint
        };
        laserPool.Spawn(tunables);
        Debug.Log("Enemy: Pew pew!");
    }

    [Serializable]
    public class Settings {
        public float MinDelayBetweenShoots;
        public int Velocity;
    }

}


