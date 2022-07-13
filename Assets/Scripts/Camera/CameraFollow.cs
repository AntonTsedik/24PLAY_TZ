using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;

    private void LateUpdate()
    {
        transform.position = new Vector3(0, 0, target.position.z) + offset ;
    }
}
