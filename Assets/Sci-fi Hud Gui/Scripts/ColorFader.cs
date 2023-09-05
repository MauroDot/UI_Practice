using TMPro;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Image))]
public class ColorFader : MonoBehaviour
{
    public Color color1 = Color.white;
    public Color color2 = Color.black;
    public float duration = 1.0f; // duration for one way transition
    private bool isFadingToColor2 = true;
    private Image imageComponent;

    private void Start()
    {
        imageComponent = GetComponent<Image>();
        StartCoroutine(FadeBetweenColors());
    }

    private IEnumerator FadeBetweenColors()
    {
        float elapsed = 0;

        while (true)
        {
            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;

                if (isFadingToColor2)
                {
                    imageComponent.color = Color.Lerp(color1, color2, elapsed / duration);
                }
                else
                {
                    imageComponent.color = Color.Lerp(color2, color1, elapsed / duration);
                }

                yield return null;
            }

            // Toggle the direction
            isFadingToColor2 = !isFadingToColor2;
            elapsed = 0;
        }
    }
}
