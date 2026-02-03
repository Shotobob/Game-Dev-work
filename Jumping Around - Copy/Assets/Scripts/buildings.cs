using UnityEngine;

public class buildings : MonoBehaviour
{
    private SpriteRenderer renderer;
    [SerializeField] float xspeed;
    float time = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        renderer.material.mainTextureOffset += new Vector2(xspeed*Time.deltaTime, 0);
        time += Time.deltaTime;
        if(time > 1f)
        {
            time = 0f;
            xspeed += 0.05f;
        }
    }
}
