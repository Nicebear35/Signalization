using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Detector : MonoBehaviour
{
    [SerializeField] private Signalization _signalization;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            _signalization.EnableEncreasingVolume();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
            _signalization.EnableDecreasingVolume();
    }
}
