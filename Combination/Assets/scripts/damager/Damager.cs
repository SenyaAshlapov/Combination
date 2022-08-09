using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    Player,
    Enemy,
    Test
}
public class Damager : MonoBehaviour
{
    [SerializeField]private Type _type;
    [SerializeField]private bool _isExplosion;
    [SerializeField]private float _speed;
    [SerializeField]private float _damage;

    [SerializeField]private Rigidbody _damagerRigidbody;

    private void FixedUpdate() {
        _damagerRigidbody.velocity = _speed * transform.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(_type == Type.Enemy)
        {
            if(other.gameObject.GetComponent<Enemy>())
            {
                other.gameObject.GetComponent<Enemy>().GetDamage(_damage);
                Destroy(this.gameObject);
            }
        }

       
    }
}
