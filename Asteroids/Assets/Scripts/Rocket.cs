using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] GameObject manager;
    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject Lthrust;
    [SerializeField] GameObject Rthrust;
    [SerializeField] GameObject Bthrust;
    [SerializeField] GameObject flash;
    [SerializeField] GameObject explo;
    bool up, down, left, right;
    [SerializeField] AudioSource bsound;
    [SerializeField] AudioSource death;
    Rigidbody2D rb;
    float timer;
    float deathtimer;
    float bstime = 0;
    bool dead = false;
    SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        Lthrust.GetComponent<SpriteRenderer>().enabled= false;
        Rthrust.GetComponent<SpriteRenderer>().enabled = false;
        Bthrust.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(dead == true)
        {
            spriteRenderer.enabled = false;
            bstime += Time.deltaTime;
            if (bstime > 0.01f)
            {
                spriteRenderer.enabled = true;
                bstime = 0;
            }
        }
        if(deathtimer > 1.5)
        {
            spriteRenderer.enabled = true;
            dead = false;
        }
        timer += Time.deltaTime;
        deathtimer += Time.deltaTime;
        //spriteRenderer.sortingOrder = -1;
       
        Lthrust.GetComponent<SpriteRenderer>().enabled= false;
        Rthrust.GetComponent<SpriteRenderer>().enabled = false;
        Bthrust.GetComponent<SpriteRenderer>().enabled = false;
        
        if(Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.right);
            Bthrust.GetComponent<SpriteRenderer>().enabled = true;
        }
        if(Input.GetKey(KeyCode.A))
            transform.Rotate(0, 0, 1);
        if(Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.right);
            Lthrust.GetComponent<SpriteRenderer>().enabled = true;
            Rthrust.GetComponent<SpriteRenderer>().enabled = true;
        }
            
        if(Input.GetKey(KeyCode.D))
            transform.Rotate(0, 0, -1);

        if(Input.GetKeyDown(KeyCode.Space) && timer >= 0.3f)
        {
            GameObject b = Instantiate(Bullet, transform.position + transform.right*1.5f, transform.rotation);
            b.GetComponent<Rigidbody2D>().linearVelocity = b.transform.right *5f;
            bsound.Play();
            
            GameObject f = Instantiate(flash, transform.position + transform.right*0.6f, transform.rotation);
            Destroy(f, .1f);
            timer = 0;
            
        }

        if(transform.position.x > 9f)
        {
            transform.position = new Vector3(transform.position.x - 18f, transform.position.y, transform.position.z);
        }
        if(transform.position.x < -9f)
        {
            transform.position= new Vector3(transform.position.x + 18f, transform.position.y, transform.position.z);
        }
        if(transform.position.y > 5f)
        {
            transform.position = new Vector3(transform.position.x , transform.position.y - 10f, transform.position.z);
        }
        if(transform.position.y < -5f)
        {
            transform.position= new Vector3(transform.position.x , transform.position.y + 10f, transform.position.z);
        }

        
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collide");
        
        if(collision.gameObject.tag.Equals("a") && deathtimer > 1.5f)
        {
            GameObject e = Instantiate(explo, transform.position, transform.rotation);
            transform.position= new Vector3(0 , 0, transform.position.z);
            rb.linearVelocity = new Vector2(0, 0);
            rb.angularVelocity = 0f;
            deathtimer = 0;
            manager.GetComponent<Tullymonster67>().visibleSkull();
            death.Play();
            dead = true;

        }
        
        

    }
    public void end()
    {
        gameObject.SetActive(false);
    }
    public void start()
    {
        gameObject.SetActive(true);
        transform.position = new Vector3(0, 0, transform.position.z);
        dead = false;
    }

}
