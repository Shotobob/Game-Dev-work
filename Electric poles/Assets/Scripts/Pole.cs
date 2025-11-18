using UnityEngine;
using System.Collections.Generic;

public class Pole : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject manager;
    [SerializeField] List<Light> Li;
    [SerializeField] int poleNum = 0;
    public bool selected = false;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnMouseDown()
    {
        manager.GetComponent<Tullymonster67>().poleClicked(poleNum);
    }
    public List<Light> getLights()
    {
        return Li;
    }
    public void addLights(Light lights)
    {
        Li.Insert(0, lights);
    }
    public void removeLights()
    {
        Li.Remove(Li[0]);
    }
    public void setSelected(bool tf)
    {
        selected = tf;
        //return true;
    }
    public bool isSelected()
    {
        return selected;
    }

}
