using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour {

    public int clipSize;
    public int reloadTime;
    public int damage;
    public float range;

    public abstract void Shoot();
}
