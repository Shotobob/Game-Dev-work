using UnityEngine;
using System.Collections.Generic;

public class Pole : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject manager;
    [SerializeField] List<Rings> rings;
    [SerializeField] int poleNum = 0;
    public bool selected = false;


    void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(110f/255f, 110f/255f, 110f/255f);
    }

    // Update is called once per frame
    void Update()
    {
        if(poleNum == 3 && rings.Count == 5)
        {
            //win
        }
    }
    
    private void OnMouseDown()
    {
        manager.GetComponent<TullyMonster67>().poleClicked(poleNum);
    }
    public List<Rings> getRings()
    {
        return rings;
    }
    public void setSelected(bool tf)
    {
        selected = tf;
        //return true;
    }
    public bool isSelected()
    {
        return true;
    }
    public void setColor()
    {
        if(selected == false)
        {
            GetComponent<SpriteRenderer>().color = new Color(118f/255f, 118f/255f, 118f/255f);
        }
        else{
            GetComponent<SpriteRenderer>().color = new Color(200f/255f, 110f/255f, 110f/255f);
        }
       
    
    }
}
