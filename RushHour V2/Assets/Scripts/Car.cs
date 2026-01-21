using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Car : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] bool vert; 
    [SerializeField] bool race; 
    public bool end = false;
    public bool dragging = false;
    //[SerializeField] bool win;


    [SerializeField] TullyMonster67 manager;
    private float ogx = 0;
    private float ogy = 0;
    private float ogz = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<TullyMonster67>();
        dragging = false;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.freezeRotation = true;
        rb.bodyType = RigidbodyType2D.Static;
        end = false;
        //manager.GetComponent<TullyMonster67>().setWin(false);
        ogx = transform.position.x;
        ogy = transform.position.y;
        

    }

    // Update is called once per frame
    void Update()
    {
        if(vert == true)
        {
            transform.position = new Vector3(ogx, transform.position.y, transform.position.z);
        }
        else{
            transform.position = new Vector3(transform.position.x, ogy, transform.position.z);
        }
        if (manager.GetComponent<TullyMonster67>().isWin() == true)
        {
            end = true;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(end == true)
            {
                transform.position = new Vector3(ogx, ogy, transform.position.z);
                manager.GetComponent<TullyMonster67>().winningText(false);

                manager.GetComponent<TullyMonster67>().setWin(false);
                manager.GetComponent<TullyMonster67>().setZero();
                end = false;
                SceneManager.Load;
            }
            

        }
        if(race == true)
        {
            RaycastHit2D[] rays = Physics2D.RaycastAll(transform.position, Vector2.left, 1.2f);
            if (rays.Length >= 3)
            {
                manager.GetComponent<TullyMonster67>().next();
                if (SceneManager.GetActiveScene().buildIndex == 4)
                {
                    manager.GetComponent<TullyMonster67>().setWin(true);
                    manager.GetComponent<TullyMonster67>().winningText(true);
                    //win = false;
                }
                //manager.GetComponent<TullyMonster67>().winningText(true);

            }

        }
        
    }
    private void OnMouseDown()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        if (manager.GetComponent<TullyMonster67>().isWin() == false)
        {
            dragging = true;
        }

    }
    private void OnMouseUp()
    {
        rb.bodyType = RigidbodyType2D.Static;
        dragging = false;
        

    }
    private void FixedUpdate()
    {
        if(dragging == true)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float x = mousePos.x - transform.position.x;
            float y = mousePos.y - transform.position.y;

            Vector2 vel = new Vector2 (x, y);
            rb.linearVelocity = vel/Time.deltaTime;

        }
        
    }
    
}
