using UnityEngine;
using System.Collections;

public class OrbitCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    public float rotSpeed = 1.5f;
    private float _rotX;
    private Vector3 _offset;

    void Start()
    {
        _rotX = transform.eulerAngles.x;
        _offset = target.position - transform.position;
    }

    void LateUpdate()
    {
        float vertInput = Input.GetAxis("Vertical");
        if (vertInput != 0)
        {
            _rotX += vertInput * rotSpeed;
        }
        else
        {
            _rotX += Input.GetAxis("Mouse Y") * rotSpeed * 3;
        }

        Quaternion rotation = Quaternion.Euler(0, _rotX, 0);
        transform.position = target.position - (rotation * _offset);
        transform.LookAt(target);
    }
}


