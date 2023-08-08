using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _menu1;
    [SerializeField] private GameObject _menu2;
    [SerializeField] private Button _nextButton;

    // Start is called before the first frame update
    void Start()
    {
        _menu1.SetActive(true);
        _menu2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        _menu1.SetActive(true);
        _menu2.SetActive(false);
        _nextButton.Select();
    }
}
