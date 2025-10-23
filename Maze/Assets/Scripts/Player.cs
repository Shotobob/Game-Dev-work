using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] int points;
    [SerializeField] float speed;
    [SerializeField] GameObject manager;
    bool up, down, left, right;
    Rigidbody2D rb;
    bool hasRed;
    bool hasYellow;
    bool hasGreen;
    bool hasBlue;
    bool win;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
            up = true;
        if(Input.GetKeyDown(KeyCode.A))
            left = true;
        if(Input.GetKeyDown(KeyCode.S))
            down = true;
        if(Input.GetKeyDown(KeyCode.D))
            right = true;
            
        if(Input.GetKeyUp(KeyCode.W))
            up = false;
        if(Input.GetKeyUp(KeyCode.A))
            left = false;
        if(Input.GetKeyUp(KeyCode.S))
            down = false;
        if(Input.GetKeyUp(KeyCode.D))
            right = false;
        
        
    }
    private void FixedUpdate()
    {
        Vector2 dir = Vector2.zero;

        if(up)
            dir+= new Vector2(0, speed*Time.deltaTime);
        if(left)
            dir+= new Vector2(-speed*Time.deltaTime,0);
        if(down)
            dir+= new Vector2(0, -speed*Time.deltaTime);
        if(right)
            dir+= new Vector2(speed*Time.deltaTime,0);
        rb.linearVelocity = dir;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger");
        if(collision.gameObject.tag.Equals("red"))
        {
            collision.gameObject.SetActive(false);
            hasRed = true;
        }
        if(collision.gameObject.tag.Equals("blue"))
        {
            collision.gameObject.SetActive(false);
            hasBlue = true;
        }
        if(collision.gameObject.tag.Equals("green"))
        {
            collision.gameObject.SetActive(false);
            hasGreen = true;
        }
        if(collision.gameObject.tag.Equals("yellow"))
        {
            collision.gameObject.SetActive(false);
            hasYellow = true;
        }
        if(collision.gameObject.tag.Equals("star"))
        {
            manager.GetComponent<TullyMonster67>().wintime();
            gameObject.SetActive(false);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collide");
        if(collision.gameObject.tag.Equals("greendoor") && hasGreen == true)
        {
            collision.gameObject.SetActive(false);
            
        }
        if(collision.gameObject.tag.Equals("reddoor") && hasRed == true)
        {
            collision.gameObject.SetActive(false);
            
        }
        if(collision.gameObject.tag.Equals("bluedoor") && hasBlue == true)
        {
            collision.gameObject.SetActive(false);
            
        }
        if(collision.gameObject.tag.Equals("yellowdoor") && hasYellow == true)
        {
            collision.gameObject.SetActive(false);
            
        }
    }
}
