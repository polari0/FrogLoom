using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrogLoom
{
    public class Collectables : MonoBehaviour
    {
        [SerializeField]
        GameObject collectableItem;

        [SerializeField, Range(0, 1000)]
        public int pointAmount;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                IncreasePoints(); 
                collectableItem.SetActive(false);
            }

        }

        private void IncreasePoints()
        {
            pointAmount++;
            //increase value on UI 
        }
    } 
}
