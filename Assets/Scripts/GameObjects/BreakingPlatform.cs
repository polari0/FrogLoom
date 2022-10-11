using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingPlatform : MonoBehaviour
{
    [SerializeField, Tooltip("This should be the platfromsprite")]
    GameObject breakingPlatform;

    [SerializeField, Range(1, 10)]
    int breakingTime;
    [SerializeField, Range(1, 10)]
    int RegenTime;

    bool isActive = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && isActive)
        {
            StartCoroutine(breakingTimer());
        }
    }

    IEnumerator RegenerationTime()
    {
        Debug.Log("here We Go");
        if (!isActive)
        {
            Debug.Log("De We go here?");
            yield return new WaitForSeconds(RegenTime);
            breakingPlatform.SetActive(true);
            isActive = true;
        }
    }
    IEnumerator breakingTimer()
    {
        if (isActive)
        {
            yield return new WaitForSeconds(breakingTime);
            breakingPlatform.SetActive(false);
            isActive = false;
            StartCoroutine(RegenerationTime());

            Debug.Log(isActive);
            
        }
    }

}
