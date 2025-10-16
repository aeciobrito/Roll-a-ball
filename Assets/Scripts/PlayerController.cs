using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private float speed = 10.0f;
    private Rigidbody _rigidbody;
    private Vector2 movementVector;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        _rigidbody.AddForce(new Vector3(movementVector.x, 0.0f, movementVector.y) * speed);
    }

    void OnMove(InputValue movementValue)
    {
        movementVector = movementValue.Get<Vector2>();
    }
}
