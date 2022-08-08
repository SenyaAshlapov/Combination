using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField]private float _speed;
    [SerializeField]private float _damage;

    [SerializeField]private Rigidbody _damagerRigidbody;

    private void FixedUpdate() {
        _damagerRigidbody.velocity = _speed * transform.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Enemy>()){
            other.gameObject.GetComponent<Enemy>().GetDamage(_damage);
            Destroy(this.gameObject);
        }
       
    }
}
