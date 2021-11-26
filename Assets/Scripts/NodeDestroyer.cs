using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D p_collision)
    {
        Debug.Log("destroy");
        Destroy(p_collision.gameObject);
    }
}
