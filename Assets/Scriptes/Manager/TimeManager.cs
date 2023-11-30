using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] float currentTime;

    [SerializeField] Text timerText;

    int minute;
    int second;

    private void Start()
    {
        currentTime = time;

        StartCoroutine(StartTimer());
    }

    IEnumerator StartTimer()
    {
        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;

            minute = (int)currentTime / 60;

            second = (int)currentTime % 60;

            timerText.text = $"{minute.ToString("00")} : {second.ToString("00")}";

            yield return null;
        }

        currentTime = 0;

        yield return null;
    }
}
