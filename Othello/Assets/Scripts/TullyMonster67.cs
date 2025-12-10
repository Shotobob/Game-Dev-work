using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class TullyMonster67 : MonoBehaviour
{
    [SerializeField] GameObject piece;
    private List<GameObject> pieces = new List<GameObject>();
    private bool placed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pieces.Add(piece);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pieces[pieces.Count - 1].transform.position = new Vector2(mousePos.x, mousePos.y);
        //correct();
        if (Input.GetKeyDown(KeyCode.Mouse0) && placed == false)
        {
            RaycastHit2D[] rays = Physics2D.RaycastAll(pieces[pieces.Count - 1].transform.position, Vector2.down, 1.5f);
            {
                if(rays.Length <= 1)
                {

                    placed = true;
                }
            }

        }
    }
}
