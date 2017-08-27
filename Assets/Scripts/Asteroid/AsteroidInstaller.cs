using System;
using UnityEngine;
using Zenject;

public class AsteroidInstaller : MonoInstaller<AsteroidInstaller> {
    [SerializeField]
    private Settings settings = null;
    
    public override void InstallBindings() {
        Container.Bind<AsteroidTunables>().AsSingle();

        Container.BindInterfacesTo<Asteroid>()
            .AsSingle()
            .WithArguments(
                settings.RootObject,
                settings.Rigidbody2D, 
                settings.Collider2D,
                settings.SpriteRenderer
        );

        Container.BindInterfacesTo<AsteroidRotationHandler>().AsSingle();
        Container.BindInterfacesTo<AsteroidMoveHandler>().AsSingle();
    }

    [Serializable]
    public class Settings {
        public GameObject RootObject;
        public Rigidbody2D Rigidbody2D;
        public Collider2D Collider2D;
        public SpriteRenderer SpriteRenderer;
    }

}