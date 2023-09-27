using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBehavior : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Color[] colors; // Colors the star can switch to
    public float colorChangeRate = 5f; // Time interval for color change in seconds

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ChangeColor(); // Initialize with a random color
        InvokeRepeating("ChangeColor", colorChangeRate, colorChangeRate); // Schedule color changes
    }

    public void ChangeColor()
    {
        if (colors.Length > 0)
        {
            Color randomColor = colors[Random.Range(0, colors.Length)];
            spriteRenderer.color = randomColor;
        }
    }
}
