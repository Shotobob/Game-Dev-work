
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Tullymonster67 : MonoBehaviour
{
    [SerializeField] GameObject skull1;
    [SerializeField] GameObject skull2;
    [SerializeField] GameObject skull3;
    [SerializeField] GameObject roids;
    [SerializeField] Rocket Rock;
    [SerializeField] Text win;
    private int count = 0;
    public bool end = false;
    private int score = 0;
    [SerializeField] Text scoreText;
    float spawn = 0;
    float timer = 4f;
    float acount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        skull1.GetComponent<SpriteRenderer>().enabled = true;
        skull2.GetComponent<SpriteRenderer>().enabled = true;
        skull3.GetComponent<SpriteRenderer>().enabled = true;

        win.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(end)
        {
            Rock.end();
            win.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.R) && end == true)
        {
            Rock.start();
            end = false;
            win.enabled = false;
            skull1.GetComponent<SpriteRenderer>().enabled = true;
            skull2.GetComponent<SpriteRenderer>().enabled = true;
            skull3.GetComponent<SpriteRenderer>().enabled = true;
            GameObject[] asteroids = GameObject.FindGameObjectsWithTag("a");
            foreach (GameObject a in asteroids)
            {
                if(a.GetComponent<Asteroids>().spawnedFromPrefab == true)
                {
                    Destroy(a);
                }
                
            }
            count = 0;
            score = 0;
            AddPoints(0);
            acount = 0;
            spawn = 0;
            timer = 4f;

}
        spawn += Time.deltaTime;
        if(spawn >= timer)
        {
            spawna();
            spawn = 0;
            timer = timer - 0.5f;
            if(timer == 0)
            {
                timer = 0.5f;
            }
        }
    }
    public void visibleSkull()
    {
        skull1.GetComponent<SpriteRenderer>().enabled = false;
        if (count == 1)
        {
            skull2.GetComponent<SpriteRenderer>().enabled = false;
        }
        if (count == 2)
        {
            skull3.GetComponent<SpriteRenderer>().enabled = false;
            end = true;
        }
        count++;

    }
    public void AddPoints(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }
    public void spawna()
    {
        if(end || acount > 12)
        {
            return;
        }

        int place = Random.Range(0, 4);
        if(place == 0)
        {
            float x = Random.Range(-9f, 9f);
            Vector2 v = new Vector2(x, -5);
            GameObject a = Instantiate(roids, v, transform.rotation);
            a.GetComponent<Asteroids>().settrue();
            acount++;
        }
        if(place == 1)
        {
            float x = Random.Range(-9f, 9f);
            Vector2 v = new Vector2(x, 5);
            GameObject a = Instantiate(roids, v, transform.rotation);
            a.GetComponent<Asteroids>().settrue();
            acount++;
        }
        if(place == 2)
        {
            float x = Random.Range(-5f, 5f);
            Vector2 v = new Vector2(-9, x);
            GameObject a = Instantiate(roids, v, transform.rotation);
            a.GetComponent<Asteroids>().settrue();
            acount++;
        }
        if(place == 3)
        {
            float x = Random.Range(-5f, 5f);
            Vector2 v = new Vector2(9, x);
            GameObject a = Instantiate(roids, v, transform.rotation);
            a.GetComponent<Asteroids>().settrue();
            acount++;
        }

    }
}
