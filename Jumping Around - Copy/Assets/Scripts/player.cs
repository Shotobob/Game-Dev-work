using UnityEngine;

public class player : MonoBehaviour
{
    private SpriteRenderer renderer;
    [SerializeField] float xspeed;
    float time = 0;
    private bool start = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -15f)
        {
            transform.position = new Vector2(60f, transform.position.y);
        }
        if(start == true)
        {
            transform.position = new Vector2(transform.position.x - xspeed*0.05f, transform.position.y);
            time += Time.deltaTime;
            if(time > 1f)
            {
                time = 0f;
                xspeed += 0.05f;
            }
        }

        
    }
    public void settrue()
    {
        start = true;
    }
}
