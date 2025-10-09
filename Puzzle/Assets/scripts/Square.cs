using UnityEngine;

public class Square : MonoBehaviour
{
    public int number = 0;
    [SerializeField] GameObject manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void sendNum()
    {
        manager.GetComponent<TullyMonster67>().setNum(number);
    }
    public void OnMouseDown()
    {
        manager.GetComponent<TullyMonster67>().setNum(number);
        manager.GetComponent<TullyMonster67>().move();
    }
}
