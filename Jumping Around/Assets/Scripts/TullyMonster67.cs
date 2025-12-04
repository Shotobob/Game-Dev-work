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
            left = true;
        if(Input.GetKeyUp(KeyCode.D))
            right = true;
        /*if(Input.GetKeyUp(KeyCode.Space))
            //rb.linearvlocity = (new Vector2(rb.velocity.x, jumpforce));*/


    }
}
