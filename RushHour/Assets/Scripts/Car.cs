using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Car : MonoBehaviour
{
    [SerializeField] bool vert; 
    [SerializeField] bool race; 
    
    
    [SerializeField] GameObject manager;
    private float ogx = 0;
    private float ogy = 0;
    private float ogz = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ogx = transform.position.x;
        ogy = transform.position.y;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            
            transform.position = new Vector3(ogx, ogy, transform.position.z);
        }
    }
    private void OnMouseDown()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if(race == true )
        {
            RaycastHit2D[] rays = Physics2D.RaycastAll(transform.position, Vector2.left, 1.2f);
            if(rays.Length == 1)
            {
                transform.position = new Vector3(transform.position.x - 1.1f, transform.position.y, transform.position.z);
                manager.GetComponent<TullyMonster67>().addMove();

            }
            
            
        }
        else{
            
            if(vert == false)
            {
                if(pos.x < transform.position.x)
                {
                    RaycastHit2D[] rays = Physics2D.RaycastAll(transform.position, Vector2.left, 2.2f);
                    if(rays.Length == 1)
                    {
                        transform.position = new Vector3(transform.position.x - 1.1f, transform.position.y, transform.position.z);
                        manager.GetComponent<TullyMonster67>().addMove();
                    }
                    
                }
                else
                {
                    RaycastHit2D[] rays = Physics2D.RaycastAll(transform.position, Vector2.right, 2.2f);
                    if(rays.Length == 1)
                    {
                        transform.position = new Vector3(transform.position.x + 1.1f, transform.position.y, transform.position.z);
                        manager.GetComponent<TullyMonster67>().addMove();
                    }
                    
                }
            }
            else{
                if(pos.y < transform.position.y)
                {
                    RaycastHit2D[] rays = Physics2D.RaycastAll(transform.position, Vector2.down, 2.2f);
                    if(rays.Length == 1)
                    {
                        transform.position = new Vector3(transform.position.x , transform.position.y- 1.1f, transform.position.z);
                        manager.GetComponent<TullyMonster67>().addMove();
                    }
                    
                }
                else
                {
                    
                    RaycastHit2D[] rays = Physics2D.RaycastAll(transform.position, Vector2.up, 2.2f);
                    if(rays.Length == 1)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y + 1.1f, transform.position.z);
                        manager.GetComponent<TullyMonster67>().addMove();
                    }
                    
                }
            }
        }
        
    }
}
