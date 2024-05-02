using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void LateUpdate()
    {
        transform.position = _target.position;
    }
}
