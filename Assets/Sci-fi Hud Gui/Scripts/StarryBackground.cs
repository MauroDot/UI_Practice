using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarryBackground : MonoBehaviour
{
    public GameObject starPrefab;
    public int numberOfStars = 100;
    public Vector2 moveSpeed = new Vector2(-0.5f, 0);
    public Vector2 starSpawnSize = new Vector2(10, 10);

    private void Start()
    {
        for (int i = 0; i < numberOfStars; i++)
        {
            SpawnStar();
        }
    }

    private void SpawnStar()
    {
        Vector2 spawnPosition = new Vector2(
            Random.Range(-starSpawnSize.x, starSpawnSize.x),
            Random.Range(-starSpawnSize.y, starSpawnSize.y)
        );

        GameObject star = Instantiate(starPrefab, spawnPosition, Quaternion.identity);
        star.transform.SetParent(transform);
        star.GetComponent<Rigidbody2D>().velocity = moveSpeed;

        // New: Get the StarBehavior component and call its ChangeColor method to assign an initial color
        StarBehavior starBehavior = star.GetComponent<StarBehavior>();
        if (starBehavior)
        {
            starBehavior.ChangeColor();
        }

        // Destroy the star when it goes out of bounds and spawn a new one
        Destroy(star, 100);
        Invoke("SpawnStar", 5.5f);
    }
}
