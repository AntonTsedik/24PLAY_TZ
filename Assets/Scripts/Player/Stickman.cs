using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stickman : MonoBehaviour
{
    [SerializeField] GameObject GameOver;


    private void OnTriggerEnter(Collider cube)
    {
        if (cube.gameObject.CompareTag("RedCube"))
        {
            Time.timeScale = 0;
            GameOver.SetActive(true);
        }
    }
}
