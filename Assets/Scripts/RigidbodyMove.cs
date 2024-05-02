using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyMove : MonoBehaviour
{
    private const string Run = "Run";

    [SerializeField] private float _speed = 5f;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Animator _animator;
 
    private Rigidbody _rigidbody;
    private Vector2 _moveInput;

    private void Awake()
    {
        _rigidbody= GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _moveInput = _joystick.Value;

        _animator.SetBool(Run, _joystick.IsPressed);        
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_moveInput.x, 0f, _moveInput.y) * _speed;

        if (_rigidbody.velocity != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity, Vector3.up);
        }
    }
}
