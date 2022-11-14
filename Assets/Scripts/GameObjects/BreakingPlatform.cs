using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingPlatform : MonoBehaviour
{
    [SerializeField, Tooltip("This should be the platfromsprite")]
    GameObject breakingPlatform;
    [SerializeField, Tooltip("This should be the BoxColliderOnparent")]
    Collider breakingPlatformCollider;
    [SerializeField, Range(1, 10)]
    int breakingTime;
    [SerializeField, Range(1, 10)]
    int RegenTime;

    bool isActive = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && isActive)
        {
            StartCoroutine(breakingTimer());
        }
    }

    private IEnumerator RegenerationTime()
    {
        Debug.Log("here We Go");
        if (!isActive)
        {
            Debug.Log("De We go here?");
            yield return new WaitForSeconds(RegenTime);
            breakingPlatform.SetActive(true);
            breakingPlatformCollider.enabled = true;
            isActive = true;
        }
    }
    IEnumerator breakingTimer()
    {
        if (isActive)
        {
            yield return new WaitForSeconds(breakingTime);
            breakingPlatform.SetActive(false);
            breakingPlatformCollider.enabled = false;
            isActive = false;
            StartCoroutine(RegenerationTime());

            Debug.Log(isActive);
            
        }
    }

}
