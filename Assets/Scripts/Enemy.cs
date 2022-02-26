using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlurredObjects;

public class Enemy : BlurredObject
{
    private void Awake()
    {
        OnGotShot += HandleOnGotShot;
    }
    public void HandleOnGotShot()
    {
        KillEnemy();
    }

    private void KillEnemy()
    {
        print("Enemy killed");
    }
}
