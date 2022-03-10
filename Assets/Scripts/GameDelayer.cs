using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.GenericSingletons;


public class GameDelayer : MonoBehaviourSingletonPersistent<GameDelayer>
{
    private List<DelayController> _delayControllers = new List<DelayController>();


    private void Update()
    {
        if (_delayControllers.Count == 0) return;

        foreach (var item in _delayControllers)
        {
            item.Update();

            if (item.IsDelayOver())
            {
                item.InvokeEvent();
                _delayControllers.Remove(item);
            }
        }
    }

    public void PushDelay(float delay, Action action)
    {
        var delayController = new DelayController(delay, action);
        _delayControllers.Add(delayController);
    }
}


public class DelayController
{
    private float _delay;
    private float _currentDelay;
    private event Action _onDelayEnd;

    public DelayController(float delay, Action onDelayEnd)
    {
        _delay = delay;
        _currentDelay = 0;
        _onDelayEnd = onDelayEnd;
    }
    public bool IsDelayOver()
    {
        return _currentDelay >= _delay;
    }

    public void Update()
    {
        _currentDelay += Time.deltaTime;
    }

    public void InvokeEvent()
    {
        _onDelayEnd?.Invoke();
    }

    public void Reset()
    {
        _currentDelay = 0;
    }
}