using System;
using Zenject;
using UnityEngine;

public class ShipMoveHandler : ITickable {
    private readonly Camera camera;
    private readonly Ship ship;
    private readonly ScreenBoundary screenBoundary;
    private readonly StartShootingSignal startShootingSignal;

    private readonly float defaultTimeScale = 1f;
    private bool signalFired = false;

    public ShipMoveHandler(
        Camera camera,
        Ship ship,
        ScreenBoundary screenBoundary,
        StartShootingSignal startShootingSignal
    ) {
        this.camera = camera;
        this.ship = ship;
        this.screenBoundary = screenBoundary;
        this.startShootingSignal = startShootingSignal;
    }


    public void Tick() {
        var isMouseDown = Input.GetMouseButton(0);
        if (isMouseDown) {
            StartShooting();
            Move();
        } else {
            SlowDown();
        }
    }

    void StartShooting() {
        if (!signalFired) {
            ship.HideHoldDownMessage();
            startShootingSignal.Fire();
        }
    }

    private void Move() {
        Time.timeScale = defaultTimeScale;

        var newPosition = Input.mousePosition;
        newPosition = camera.ScreenToWorldPoint(newPosition);

        newPosition.x = Mathf.Clamp(
            newPosition.x,
            screenBoundary.Left + ship.Size.x,
            screenBoundary.Right - ship.Size.x
        );

        /*
         * TODO move ship exact mouse location
        newPosition.y = Mathf.Clamp(
            newPosition.y,
            screenBoundary.Bottom + ship.Size.y,
            screenBoundary.Top - ship.Size.y
        );
        */
        newPosition.y = ship.Position.y;

        newPosition.z = 0;

        ship.Position = newPosition;
    }

    private void SlowDown() {
        Time.timeScale = 0.2f;
    }

}


