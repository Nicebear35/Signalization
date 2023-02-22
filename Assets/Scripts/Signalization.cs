using System.Collections;
using UnityEngine;

public class Signalization : MonoBehaviour
{
    [SerializeField] private AudioSource _signalizaton;
    [SerializeField] private float _timeToChangeVolume;
    [SerializeField] private float _currentVolume;

    private float _volumeStep = 0.2f;
    private float _minVolume = 0f;
    private float _maxVolume = 1f;

    private void Start()
    {
        _signalizaton.volume = 0f;
        _signalizaton.Play();
    }

    private void Update()
    {
        _currentVolume = _signalizaton.volume;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            StartCoroutine(ChangeVolume(_maxVolume, _volumeStep));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StartCoroutine(ChangeVolume(_minVolume, _volumeStep));
    }

    private IEnumerator ChangeVolume(float targetValue, float step)
    {
        while (_signalizaton.volume != targetValue)
        {
            _signalizaton.volume = Mathf.MoveTowards(_signalizaton.volume, targetValue, step * Time.deltaTime);
            
            yield return null;
        }
    }
}
