using UnityEngine;
using System.Collections.Generic;

public class TullyMonster67 : MonoBehaviour
{
    [SerializeField] List<Pole> poles;
    public int selectedPole = -1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void poleClicked(int pole)
    {
        if(selectedPole == -1)
        {
            selectedPole = pole;
            poles[pole].GetComponent<Pole>().setSelected(true);
            poles[pole].GetComponent<Pole>().setColor();
        }
        else if(selectedPole == pole)
        {
            selectedPole = -1;
            poles[pole].GetComponent<Pole>().setSelected(false);
            poles[pole].GetComponent<Pole>().setColor();
        }
        else{
            poles[selectedPole].GetComponent<Pole>().setSelected(false);
            poles[selectedPole].GetComponent<Pole>().setColor();
            selectedPole = pole;
            poles[pole].GetComponent<Pole>().setSelected(true);
            poles[pole].GetComponent<Pole>().setColor();
        }
    }
}
