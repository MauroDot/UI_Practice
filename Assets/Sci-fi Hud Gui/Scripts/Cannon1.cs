using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon1 : MonoBehaviour
{
    [SerializeField] private GameObject _cannonBall;
    [SerializeField] private GameObject _instantiationPoint;
    [SerializeField] private AudioSource _turningAudioSource;
    [SerializeField] private AudioSource _firingAudioSource;

    private void Start()
    {
        _firingAudioSource = GetComponent<AudioSource>();
        if (_firingAudioSource == null)
        {
            Debug.LogError("No AudioSource component found! Adding one.");
            _firingAudioSource = gameObject.AddComponent<AudioSource>();
            // Here you can set other AudioSource properties if needed
        }
    }
    public void FireGun()
    {
        GameObject projectile = Instantiate(_cannonBall, _instantiationPoint.transform.position, _instantiationPoint.transform.rotation);

        // Change the color of the cannonball to a random color.
        ChangeToRandomColor(projectile);

        projectile.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(1000, 0, 0));

        // Play firing sound effect.
        _firingAudioSource.Play();
    }
    private void ChangeToRandomColor(GameObject obj)
    {
        Renderer rend = obj.GetComponent<Renderer>();
        if (rend != null)
        {
            rend.material.color = GetRandomColor();
        }
    }
    private Color GetRandomColor()
    {
        return new Color(Random.value, Random.value, Random.value);
    }
    public void TurnLeft()
    {
        transform.Rotate(0, -15, 0);

        // Play turning sound effect.
        _turningAudioSource.Play();
    }
    public void TurnRight()
    {
        transform.Rotate(0, 15, 0);

        // Play turning sound effect.
        _turningAudioSource.Play();
    }
}
