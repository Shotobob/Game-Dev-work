using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject manager;
    [SerializeField] GameObject Bullet;
    bool up, down, left, right;
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
            up = true;
        if(Input.GetKey(KeyCode.A))
            transform.Rotate(0, 0, 1);
        if(Input.GetKey(KeyCode.S))
            down = true;
        if(Input.GetKey(KeyCode.D))
            transform.Rotate(0, 0, -1);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject b = Instantiate(Bullet, transform.position + transform.up*1.5f, transform.rotation);
            b.GetComponent<Rigidbody2D>().linearVelocity = b.transform.up *.5f;
        }

        
        
    }
    private void FixedUpdate()
    {
        Vector2 dir = Vector2.zero;

        if(up)
            dir+= new Vector2(0, speed*Time.deltaTime);
            up = false;
        if(left)
            dir+= new Vector2(-speed*Time.deltaTime,0);
        if(down)
            dir+= new Vector2(0, -speed*Time.deltaTime);
            down = false;
        if(right)
            dir+= new Vector2(speed*Time.deltaTime,0);
        rb.linearVelocity = dir;
    }
}
