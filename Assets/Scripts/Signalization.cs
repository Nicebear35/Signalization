using System.Collections;
using UnityEngine;

public class Signalization : MonoBehaviour
{
    [SerializeField] private AudioSource _signalizaton;
    [SerializeField] private float _timeToChangeVolume;

    private Coroutine _coroutine;

    private float _volumeStep = 0.2f;
    private float _minVolume = 0f;
    private float _maxVolume = 1f;

    private void Start()
    {
        _signalizaton.volume = 0f;
        _signalizaton.Play();
    }

    public void EnableEncreasingVolume()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ChangeVolume(_maxVolume, _volumeStep));
    }

    public void EnableDecreasingVolume()
    {
        StopCoroutine(_coroutine);
        _coroutine = StartCoroutine(ChangeVolume(_minVolume, _volumeStep));
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
