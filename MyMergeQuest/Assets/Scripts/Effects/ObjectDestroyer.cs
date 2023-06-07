using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    private void OnDestroy()
    {
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}
