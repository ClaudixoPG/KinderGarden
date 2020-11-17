using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public float totalTime;
    [SerializeField]
    private float timer;
    protected bool paused;
    [SerializeField]
    protected bool inited;
    public UnityEvent OnFinish;
    public UnityEvent OnInit;
    public UnityEvent OnTick;


    // Start is called before the first frame update
    void Start()
    {
        OnFinish = new UnityEvent();
        OnInit = new UnityEvent();
        OnTick = new UnityEvent();
        timer = 0;
        //Init();
    }

    // Update is called once per frame

    void Update()
    {
        if (inited)
        {
            if (!paused)
            {
                timer += Time.deltaTime;
                if (timer >= totalTime)
                {
                    Finish();
                }
                else
                {
                    OnTick?.Invoke();
                }
            }
        }
    }

    public void Restart()
    {
        timer = 0;
        Init();
    }

    public virtual void Init()
    {
        inited = true;
        OnInit?.Invoke();
    }

    public virtual void Finish()
    {
        inited = false;
        OnFinish?.Invoke();
    }

    public int ElapsedMin()
    {
        return (int)timer / 60;
    }

    public int ElapsedSec()
    {
        return (int)timer % 60;
    }

    public int ElapsedMillis()
    {
        return (int)(100 * (timer - (int)timer));
    }

    public int ContdownMin()
    {
        float cd = totalTime - timer;
        return (int)cd / 60;
    }

    public int ContdownSec()
    {
        float cd = totalTime - timer;
        return (int)cd % 60;
    }

    public int ContodownMillis()
    {
        float cd = totalTime - timer;
        return (int)(100 * (cd - (int)cd));
    }

}
