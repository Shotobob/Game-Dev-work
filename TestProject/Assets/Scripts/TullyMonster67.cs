using UnityEngine;
using UnityEngine.UI;

public class TullyMonster67 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] GameObject skull1;
    [SerializeField] GameObject skull2;
    [SerializeField] GameObject skull3;
    [SerializeField] Text scoreText;
    private int score = 0;
    private int count = 0;
    void Start()
    {
        skull1.GetComponent<SpriteRenderer>().enabled = false;
        skull2.GetComponent<SpriteRenderer>().enabled = false;
        skull3.GetComponent<SpriteRenderer>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void visibleSkull()
    {
        skull1.GetComponent<SpriteRenderer>().enabled = true;
        if(count == 1)
        {
            skull2.GetComponent<SpriteRenderer>().enabled = true;
        }
        if(count == 2)
        {
            skull3.GetComponent<SpriteRenderer>().enabled = true;
        }
        count++;
        
    }

    public void AddPoints(int points)
    {
        score+=points;
        scoreText.text = "Score: " + score;
    }
}
