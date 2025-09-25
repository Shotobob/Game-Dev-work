using UnityEngine;

public class Pole : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject manager;


    void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(110f/255f, 110f/255f, 110f/255f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        setColor();
        //manager.GetComponent<TullyMonster67>().AddPoints(points);
    }
    private void setColor()
    {
       GetComponent<SpriteRenderer>().color = new Color(200f/255f, 110f/255f, 110f/255f);
    
    }
}
