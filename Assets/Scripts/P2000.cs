using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2000 : Weapon {

    public void Start()
    {
        this.clipSize = 15;
        this.damage = 30;
        this.reloadTime = 3000;
        this.range = 2000;
    }

    public override void Shoot()
    {
        Debug.Log("Bang");
    }
}
