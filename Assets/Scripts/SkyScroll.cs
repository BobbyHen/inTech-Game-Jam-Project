using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyScroll : MonoBehaviour
{
    public float scrollSpeed;
    public Renderer _renderer;
    public Transform bgScroll;
    
    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(Time.time * scrollSpeed, 0);
        _renderer.material.mainTextureOffset = offset;
        transform.position = new Vector2(bgScroll.position.x, transform.position.y);
    }
}
