using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class Coin : MonoBehaviour
{

    [SerializeField] GameObject manager;
    private SpriteRenderer coinrenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coinrenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
      

    }

}
