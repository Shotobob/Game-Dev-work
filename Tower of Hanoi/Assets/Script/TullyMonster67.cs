using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


public class TullyMonster67 : MonoBehaviour
{
    [SerializeField] List<Pole> poles;
    public int selectedPole = -1;
    [SerializeField] Text moves;
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
            poles[pole].setSelected(true);
            poles[pole].setColor();
        }
        else if(selectedPole == pole)
        {
            selectedPole = -1;
            poles[pole].setSelected(false);
            poles[pole].setColor();
        }
        else{
            poles[selectedPole].setSelected(false);
            poles[selectedPole].setColor();
            
            if(poles[pole].getRings().Count() == 0 || poles[selectedPole].getRings()[0].getWeight() < poles[pole].getRings()[0].getWeight())
            {

            }
            
            selectedPole = pole;
            poles[pole].setSelected(true);
            poles[pole].setColor();
            
        }
    }
}
