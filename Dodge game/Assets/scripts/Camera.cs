using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject player;
    Vector3 vec3;
    void Start()
    {
        transform.position = new Vector3(-41f, 20f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Clamp(player.transform.position.x, -41f, 41f);
        float y = Mathf.Clamp(player.transform.position.y, -20f, 20f);
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(x, y, transform.position.z), ref vec3, .15f);
    }
}
