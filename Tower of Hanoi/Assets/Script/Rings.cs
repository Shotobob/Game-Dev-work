using UnityEngine;
using System.Collections.Generic;

public class Rings : MonoBehaviour
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
    public void move(int x, int y)
    {
        transform.position = new Vector3(0, 0, 0);
    }
    public int getWeight()
    {
        return weight;
    } 
}
