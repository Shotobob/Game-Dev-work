using UnityEngine;

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
        elapsedTime += 1000f * Time.deltaTime;
        if(elapsedTime >= moveTime )
        {
            Move();
            manager.GetComponent<TullyMonster67>().visibleSkull();
        }
    }
    private void Move()
    {
        transform.position = new Vector3(UnityEngine.Random.Range(-4.5f, 4.5f), UnityEngine.Random.Range(-4.5f, 4.5f), transform.position.z);
        elapsedTime = 0;

    }
    private void OnMouseDown()
    {
        Move();
        manager.GetComponent<TullyMonster67>().AddPoints(points);
    }
}
