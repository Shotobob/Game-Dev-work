using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class Tullymonster67 : MonoBehaviour
{
    [SerializeField] GameObject LightningDeath;
    [SerializeField] GameObject LP;
    [SerializeField] GameObject DP;
    [SerializeField] GameObject MP;
    [SerializeField] List<Pole> poles;
    public int selectedPole = -1;
    [SerializeField] Text death;
    [SerializeField] Text win;
    public int movesNum = 0;
    public bool end = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        death.enabled = false;
        LightningDeath.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void poleClicked(int pole)
    {
        if (end == false)
        {
            double x = 0;
            double y = -3.5;
            if (selectedPole == -1)
            {
                selectedPole = pole;
                poles[pole].setSelected(true);
                //poles[pole].setColor();
            }
            else if (selectedPole == pole)
            {
                selectedPole = -1;
                poles[pole].setSelected(false);
                //poles[pole].setColor();
            }
            else
            {
                poles[selectedPole].setSelected(false);
                //poles[selectedPole].setColor();

                if (poles[selectedPole].getLights().Count != 0)
                {
                    if (poles[pole].getLights().Count == 0 || poles[selectedPole].getLights()[0].getWeight() < poles[pole].getLights()[0].getWeight())
                    {

                        for (int i = 0; i < poles[pole].getLights().Count; i++)
                        {
                            y += 0.8;
                        }
                        Light movedLight = poles[selectedPole].getLights()[0];
                        if (pole == 0)
                        {
                            x = -6.5;
                            movedLight.move((float)x, (float)y);

                        }
                        if (pole == 1)
                        {
                            x = 0;
                            movedLight.move((float)x, (float)y);

                        }
                        if (pole == 2)
                        {
                            x = 6.5;
                            movedLight.move((float)x, (float)y);
                        }
                        poles[pole].addLights(poles[selectedPole].getLights()[0]);
                        poles[selectedPole].removeLights();
                        movesNum++;

                    }
                    else
                    {
                        poles[pole].getLights()[0].GetComponent<SpriteRenderer>().enabled = false;
                        poles[selectedPole].getLights()[0].GetComponent<SpriteRenderer>().enabled = false;
                        death.enabled = true;
                        LightningDeath.GetComponent<SpriteRenderer>().enabled = true;
                        if (pole == 0)
                        {
                            x = -6.5;

                        }
                        if (pole == 1)
                        {
                            x = 0;

                        }
                        if (pole == 2)
                        {
                            x = 6.5;
                        }
                        LightningDeath.transform.position = new Vector3((float)x, transform.position.y, transform.position.z);
                        
                    }

                }
                selectedPole = -1;
                poles[pole].setSelected(false);


            }
        }

        
    }
    public void change()
    {
        if(LP.GetComponent<SpriteRenderer>().enabled == false)
        {
            LP.GetComponent<SpriteRenderer>().enabled == true
        }
        else{
            LP.GetComponent<SpriteRenderer>().enabled == false;
        }
    }
}
