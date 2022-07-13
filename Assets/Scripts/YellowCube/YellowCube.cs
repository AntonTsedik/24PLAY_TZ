using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowCube : MonoBehaviour
{
    CubeHolder cubeholder;

    public void SetCubeHolder(CubeHolder cubeholder)
    {
        this.cubeholder = cubeholder;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RedCube"))
        {
            cubeholder.CubesDecrese(this.gameObject);
            transform.SetParent(null);
        }
    }

}
