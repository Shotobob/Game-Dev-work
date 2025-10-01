using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class Car : MonoBehaviour
{
    [SerializeField] bool vert; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        Vector3 areaClicked = new Vector3(UnityEngine.Random.Range(-4.5f, 4.5f), UnityEngine.Random.Range(-4.5f, 3.5f), transform.position.z);
    }
}
