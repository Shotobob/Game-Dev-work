using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Car : MonoBehaviour
{
    [SerializeField] bool vert; 
    [SerializeField] bool race; 
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
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(race == true)
        {
            transform.position = new Vector3(transform.position.x - 1.1f, transform.position.y, transform.position.z);
        }
        else{
            if(vert == false)
            {
                if(pos.x < transform.position.x)
                {
                    transform.position = new Vector3(transform.position.x - 1.1f, transform.position.y, transform.position.z);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x + 1.1f, transform.position.y, transform.position.z);
                }
            }
            else{
                if(pos.y < transform.position.y)
                {
                    transform.position = new Vector3(transform.position.x , transform.position.y- 1.1f, transform.position.z);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + 1.1f, transform.position.z);
                }
            }
        }
    }
}
