using UnityEngine;
using Zenject;

public class ShipInstaller : MonoInstaller<ShipInstaller> {
    [SerializeField]
    private Settings settings = null;

    public override void InstallBindings() {
        Container.Bind<Ship>().AsSingle()
            .WithArguments(
            settings.RootObject,
            settings.Rigidbody2D,
            settings.Collider2D,
            settings.SpriteRenderer,
            settings.HoldDownMessage,
            settings.LaserSpawnPoint
        );
        Container.BindInterfacesTo<ShipMoveHandler>().AsSingle();
        Container.BindInterfacesTo<ShipLaserHandler>().AsSingle();
    }

    [System.Serializable]
    public class Settings {
        public GameObject RootObject;
        public Rigidbody2D Rigidbody2D;
        public Collider2D Collider2D;
        public SpriteRenderer SpriteRenderer;
        public GameObject HoldDownMessage;
        public Transform LaserSpawnPoint;
    }
}