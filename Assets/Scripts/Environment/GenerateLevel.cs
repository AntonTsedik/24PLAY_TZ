using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    [SerializeField] GameObject[] section;
    private int zPos = 60;
    private bool createSection = false;
    private int sectionNumber;

    private void Update()
    {
        if (createSection == false)
        {
            createSection = true;
            StartCoroutine(GenerateSection());
        }
    }

    IEnumerator GenerateSection()
    {
        sectionNumber = Random.Range(0, 5);
        Instantiate(section[sectionNumber], new Vector3(0,0,zPos), Quaternion.identity);
        zPos += 30;
        yield return new WaitForSeconds(4);
        createSection = false;
    }
}
