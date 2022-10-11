using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingPlatfromOneWay : MonoBehaviour
{
    [SerializeField]
    private Transform platfrom;
    [SerializeField]
    private Transform endPoint;

    [SerializeField, Range(0, 100), Tooltip("How long it takes to Move")]
    float Time;


    private void Awake()
    {
        
    }

    private void Start()
    {
        //platfrom.DOMove(endPoint.transform.position, 5f, false);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            platfrom.DOMove(endPoint.transform.position, Time, false).SetEase(Ease.Unset); 
        }
    }
}
