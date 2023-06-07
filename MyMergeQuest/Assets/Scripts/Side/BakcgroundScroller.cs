using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakcgroundScroller : MonoBehaviour
{
    [Range(-1f, 1f)]
    public float scrollSpeed = 0.5f;

    private float offset;
    private Material material;

    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        if (GlobalVars.canMove)
        {
            offset += (Time.deltaTime * scrollSpeed) / 10f;
            material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }
    }
}
