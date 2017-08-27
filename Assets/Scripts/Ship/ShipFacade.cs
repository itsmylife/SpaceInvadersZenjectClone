using UnityEngine;
using Zenject;

public class ShipFacade : MonoBehaviour {

    private Ship ship;
	
    [Inject]
    public void Construct(Ship ship) {
        this.ship = ship;
    }


    public void TakeDamage(int damageAmount) {
        Debug.Log("Health Lose - Taken damage: " + damageAmount + " - " + ship.ToString());
    }
}
