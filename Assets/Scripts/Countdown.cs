using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown
{
    private float countdownTime;
    private float finishTime;
    private float remainTime;
    private bool isPause;


    public bool IsPause => isPause;
    public float Remain => isPause ? remainTime : Mathf.Max(finishTime - Time.time, 0);
    public float Remain01 => Remain / countdownTime;


    public Countdown(float time)
    {
        countdownTime = time;
        Start();
        Pause();
    }


    public void Start()
    {
        isPause = false;
        finishTime = Time.time + countdownTime;
    }


    public void Resume()
    {
        if(!isPause) 
            return;
        
        isPause = false;
        finishTime = remainTime + Time.time;
    }


    public void Pause()
    {
        if (isPause) 
            return;

        isPause = true;
        remainTime = finishTime - Time.time;
    }


    public void Reset()
    {
        Start();
        Pause();
    }


    public void Reset(float newTime)
    {
        countdownTime = newTime;
        Reset();
    }
}
