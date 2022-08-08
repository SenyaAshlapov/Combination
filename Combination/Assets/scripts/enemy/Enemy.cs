using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp;
    public void GetDamage(float damage){
        Debug.Log(damage);
        hp -= damage;
        if(hp <= 0)
            Destroy(this.gameObject);
    }
}
