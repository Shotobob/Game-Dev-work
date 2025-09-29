using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;


public class TullyMonster67 : MonoBehaviour
{
    [SerializeField] List<Pole> poles;
    public int selectedPole = -1;
    [SerializeField] Text moves;
    [SerializeField] Text win;
    public int movesNum = 0;
    public bool end = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        win.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        moves.text = "Moves: " + movesNum;
        if (poles[2].getRings().Count == 5)
        {
            end = true;
            win.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.R) && end == true)
        {
            movesNum = 0;
            for(int i = 4; i >= 0; i--)
            {
                
                poles[2].getRings()[i].move(-5.5f, -3.5f + 0.8f * poles[0].getRings().Count);
                poles[0].addRings(poles[2].getRings()[i]);
            }
            poles[2].getRings().Clear();
            end = false;
            win.enabled = false;

        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            poles[2].addRings(poles[0].getRings()[4]);
            poles[2].addRings(poles[0].getRings()[3]);
            poles[2].addRings(poles[0].getRings()[2]);
            poles[2].addRings(poles[0].getRings()[1]);
            poles[2].addRings(poles[0].getRings()[0]);
            poles[0].getRings().Clear();
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
                poles[pole].setColor();
            }
            else if (selectedPole == pole)
            {
                selectedPole = -1;
                poles[pole].setSelected(false);
                poles[pole].setColor();
            }
            else
            {
                poles[selectedPole].setSelected(false);
                poles[selectedPole].setColor();

                if (poles[selectedPole].getRings().Count != 0)
                {
                    if (poles[pole].getRings().Count == 0 || poles[selectedPole].getRings()[0].getWeight() < poles[pole].getRings()[0].getWeight())
                    {

                        for (int i = 0; i < poles[pole].getRings().Count; i++)
                        {
                            y += 0.8;
                        }
                        Rings movedRing = poles[selectedPole].getRings()[0];
                        if (pole == 0)
                        {
                            x = -5.5;
                            movedRing.move((float)x, (float)y);

                        }
                        if (pole == 1)
                        {
                            x = 0;
                            movedRing.move((float)x, (float)y);

                        }
                        if (pole == 2)
                        {
                            x = 5.5;
                            movedRing.move((float)x, (float)y);
                        }
                        poles[pole].addRings(poles[selectedPole].getRings()[0]);
                        poles[selectedPole].removeRings();
                        movesNum++;

                    }
                }


                selectedPole = -1;
                poles[pole].setSelected(false);
                poles[pole].setColor();

            }
        }

        
    }
}
