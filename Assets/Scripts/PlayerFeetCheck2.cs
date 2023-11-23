using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFeetCheck2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Destroy(transform.parent.gameObject); // Remove game object Enemy
        }
    }
}
