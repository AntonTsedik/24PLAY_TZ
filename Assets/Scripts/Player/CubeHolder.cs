using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CubeHolder : MonoBehaviour
{
    [SerializeField] GameObject GameOver;
    [SerializeField] Transform StickMan;
    [SerializeField] Transform StackParent;

    private Animator animator;

    List<GameObject> Cubes;
    private void Awake()
    {
        Cubes = new List<GameObject>();
        animator = StickMan.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider cube)
    {

        if (cube.transform.CompareTag("YellowCube"))
        {
            animator.SetTrigger("Jump");

            if (Cubes.Contains(cube.gameObject))
            {
                return;
            }

            cube.transform.gameObject.layer = LayerMask.NameToLayer("CubeStack");
            Cubes.Insert(0, cube.gameObject);
            cube.transform.SetParent(StackParent);

            if (Cubes.Count > 1)
            {
                cube.transform.localPosition = Cubes[1].transform.localPosition;
            }

            for (int i = 1; i < Cubes.Count; i++)
            {
                Cubes[i].transform.localPosition = Cubes[i].transform.localPosition + Vector3.up * 1.05f;
            }

            StickMan.position += Vector3.up * 1.05f;
            cube.GetComponent<YellowCube>().SetCubeHolder(this);
        }
    }
    public async void CubesDecrese(GameObject yellowcube)
    {
        await Task.Delay(System.TimeSpan.FromSeconds(0.25));
        int index = Cubes.IndexOf(yellowcube);

        if (index == -1)
        {
            return;
        }

        Cubes.RemoveAt(index);

        for (int i = index; i < Cubes.Count; i++)
        {
            Cubes[i].transform.localPosition = Cubes[i].transform.localPosition + Vector3.down * 1.05f;
        }

        StickMan.position += Vector3.down * 1.05f;

        if (Cubes.Count == 0)
        {
            Time.timeScale = 0;
            GameOver.SetActive(true);
        }
    }
}
