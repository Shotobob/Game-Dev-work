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
    [SerializeField] Pole OGpoles;
    public int selectedPole = -1;
    [SerializeField] Text death;
    [SerializeField] Text win;
    [SerializeField] AudioSource MoveLightning;
    [SerializeField] AudioSource Deathhhhh;
    [SerializeField] AudioSource select;
    public int movesNum = 0;
    public bool end = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        death.enabled = false;
        win.enabled = false;
        LightningDeath.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (poles[2].getLights().Count == 4)
        {
            end = true;
            win.enabled = true;

        }
        if (Input.GetKeyDown(KeyCode.R) && end == true)
        {
            DP.GetComponent<SpriteRenderer>().sortingOrder = -3;
            death.enabled = false;
            win.enabled = false;
            LightningDeath.GetComponent<SpriteRenderer>().enabled = false;
            
           
            end = false;
            win.enabled = false;
            selectedPole = -1;
            foreach (Pole p in poles)
            {
                foreach (Light l in p.getLights())
                {
                    l.GetComponent<SpriteRenderer>().enabled = true;
                }
                p.getLights().Clear();
            }
            List<Light> original = OGpoles.getLights();
            for (int i = 3; i >= 0; i--)
            {
                original[i].moveOG();       
                poles[0].addLights(original[i]); 
            }


        }
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
                LP.transform.position = poles[pole].getPos();
                LP.GetComponent<SpriteRenderer>().enabled = true;
                select.Play();
            }
            else if (selectedPole == pole)
            {
                selectedPole = -1;
                poles[pole].setSelected(false);
                LP.transform.position = poles[pole].getPos();
                LP.GetComponent<SpriteRenderer>().enabled = false ;
                select.Play();
            }
            else
            {
                poles[selectedPole].setSelected(false);
                LP.transform.position = poles[pole].getPos();
                LP.GetComponent<SpriteRenderer>().enabled = false;
                select.Play();

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
                        MoveLightning.Play();

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
                        Deathhhhh.Play();
                        DP.transform.position = new Vector3((float)x, transform.position.y, transform.position.z);
                        DP.GetComponent<SpriteRenderer>().sortingOrder = 2;
                        end = true;
                        
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
            LP.GetComponent<SpriteRenderer>().enabled = true;
        }
        else{
            LP.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
