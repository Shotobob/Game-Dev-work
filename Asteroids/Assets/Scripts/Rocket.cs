using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] GameObject manager;
    [SerializeField] GameObject Bullet;
    bool up, down, left, right;
    [SerializeField] AudioSource bsound;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
            rb.AddForce(transform.right);
        if(Input.GetKey(KeyCode.A))
            transform.Rotate(0, 0, 1);
        if(Input.GetKey(KeyCode.S))
            rb.AddForce(-transform.right);
        if(Input.GetKey(KeyCode.D))
            transform.Rotate(0, 0, -1);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject b = Instantiate(Bullet, transform.position + transform.right*1.5f, transform.rotation);
            b.GetComponent<Rigidbody2D>().linearVelocity = b.transform.right *5f;
            bsound.Play();
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
 
}
