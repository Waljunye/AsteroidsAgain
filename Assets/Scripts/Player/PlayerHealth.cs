using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids.Interfaces;
public class PlayerHealth : IHealth
{
    private GameObject _hittableUnit;
    public float HP { get; private set; }
    public PlayerHealth(float startHP, GameObject unit)
    {
        HP = startHP;
        _hittableUnit = unit;
    }
    

    public void GetHit()
    {
        if(HP <= 0)
        {
            Object.Destroy(_hittableUnit);
        }
        else
        {
            HP--;
        }
    }

}
