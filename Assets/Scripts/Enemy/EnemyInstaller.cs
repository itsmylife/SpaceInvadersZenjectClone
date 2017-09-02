using UnityEngine;
using Zenject;

public class EnemyInstaller : MonoInstaller<EnemyInstaller> {
    [SerializeField]
    public Settings settings = null;

    public override void InstallBindings() {
        Container.Bind<EnemyTunables>().AsSingle();
        Container.BindInterfacesTo<Enemy>().AsSingle()
            .WithArguments(
                settings.RootObject,
                settings.Rigidbody2D, 
                settings.Collider2D,
                settings.SpriteRenderer
            );
    }

    [System.Serializable]
    public class Settings {
        public GameObject RootObject;
        public Rigidbody2D Rigidbody2D;
        public Collider2D Collider2D;
        public SpriteRenderer SpriteRenderer;
    }
}