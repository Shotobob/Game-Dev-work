using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Shape : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] int points;
    [SerializeField] int moveTime;
    [SerializeField] GameObject manager;
    private float elapsedTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && manager.GetComponent<TullyMonster67>().end == true)
        {
            
            Move();
        }
        if (manager.GetComponent<TullyMonster67>().end)
        {
            return;
        }
        elapsedTime += 1000f * Time.deltaTime;
        if(elapsedTime >= moveTime )
        {
            Move();
            manager.GetComponent<TullyMonster67>().visibleSkull();

        }
    }
    public void Move()
    {
        transform.position = new Vector3(UnityEngine.Random.Range(-4.5f, 4.5f), UnityEngine.Random.Range(-4.5f, 3.5f), transform.position.z);
        elapsedTime = 0;

    }
    private void OnMouseDown()
    {
        if (manager.GetComponent<TullyMonster67>().end == false)
        {
            Move();
            manager.GetComponent<TullyMonster67>().AddPoints(points);
        }
        
    }
}
