using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpeed : MonoBehaviour
{
    public float speed = 1f;
    private MeshRenderer MeshRenderer;
    void Start()
    {
        MeshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MeshRenderer.material.mainTextureOffset += new Vector2(speed*Time.deltaTime,0);
    }
}
