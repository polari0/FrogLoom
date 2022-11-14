using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandonNumberGen : MonoBehaviour
{

    private int amountOfSets;
    private List<int> lotteryNumbers = new List<int>();
    int listPosition;

    private void Start()
    {
        RandomNumbers();
        Debug.Log(lotteryNumbers);
    }
    private void RandomNumbers()
    {
        for (int i = 0; i <= 6; i ++)
        {
            lotteryNumbers.Insert(listPosition, Random.Range(1, 40));
            listPosition++;
        }
    }

}
