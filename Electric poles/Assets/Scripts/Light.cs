using UnityEngine;

public class Light : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject manager;
    [SerializeField] int weight;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void move(float x, float y)
    {
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
    public int getWeight()
    {
        return weight;
    } 
}
