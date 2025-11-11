using UnityEngine;

public class squaremove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float speed;
    [SerializeField] GameObject manager;
    bool up, down, left, right;
    Rigidbody2D rb;
    float ogx = 0;
    float ogy = 0;
    
    bool win;
    bool lose;

    void Start()
    {
        lose = false;
        win = false;
        ogx = transform.position.x;
        ogy = transform.position.y;

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(win == true || lose == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                lose = false;
                win = false;
                transform.position = new Vector3(ogx, ogy, transform.position.z);
                rb.linearVelocity = Vector2.zero;
                rb.angularVelocity = 0f;
                rb.constraints = RigidbodyConstraints2D.None;
                rb.freezeRotation = true;
                up = false;
                down = false;
                left = false;
                right = false;
            }
        }
        
        if (manager.GetComponent<TullyMonster67>().iswin() == true)
        {
            rb.linearVelocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            win = true;
            //rb.linearVelocity = Vector3.zero;
        }
        if (manager.GetComponent<TullyMonster67>().islose() == true)
        {
            rb.linearVelocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            lose = true;
            //rb.linearVelocity = Vector3.zero;
        }
        if (win == true || lose == true)
        {
            return;
        }
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
        if (win || lose)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }
        Vector2 dir = Vector2.zero;
        if (win == true)
        {
            return;
        }
        if (up)
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
        if (collision.gameObject.tag.Equals("death"))
        {
            transform.position = new Vector3(ogx, ogy, transform.position.z);
            manager.GetComponent<TullyMonster67>().endlife();
        }
        if (collision.gameObject.tag.Equals("win"))
        {
            win = true;
            manager.GetComponent<TullyMonster67>().win();
        }

    }
 

}
