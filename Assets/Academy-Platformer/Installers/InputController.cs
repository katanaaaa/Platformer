using System;
using UnityEngine;
using Zenject;

public class InputController : ITickable
{
    public event Action OnLeftEvent;
    public event Action OnRightEvent;
    
    private readonly TickableManager _tickableManager;

    public InputController(TickableManager tickableManager)
    {
        _tickableManager = tickableManager;
        
        _tickableManager.Add(this);
    }
    
    public void Tick()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            OnLeftEvent?.Invoke();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            OnRightEvent?.Invoke();
        }
    }
}