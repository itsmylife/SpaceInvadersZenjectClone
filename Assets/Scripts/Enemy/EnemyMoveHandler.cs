﻿using System;
using UnityEngine;

public class EnemyMoveHandler : Zenject.IFixedTickable {

    private readonly Enemy enemy;
    private readonly EnemyFacade enemyFacade;
    private readonly EnemyFacade.Pool enemyFactory;
    private readonly ScreenBoundary screenBoundary;

    public EnemyMoveHandler(
        Enemy enemy,
        EnemyFacade enemyFacade,
        EnemyFacade.Pool enemyFactory,
        ScreenBoundary screenBoundary
    ) {
        this.enemy = enemy;
        this.enemyFacade = enemyFacade;
        this.enemyFactory = enemyFactory;
        this.screenBoundary = screenBoundary;
    }

    public void FixedTick() {
        var newPosition = enemy.Position;
        newPosition.y -= enemy.Tunables.Speed * Time.fixedDeltaTime;
        enemy.Position = newPosition;

        if (!screenBoundary.IsBelowBottom(enemy)) {
            enemyFactory.Despawn(enemyFacade);
        }
    }

}
