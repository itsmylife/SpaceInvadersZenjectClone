using System;
using Zenject;
using UnityEngine;

public enum LaserType {
    ShipLaser,
    EnemyLaser
}


public class Laser {
    private GameObject rootObject;
    private SpriteRenderer spriteRenderer;
    private Sprite ShipLaserSprite;
    private Sprite EnemyLaserSprite;

    public Laser(
        GameObject rootObject,
        SpriteRenderer spriteRenderer,
        Sprite ShipLaserSprite,
        Sprite EnemyLaserSprite
    ) {
        this.rootObject = rootObject;
        this.spriteRenderer = spriteRenderer;
        this.ShipLaserSprite = ShipLaserSprite;
        this.EnemyLaserSprite = EnemyLaserSprite;
    }


    public void ChangeType(LaserType type) {
        switch (type) {
            case LaserType.ShipLaser:
                spriteRenderer.sprite = ShipLaserSprite;
                break;
            case LaserType.EnemyLaser:
                spriteRenderer.sprite = EnemyLaserSprite;
                break;
            default:
                break;
        }
    }


}


