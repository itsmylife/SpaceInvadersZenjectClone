using System;
using Zenject;
using UnityEngine;
using ModestTree;
using ModestTree.Util;


public class ShipLaserHandler : IInitializable, IFixedTickable {
    private readonly Ship ship;
    private readonly Settings settings;
    private readonly LaserFacade.Pool laserPool;
    private readonly ShipCommonSettings shipCommonSettings;

    private StartShootingSignal startShootingSignal;

    private float lastShootTime;
    private bool shootingAllowed = false;

    public ShipLaserHandler(
        Ship ship,
        Settings settings,
        LaserFacade.Pool laserPool,
        StartShootingSignal startShootingSignal,
        ShipCommonSettings shipCommonSettings
    ) {
        this.ship = ship;
        this.settings = settings;
        this.laserPool = laserPool;
        this.startShootingSignal = startShootingSignal;
        this.shipCommonSettings = shipCommonSettings;
    }

    public void Initialize() {
        startShootingSignal += OnStartShootingSignalFired;
    }

    private void OnStartShootingSignalFired() {
        startShootingSignal -= OnStartShootingSignalFired;
        shootingAllowed = true;
    }

    public void FixedTick() {
        if (!shootingAllowed) {
            return;
        }

        if (Time.realtimeSinceStartup - lastShootTime > settings.MinDelayBetweenShoots) {
            lastShootTime = Time.realtimeSinceStartup;
            Shoot();
        }
    }


    private void Shoot() {
        var tunables = new LaserTunables {
            Type = LaserType.ShipLaser,
            SpawnPoint = ship.LaserSpawnPoint.position,
            Velocity = settings.Velocity,
            HitPoint = shipCommonSettings.HitPoint
        };
        laserPool.Spawn(tunables);
        Debug.Log("Ship: Pew pew!");
    }



    [System.Serializable]
    public class Settings {
        public float MinDelayBetweenShoots;
        public int Velocity;
    }
}
