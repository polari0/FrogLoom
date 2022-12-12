using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockModule : MonoBehaviour
{
    [SerializeField] float m_BlockCooldownTimer;
    [SerializeField] float m_BlockLenghtTimer = 2;
    [SerializeField] bool m_BlockResetTimer = true;
    [SerializeField] GameObject m_BlockCollider;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && m_BlockResetTimer)
        {
            Debug.Log("Yeehaw");
            m_BlockCollider.SetActive(true);
            m_BlockResetTimer = false;
            StartCoroutine(blockCooldown());
        }
    }

    IEnumerator blockCooldown()
    {
        if (!m_BlockResetTimer)
        {
            yield return new WaitForSeconds(m_BlockLenghtTimer);
            m_BlockResetTimer = true;
            m_BlockCollider.SetActive(false);
            StopCoroutine(blockCooldown());
        }
        else if (m_BlockResetTimer)
        {
            yield return null;
            StopCoroutine(blockCooldown());
        }
    }

}
