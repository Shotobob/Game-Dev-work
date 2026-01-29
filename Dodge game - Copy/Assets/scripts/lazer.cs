using UnityEngine;

public class lazer : MonoBehaviour
{
    SpriteRenderer sr;
    float time = 0f;
    [SerializeField] GameObject laz;

    void Start()
    {
        laz.SetActive(false);
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time >= 3f && time < 3.5f)
            sr.enabled = false;

        else if (time >= 3.5f && time < 4f)
            sr.enabled = true;

        else if (time >= 4f && time < 4.5f)
            sr.enabled = false;

        else if (time >= 4.5f && time < 6f)
        {
            sr.enabled = true;
            laz.SetActive(true);
        }
        else if (time >= 6f)
        {
            time = 0f;
            laz.SetActive(false);
        }
    }
}
