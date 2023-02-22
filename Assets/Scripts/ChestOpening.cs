using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ChestOpening : MonoBehaviour
{
    [SerializeField] Animator _animator;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _animator.SetBool("IsInside", true);
        }
    }

    private void OnTriggerExit2D(Collider2D noCollision)
    {
        _animator.SetBool("IsInside", false);    
    }
}
