using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] int points;
    [SerializeField] float speed;
    bool up, down, left, right;
    Rigidbody2D rb;
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
}
