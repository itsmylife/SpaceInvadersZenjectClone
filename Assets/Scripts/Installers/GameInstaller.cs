using System;
using UnityEngine;
using Zenject;

public class GameInstaller: MonoInstaller<GameInstaller> {
    [Inject]
    private Settings settings = null;

    public override void InstallBindings() {
        Container.Bind<ScreenBoundary>().AsSingle();
        Container.BindInterfacesTo<AsteroidSpawner>().AsSingle();
        Container.BindInterfacesTo<EnemySpawner>().AsSingle();

        Container.BindMemoryPool<AsteroidFacade, AsteroidFacade.Pool>()
            .WithInitialSize(5).ExpandByDoubling()
            .FromSubContainerResolve()
            .ByNewPrefab(settings.AsteroidPrefab)
            .UnderTransformGroup("Asteroids");

        Container.BindMemoryPool<EnemyFacade, EnemyFacade.Pool>()
            .WithInitialSize(5).ExpandByDoubling()
            .FromSubContainerResolve()
            .ByNewPrefab(settings.EnemyPrefab)
            .UnderTransformGroup("Enemies");

        Container.BindMemoryPool<LaserFacade, LaserFacade.Pool>()
            .WithInitialSize(10).ExpandByDoubling()
            .FromSubContainerResolve()
            .ByNewPrefab(settings.LaserPrefab)
            .UnderTransformGroup("Lasers");


        Container.DeclareSignal<StartShootingSignal>();
    }

    [Serializable]
    public class Settings {
        public GameObject EnemyPrefab;
        public GameObject AsteroidPrefab;
        public GameObject LaserPrefab;
    }
}