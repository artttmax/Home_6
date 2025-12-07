using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy> Release;

    private Coroutine _coroutine;

    private float _minLifeTime = 2f;
    private float _maxLifeTime = 10f;

    private void OnEnable()
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(ReturnAfterDelay(ChangeLifeTime()));
        }
    }

    private IEnumerator ReturnAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        Disappear();
    }

    private void Disappear()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);

            _coroutine = null;
        }

        TriggerRelease();
    }

    private float ChangeLifeTime()
    {
        return Random.Range(_minLifeTime, _maxLifeTime + 1);
    }

    private void TriggerRelease()
    {
        Release?.Invoke(this);
    }
}