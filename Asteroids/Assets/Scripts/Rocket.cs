using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] GameObject manager;
    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject Lthrust;
    [SerializeField] GameObject Rthrust;
    [SerializeField] GameObject Bthrust;
    [SerializeField] GameObject flash;
    bool up, down, left, right;
    [SerializeField] AudioSource bsound;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Lthrust.GetComponent<SpriteRenderer>().enabled= false;
        Rthrust.GetComponent<SpriteRenderer>().enabled = false;
        Bthrust.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
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

        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject b = Instantiate(Bullet, transform.position + transform.right*1.5f, transform.rotation);
            b.GetComponent<Rigidbody2D>().linearVelocity = b.transform.right *5f;
            bsound.Play();
            
            GameObject f = Instantiate(flash, transform.position + transform.right*0.6f, transform.rotation);
            Destroy(f, .1f);
        }

        if(transform.position.x > 9f)
        {
            transform.position = new Vector3(transform.position.x - 18f, transform.position.y, transform.position.y);
        }
        if(transform.position.x < -9f)
        {
            transform.position= new Vector3(transform.position.x + 18f, transform.position.y, transform.position.y);
        }
        if(transform.position.y > 5f)
        {
            transform.position = new Vector3(transform.position.x , transform.position.y - 10f, transform.position.y);
        }
        if(transform.position.y < -5f)
        {
            transform.position= new Vector3(transform.position.x , transform.position.y + 10f, transform.position.y);
        }

        
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collide");
        if(collision.gameObject.tag.Equals("a"))
        {
            transform.position= new Vector3(0 , 0, transform.position.z);
            
        }
        
    }
 
}
