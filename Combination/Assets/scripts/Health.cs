using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]private HealthData _healthData;

    void OnCollisionEnter(Collision other){
        if(other.gameObject.GetComponent<Player>()){
            other.gameObject.GetComponent<Player>().InitHealth(_healthData);
            Destroy(this.gameObject);
        }
    }
}
