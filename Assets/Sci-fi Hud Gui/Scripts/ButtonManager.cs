using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Toggle[] _toggle;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Toggle0True()
    {
        if (_toggle[0].isOn == true)
            Debug.Log("Rule 1");
    }
    public void Toggle1True()
    {
        if (_toggle[1].isOn == true)
            Debug.Log("Rule 2");
    }
    public void Toggle2True()
    {
        if (_toggle[2].isOn == true)
            Debug.Log("Rule 3");
    }
}
