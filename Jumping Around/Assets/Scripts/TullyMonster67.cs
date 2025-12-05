using UnityEngine;

public class TullyMonster67 : MonoBehaviour
{
    Rigidbody2D rb;
    bool left, right;
    [SerializeField] float jumpforce;
    [SerializeField] float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
            left = true;
        if(Input.GetKeyDown(KeyCode.D))
            right = true;
        if(Input.GetKeyUp(KeyCode.A))
            left = false;
        if(Input.GetKeyUp(KeyCode.D))
            right = false;
        if(Input.GetKeyDown(KeyCode.Space) == true && isGrounded() == true)
            rb.linearVelocity = (new Vector2(rb.linearVelocity.x, jumpforce));
    }
    public bool isGrounded()
    {
        bool ig = false;
        Vector2 castFrom = new Vector2(transform.position.x, transform.position.y - GetComponent<SpriteRenderer>().bounds.size.y / 2 - 0.01f);
        RaycastHit2D hit = Physics2D.Raycast(castFrom, Vector2.down, .1f);
        //Debug.DrawRay(castFrom, (Vector2.down*.1f), )
        if(hit.transform != null && hit.transform.tag == "g")
            ig = true;
        return ig;
    }
    public void FixedUpdate()
    {
        float h = 0f;
        if(left)
            h -= speed;
        if(right)
            h += speed;
        rb.linearVelocity = new Vector2(h, rb.linearVelocity.y);
    }
}
