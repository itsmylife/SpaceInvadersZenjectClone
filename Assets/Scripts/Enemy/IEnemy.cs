using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy : IInteractiveObject {
    EnemyTunables Tunables { get; set; }
}

