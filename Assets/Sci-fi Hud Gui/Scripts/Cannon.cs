using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CannonController : MonoBehaviour
{
    [SerializeField] private GameObject _cannonBall;
    [SerializeField] private GameObject _instantiationPoint;
    [SerializeField] private AudioSource _turningAudioSource;
    [SerializeField] private AudioSource _firingAudioSource;

    public void FireGun()
    {
        GameObject projectile = Instantiate(_cannonBall, _instantiationPoint.transform.position, _instantiationPoint.transform.rotation);

        projectile.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(1000, 0, 0));

        // Play firing sound effect.
        _firingAudioSource.Play();
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


