using System.Collections.Generic;
using UnityEngine;

public class EnvourmentSpawner : MonoBehaviour
{
    [SerializeField]private List<GameObject> _envourments = new List<GameObject>();


    private void Start() {
        spawnEnvorment();
    }
    private void spawnEnvorment(){
        int randomEnvourment = Random.Range(0, _envourments.Count);
        float spawnShance = Random.Range(0,1f);

        if(spawnShance >= 0.4f)
            Instantiate(_envourments[randomEnvourment], transform.position, transform.rotation);

    }
}
