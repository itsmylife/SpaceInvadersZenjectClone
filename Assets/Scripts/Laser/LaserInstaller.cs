using System;
using Zenject;
using UnityEngine;

public class LaserInstaller : MonoInstaller<LaserInstaller> {
    [SerializeField]
    public Settings settings = null;

    public override void InstallBindings() {
        Container.Bind<LaserTunables>().AsSingle();
        Container.Bind<LaserHitHandler>().AsSingle();
        Container.Bind<Laser>().AsSingle()
            .WithArguments(
                settings.RootObject, 
                settings.SpriteRenderer,
                settings.ShipLaserSprite,
                settings.EnemyLaserSprite
            );
    }

    [Serializable]
    public class Settings
    {
        public GameObject RootObject;
        public SpriteRenderer SpriteRenderer;
        public Sprite ShipLaserSprite;
        public Sprite EnemyLaserSprite;
    }
}


