using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button0 : MonoBehaviour
{
    [SerializeField] private int _value;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Image _cover;

    private void Start()
    {
        _gameManager = GameObject.Find("Manager").GetComponent<GameManager>();
    }

    public void SendScore()
    {
        // Check if the game hasn't started or if the item is not covered, then return.
        if (!_gameManager.IsGamePlaying() || !_cover.gameObject.activeSelf) return;

        _gameManager.TotalScore(_value);
        _cover.gameObject.SetActive(false);
    }

    public void Reveal()
    {
        _cover.gameObject.SetActive(false);
    }

    public void Hide()
    {
        _cover.gameObject.SetActive(true);
    }
}
