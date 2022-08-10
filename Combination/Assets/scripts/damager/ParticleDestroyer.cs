using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroyer : MonoBehaviour
{
   [SerializeField]private float _timeToDestroy;
    void Start()
    {
        StartCoroutine(IEdestroyer());
    }


    private IEnumerator IEdestroyer()
    {
        yield return new WaitForSeconds(_timeToDestroy);

        Destroy(this.gameObject);
    }
}
