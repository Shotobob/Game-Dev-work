using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class TullyMonster67 : MonoBehaviour
{
    
    [SerializeField] Text winText;
    [SerializeField] List<Square> squares;
    private int[,] slist = {{1, 2, 3, 4}, {5, 6, 7, 8}, {9, 10, 11, 12}, {13, 14, 15, 16}};
    private int[,] checker = {{1, 2, 3, 4}, {5, 6, 7, 8}, {9, 10, 11, 12}, {13, 14, 15, 16}};
    private int switchNum = 0;
    private int moves = 0;

    [SerializeField] Text moveText;
    
    private bool win = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        winText.enabled = false;
        int counter = 0;
        while(counter != 100)
        {
            setNum();
            move();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        int wincount = 0;
        moveText.text = "Move: " + moves;
        for(int x = 0; x < slist.GetLength(0); x++)
        {
            for(int y = 0; y < slist.GetLength(1); y++)
            {
                if(slist[x,y] == checker[x,y])
                {
                    wincount++;
                }
            }
        }
        if(wincount == 16)
        {
            win = true;
            winText.enabled = true;
        }
    }
    public void setNum(int num)
    {
        switchNum = num;
    }
    public void move()
    {
        int row = 0;
        int col = 0;
 
        for(int x = 0;x < slist.GetLength(0); x++)
        {
            for(int y = 0;y < slist.GetLength(1); y++)
            {
                if(slist[x, y] == switchNum)
                {
                    row = x;
                    col = y;
                }
            
            }
        }

        if(row + 1 < 4 && row + 1 >=0)
        {
            if(slist[row + 1, col] == 16)
            {
                slist[row, col] = 16;
                slist[row + 1, col] = switchNum;
                squares[switchNum - 1].Move(row + 1, col);
                moves++;

            }
        }
        if (row - 1 < 4 && row - 1 >=0)
        {
            if(slist[row - 1, col] == 16)
            {
                slist[row, col] = 16;
                slist[row - 1, col] = switchNum;
                squares[switchNum - 1].Move(row - 1, col);
                moves++;
            }
        }
        if (col - 1 < 4 && col - 1 >=0)
        {
            if(slist[row, col - 1] == 16)
            {
                slist[row, col] = 16;
                slist[row, col - 1] = switchNum;
                squares[switchNum - 1].Move(row, col - 1);
                moves++;
            }
        }
        if (col + 1 < 4 && col + 1 >=0)
        {
            if(slist[row, col + 1] == 16)
            {
                slist[row, col] = 16;
                slist[row, col + 1] = switchNum;
                squares[switchNum - 1].Move(row, col + 1);
                moves++;
            }
        }
    }
    
}
