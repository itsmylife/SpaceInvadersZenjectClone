using System;
using UnityEngine;
using Zenject;

public class GameInstaller: MonoInstaller<GameInstaller> {
    [Inject]
    private Settings _settings = null;

    public override void InstallBindings() {
        Container.Bind<ScreenBoundary>().AsSingle();
        Container.BindInterfacesTo<AsteroidSpawner>().AsSingle();

        Container.BindMemoryPool<AsteroidFacade, AsteroidFacade.Pool>()
            .WithInitialSize(5).ExpandByDoubling()
            .FromSubContainerResolve()
            .ByNewPrefab(_settings.AsteroidPrefab)
            .UnderTransformGroup("Asteroids");

        Container.BindMemoryPool<Laser, Laser.Pool>()
            .WithInitialSize(10).ExpandByDoubling()
            .FromComponentInNewPrefab(_settings.LaserPrefab)
            .UnderTransformGroup("Lasers");


        Container.DeclareSignal<StartShootingSignal>();
    }

    [Serializable]
    public class Settings {
        public GameObject AsteroidPrefab;
        public GameObject LaserPrefab;
    }
}