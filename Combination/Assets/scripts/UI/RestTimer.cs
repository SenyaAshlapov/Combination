using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestTimer : MonoBehaviour
{
    [SerializeField]private Image _timerLine;
    [SerializeField]private GameObject _timer;

    private void Awake() {
        WaveSpawner.ActivateTimer += startTimer;
    }

    private void OnDestroy() {
        WaveSpawner.ActivateTimer -= startTimer;
    }
    private void startTimer(float time)
    {
        _timer.SetActive(true);
        StartCoroutine(IEtimer(time));
    }
    private IEnumerator IEtimer(float time){
        _timerLine.fillAmount = 1;
        float duration = time;

        while(duration > 0)
        {
            duration -= Time.deltaTime;
            _timerLine.fillAmount = duration/time;
            yield return new WaitForSeconds(Time.deltaTime * 0.55f);
        }
        _timer.SetActive(false);
        yield return null;
    }



    
}
