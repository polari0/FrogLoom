using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingPlatfromOneWay : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D platfrom;
    [SerializeField]
    private Transform endPoint;



    private float posX, posY;


    private void Awake()
    {
        posX = endPoint.transform.position.x;
        posY = endPoint.transform.position.y;
    }
    private void Start()
    {
        platfrom.DOMove(new Vector2(posX, posY), 5f, false);
    }
}
