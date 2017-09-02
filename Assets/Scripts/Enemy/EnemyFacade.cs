using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyFacade : MonoBehaviour {

    private IEnemy enemy;
    private Pool enemyPool;

    private int currentHealth;


    [Inject]
    public void Construct(
        IEnemy enemy,
        Pool enemyPool
    ) {
        this.enemy = enemy;
        this.enemyPool = enemyPool;
        currentHealth = enemy.Tunables.Health;
    }


    public Vector3 Position {
        get {
            return enemy.Position;
        }
        set {
            enemy.Position = value;
        }
    }

    public Vector3 Size {
        get {
            return enemy.Size;
        }
    }

    public void TakeDamage(int damageAmount) {
        currentHealth -= damageAmount;

        if (currentHealth <= 0) {
            // TODO asteroidExplodedSignal.Fire(asteroidCommonSettings, asteroid.Position);
            enemyPool.Despawn(this);
        }
    }

    public void ResetTunables(EnemyTunables newTunables) {
        enemy.Tunables = newTunables;
    }

    public class Pool : MonoMemoryPool<EnemyTunables, EnemyFacade> {
        protected override void Reinitialize(
            EnemyTunables tunables, 
            EnemyFacade enemyFacade
        ) {
            enemyFacade.ResetTunables(tunables);
        }
    }
}
