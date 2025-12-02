using UnityEngine;

public class explosion : MonoBehaviour
{
    Animator animator;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        float length = animator.GetCurrentAnimatorStateInfo(0).length;
        Destroy(gameObject, length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
