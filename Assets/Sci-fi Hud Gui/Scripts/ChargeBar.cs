using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ChargeBar : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Button _chargeButton;
    [SerializeField] private TMP_Text _textField;
    [SerializeField] private Animator _anim;

    [SerializeField] private GameObject _cannonBall;
    [SerializeField] private GameObject _instantiationPoint;

    // Sound
    public AudioSource _chargeAudioSource; // AudioSource for charging sound
    public AudioClip _chargeClip;          // AudioClip for charging
    public AudioSource _fireAudioSource;   // AudioSource for firing sound
    public AudioClip _fireClip;            // AudioClip for firing

    private float _charge;
    private bool _chargeBool;

    public void Start()
    {
        _textField.text = "No Charge";
    }

    public void Update()
    {
        if (_chargeBool == true)
        {
            if (_charge < 100)
            {
                _charge += 50.0f * Time.deltaTime;
            }
            _slider.value = _charge;
            ChangeAnimSpeed();
            _textField.text = "Charging";

            // Start the charging sound if not playing and charge is less than 100
            if (!_chargeAudioSource.isPlaying && _charge < 100)
            {
                _chargeAudioSource.clip = _chargeClip;
                _chargeAudioSource.Play();
            }
            else if (_charge >= 100) // Stop the charging sound if charge reaches 100
            {
                _chargeAudioSource.Stop();
            }
        }
        else
        {
            if (_charge >= 0)
            {
                _charge -= 300.0f * Time.deltaTime;
            }
            _slider.value = _charge;
            _textField.text = "Not Charging";

            // Stop the charging sound if playing
            if (_chargeAudioSource.isPlaying)
            {
                _chargeAudioSource.Stop();
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Pointer is Down");
        _chargeBool = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Pointer is Up");
        _chargeBool = false;
    }

    private void ChangeAnimSpeed()
    {
        if (_charge < 30f)
        {
            _anim.speed = 1;
        }

        if (_charge > 30f && _charge < 70f)
        {
            _anim.speed = 2;
        }

        if (_charge > 70f)
        {
            _anim.speed = 4;
        }
    }

    public void FireGun()
    {
        GameObject projectile = Instantiate(_cannonBall, _instantiationPoint.transform.position, _instantiationPoint.transform.rotation);
        ChangeToRandomColor(projectile);

        float forceMultiplier = 1 + _charge / 100.0f;
        projectile.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(2000 * forceMultiplier, 0, 0));

        // Destroy the projectile after 15 seconds
        Destroy(projectile, 15.0f);

        // Play firing sound effect.
        _fireAudioSource.clip = _fireClip;
        _fireAudioSource.Play();
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
    }
}
