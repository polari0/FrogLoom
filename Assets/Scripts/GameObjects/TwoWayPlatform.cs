using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TwoWayPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform platfrom;
    [SerializeField]
    private Transform endPoint;
    [SerializeField]
    private Transform startingPoint;

    
    [SerializeField, Range(0, 100), Tooltip("How long it takes to move")]
    float Time;

    bool playerIsthouching = false;

    TweenParams infiniteLoop = new TweenParams().SetLoops(-1);
    
    private void Awake()
    {
        Sequence loopingPlatform = DOTween.Sequence();
        loopingPlatform.Append(platfrom.DOMove(endPoint.transform.position, Time, false))
        .Append(platfrom.DOMove(startingPoint.transform.position, Time, false)).SetAs(infiniteLoop);

    }

    private void Start()
    {
        
    }
    //private void OnTriggerEnter2D(Collider2D collider)
    //{

    //    if (collider.tag == "Player" && !playerIsthouching)
    //    {
    //        playerIsthouching = true;
    //        platfrom.DOMove(endPoint.transform.position, speed, false);
    //    }
    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player" && playerIsthouching == true)
    //    {
    //        playerIsthouching = false;

    //    }
    //}
}
