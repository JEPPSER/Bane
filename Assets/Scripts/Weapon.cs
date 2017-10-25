using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour {

    public int clipSize;
    public int reloadTime;
    public int damage;
    public float range;

    public abstract void Shoot();

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Soldier(Clone)")
        {
            if (Input.GetKeyDown("f"))
            {
                other.GetComponentInParent<SoldierController>().pickUpWeapon(this);
                Physics2D.IgnoreCollision(other, GetComponent<Collider2D>());
            }   
        }
    }
}
