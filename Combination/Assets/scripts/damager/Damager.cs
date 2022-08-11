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
    [SerializeField]private float _speed;
    [SerializeField]private float _damage;
    [SerializeField]private Rigidbody _damagerRigidbody;
    [SerializeField]private bool _isExplosion;
    [SerializeField]private float _explosionForce;
    [SerializeField]private float _explosionRadius;
    [SerializeField]private GameObject _destroyParticle;
    [SerializeField]private GameObject _explosionParticle;

    private void Update() {
        _damagerRigidbody.velocity = _speed * transform.forward ;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(_type == Type.Enemy)
        {
            if(other.gameObject.GetComponent<Enemy>())
            {
                other.gameObject.GetComponent<Enemy>().GetDamage(_damage);
                
                if(_isExplosion == true)
                    Instantiate(_explosionParticle, transform.position, transform.rotation);
                    explode();               
            }
        }   

        else if(_type == Type.Player)
        {
            if(other.gameObject.GetComponent<Player>())
            {
                other.gameObject.GetComponent<Player>().GetDamage(_damage);

                if(_isExplosion == true)
                    Instantiate(_explosionParticle, transform.position, transform.rotation);
                    explode();              
            }
        } 
        Instantiate(_destroyParticle, transform.position, transform.rotation);
        Destroy(this.gameObject);   

         
    }

    private void explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius);

        for(int i = 0; i < colliders.Length; i++){
            Rigidbody rigidbody = colliders[i].attachedRigidbody;
            if(rigidbody){
                rigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            }
        }

        
    }
}
