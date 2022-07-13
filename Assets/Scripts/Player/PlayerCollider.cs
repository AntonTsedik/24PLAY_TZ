using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] GameObject GameOver;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RedCube"))
        {
            Time.timeScale = 0;
            GameOver.SetActive(true);
        }
    }
}
