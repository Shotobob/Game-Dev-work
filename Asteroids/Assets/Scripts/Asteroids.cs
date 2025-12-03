using UnityEngine;
using UnityEngine.UI;

public class Asteroids : MonoBehaviour
{
    [SerializeField] GameObject manager;
    Rigidbody2D rb;
    [SerializeField] int hp = 0;
    [SerializeField] int size = 0;
    [SerializeField] GameObject small;
    [SerializeField] GameObject explo;
    [SerializeField] AudioSource death;
    public bool spawnedFromPrefab = false;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        Vector2 direction = Random.insideUnitCircle.normalized;
        rb.AddForce(direction*50f);
        //rb.linearVelocity = direction;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (spawnedFromPrefab == false)
        {
            return;
        }
        if (transform.position.x > 9f)
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
    public void settrue()
    {
        spawnedFromPrefab = true;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 pv = rb.linearVelocity;
        Vector2 num1 = new Vector2 (-pv.y, pv.x).normalized;
        Vector2 num2 = new Vector2(pv.y, -pv.x).normalized;
        Vector2 num1s = new Vector2(pv.x, pv.y).normalized;
        Vector2 num2s = new Vector2(pv.x, pv.y).normalized;
        Debug.Log("trigger");
        hp--;
        collision.gameObject.SetActive(false);
        if (hp == 0)
        {
            death.Play();
            GameObject e = Instantiate(explo, transform.position, transform.rotation);
            if (size != 1)
            {
                
                GameObject s1 = Instantiate(small, transform.position + transform.right * 1.5f, transform.rotation);
                GameObject s2 = Instantiate(small, transform.position + transform.right * -1.5f, transform.rotation);

                Rigidbody2D rb1 = s1.GetComponent<Rigidbody2D>();
                Rigidbody2D rb2 = s2.GetComponent<Rigidbody2D>();

                rb1.AddForce(num1 * 50);
                rb2.AddForce(num2 * 50);
                rb1.AddForce(num1s * 50);
                rb2.AddForce(num2s * 50);

                s1.GetComponent<Asteroids>().spawnedFromPrefab = true;
                s2.GetComponent<Asteroids>().spawnedFromPrefab = true;
            }
            
            if (size == 3)
            {
                manager.GetComponent<Tullymonster67>().AddPoints(10);
            }
            if (size == 2)
            {
                manager.GetComponent<Tullymonster67>().AddPoints(5);
            }
            if (size == 1)
            {
                manager.GetComponent<Tullymonster67>().AddPoints(2);
            }

            
            gameObject.SetActive(false);
        }
        

        


    }
}
