using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private bool _isCanAttack = true;
    public void Attack(int shotCount, float coolDown, float shotTime, GameObject damager, Transform shotPoin)
    {
        StartCoroutine(IEattack(shotCount, coolDown, shotTime, damager, shotPoin));

    }

    public bool CanAtack() 
    {
        return _isCanAttack;
    }

    public IEnumerator IEattack(int shotCount, float coolDown, float shotTime, GameObject damager, Transform shotPoin)
    {
        _isCanAttack = false;

        for (int i = 0; i < shotCount; i++)
        {
            yield return new WaitForSeconds(shotTime);
            Instantiate(damager, shotPoin.position, shotPoin.rotation);
                

        }

        yield return new WaitForSeconds(coolDown);

        _isCanAttack = true;
        yield return null;
    }
}
