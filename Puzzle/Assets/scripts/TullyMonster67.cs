using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;





public class TullyMonster67 : MonoBehaviour
{
    
    
    [SerializeField] List<Square> sList;
    private int[,] slist = {{1, 2, 3, 4}, {5, 6, 7, 8}, {9, 10, 11, 12}, {13, 14, 15, 16}};
    private int switchNum = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setNum(int num)
    {
        switchNum = num;
    }
    public void move()
    {
        int row = 0;
        int col = 0;
        int row16 = 0;
        int col16 = 0;
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
        for(int x = 0;x < slist.GetLength(0); x++)
        {
            for(int y = 0;y < slist.GetLength(1); y++)
            {
                if(slist[x, y] == 16)
                {
                    row16 = x;
                    col16 = y;
                }
            
            }
        }
        if(row + 1 < 4 && row + 1 >=0)
        {
            if(slist[row + 1, col] == 16)
            {
                slist[row + 1, col] = 16;
                slist[row16, col16] = switchNum;
            }
        }
        else if (row - 1 < 4 && row - 1 >=0)
        {
            if(slist[row - 1, col] == 16)
            {
                slist[row - 1, col] = 16;
                slist[row16, col16] = switchNum;
            }
        }
        else if (col - 1 < 4 && col - 1 >=0)
        {
            if(slist[row, col - 1] == 16)
            {
                slist[row, col - 1] = 16;
                slist[row16, col16] = switchNum;
            }
        }
        else if (col + 1 < 4 && col + 1 >=0)
        {
            if(slist[row, col - 1] == 16)
            {
                slist[row, col - 1] = 16;
                slist[row16, col16] = switchNum;
            }
        }
    }
}
