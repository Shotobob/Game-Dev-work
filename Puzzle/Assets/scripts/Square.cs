using UnityEngine;

public class Square : MonoBehaviour
{
    public int number = 0;
    [SerializeField] GameObject manager;
    [SerializeField] GameObject square;
    [SerializeField] GameObject image;
    private bool imageSet = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        image.SetActive(true);
        square.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            if(imageSet == false)
            {
                imageSet = true;
                image.SetActive(true);
                square.SetActive(false);
            }
            else if (imageSet == true)
            {
                imageSet = false;
                image.SetActive(false);
                square.SetActive(true);
            }
        }
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
    public void Move(int row, int col)
    {
        float x = -7f + col * 2.1f;
        float y = 3f - row*2.1f;

        transform.position = new Vector3(x, y, transform.position.z);
    }
}
