using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class CoinsCollector : MonoBehaviour
{
    [SerializeField] private GameObject _soundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            CoinsText.Coins++;
            Destroy(gameObject);
            Destroy(Instantiate(_soundEffect, transform.position, Quaternion.identity), 1);            
        }
    }
}
