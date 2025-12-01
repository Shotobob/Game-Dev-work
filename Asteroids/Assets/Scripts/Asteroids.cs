using UnityEngine;

public class Asteroids : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] int hp = 0;
    [SerializeField] GameObject small;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.AddForce(transform.right);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger");
        collision.gameObject.SetActive(false);
        gameObject.SetActive(false);
        GameObject s1 = Instantiate(small, transform.position, transform.rotation);
        GameObject s2 = Instantiate(small, transform.position, transform.rotation);
        
    }
}
