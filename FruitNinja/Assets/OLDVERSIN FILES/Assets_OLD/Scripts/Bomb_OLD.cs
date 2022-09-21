using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_OLD : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<GameManager_OLD>().Explode();  
        }
    }

}
