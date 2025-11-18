using UnityEngine;

public class Light : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject manager;
    [SerializeField] int weight;
    float ogx;
    float ogy;

    void Start()
    {
        ogx = transform.position.x;
        ogy = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void move(float x, float y)
    {
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
    public void moveOG()
    {
        transform.position = new Vector3(ogx, ogy, transform.position.z);
    }
    public int getWeight()
    {
        return weight;
    } 
}
