using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScrollBarSlideshow : MonoBehaviour
{
    [SerializeField] private Scrollbar _scrollbar;
    [SerializeField] private Image _currentImage;
    [SerializeField] private Sprite[] _scrollTimeImage;
    [SerializeField] private TMP_Text _scrollTimeText;

    private void Start()
    {
        UpdateSlideshow(_scrollbar.value);
    }

    private void Update()
    {
        UpdateSlideshow(_scrollbar.value);
    }

    private void UpdateSlideshow(float value)
    {
        if (value < 1f / 5f)
        {
            _scrollTimeText.text = "Oh no work again";
            _currentImage.sprite = _scrollTimeImage[0];
        }
        else if (value < 2f / 5f)
        {
            _scrollTimeText.text = "Well it is what it is";
            _currentImage.sprite = _scrollTimeImage[1];
        }
        else if (value < 3f / 5f)
        {
            _scrollTimeText.text = "Let's get it done!";
            _currentImage.sprite = _scrollTimeImage[2];
        }
        else if (value < 4f / 5f)
        {
            _scrollTimeText.text = "Almost there!";
            _currentImage.sprite = _scrollTimeImage[3];  
        }
        else
        {
            _scrollTimeText.text = "Finished for the day!";
            _currentImage.sprite = _scrollTimeImage[4];  
        }
    }
}
