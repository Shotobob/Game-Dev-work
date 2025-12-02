using UnityEngine;

public class Asteroids : MonoBehaviour
{
    [SerializeField] GameObject manager;
    Rigidbody2D rb;
    [SerializeField] int hp = 0;
    [SerializeField] GameObject small;
    [SerializeField] GameObject explo;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //rb.AddForce(transform.right);
        rb = GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(hp, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
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
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger");
        GameObject e = Instantiate(explo, transform.position, transform.rotation);
        if (hp != 1)
        {
            GameObject s1 = Instantiate(small, transform.position, transform.rotation);
            GameObject s2 = Instantiate(small, transform.position, transform.rotation);
        }
        

        if(hp == 3)
        {
            manager.GetComponent<Tullymonster67>().AddPoints(10);
        }
        if (hp == 2)
        {
            manager.GetComponent<Tullymonster67>().AddPoints(5);
        }
        if (hp == 1)
        {
            manager.GetComponent<Tullymonster67>().AddPoints(2);
        }
        
        collision.gameObject.SetActive(false);
        gameObject.SetActive(false);


    }
}
