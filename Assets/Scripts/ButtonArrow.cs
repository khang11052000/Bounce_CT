using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonArrow : MonoBehaviour
{
    //public UnityEvent<int> eventInt;

    public UnityEvent eventMouseDown;
    public UnityEvent eventMouseUp;

    //public Event eventMouseDown2;
    
    private void OnMouseDown()
    {
        // eventInt.AddListener(OnCallbackInt);
        //
        // eventMouseDown.AddListener(OnCallback);
        this.eventMouseDown.Invoke();
        
        //this.eventInt.Invoke(2);
        
    }

    private void OnMouseUp()
    {
        this.eventMouseUp.Invoke();
    }

    // private void OnCallbackInt(int i)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // private void OnDisable()
    // {
    //     //remove callback in event
    //     eventMouseDown.RemoveListener(OnCallback);
    //     
    //     //remove all callback
    //     eventMouseDown.RemoveAllListeners();
    // }
    //
    // private void OnCallback()
    // {
    //     
    // }
}
