using System;
using UnityEngine;

public interface IAsteroid : IInteractiveObject {
    AsteroidTunables Tunables { get; set; }

    void Rotate(Vector3 eulerAngles);
}


