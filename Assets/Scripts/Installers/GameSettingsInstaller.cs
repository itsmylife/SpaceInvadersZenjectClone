using System;
using UnityEngine;
using Zenject;

//[CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]
public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller> {
    public GameInstaller.Settings GameInstallerSettings;
    public AsteroidSpawner.Settings AsteroidSpawnerSettings;

    public AsteroidSettings Asteroid;
    public ShipSettings Ship;

    
    [Serializable]
    public class AsteroidSettings {
        public AsteroidCommonSettings AsteroidCommonSettings;
    }

    [Serializable]
    public class ShipSettings {
        public ShipCommonSettings ShipCommonSettings;
        public ShipLaserHandler.Settings ShipLaserSettings;
    }


    public override void InstallBindings() {
        Container.BindInstance(GameInstallerSettings);
        Container.BindInstance(AsteroidSpawnerSettings);

        Container.BindInstance(Asteroid.AsteroidCommonSettings);
        Container.BindInstance(Ship.ShipCommonSettings);
        Container.BindInstance(Ship.ShipLaserSettings);
    }
    
}