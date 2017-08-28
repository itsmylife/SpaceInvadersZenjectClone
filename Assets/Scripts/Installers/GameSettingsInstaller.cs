using System;
using UnityEngine;
using Zenject;

//[CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]
public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller> {
    public GameInstaller.Settings GameInstallerSettings;
    public AsteroidSpawner.Settings AsteroidSpawnerSettings;

    public ShipSettings Ship;
    public AsteroidSettings Asteroid;
    public LaserSettings Laser;

    
    [Serializable]
    public class AsteroidSettings {
        public AsteroidCommonSettings AsteroidCommonSettings;
    }

    [Serializable]
    public class ShipSettings {
        public ShipCommonSettings ShipCommonSettings;
        public ShipLaserHandler.Settings ShipLaserSettings;
    }

    [Serializable]
    public class LaserSettings {
        public LaserHitHandler.Settings LaserHitHandlerSettings;
    }

    public override void InstallBindings() {
        Container.BindInstance(GameInstallerSettings);
        Container.BindInstance(AsteroidSpawnerSettings);

        Container.BindInstance(Asteroid.AsteroidCommonSettings);
        Container.BindInstance(Ship.ShipCommonSettings);
        Container.BindInstance(Ship.ShipLaserSettings);

        Container.BindInstance(Laser.LaserHitHandlerSettings);
    }
    
}