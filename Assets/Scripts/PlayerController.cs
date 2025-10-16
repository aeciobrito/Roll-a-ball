using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private float _speed = 10.0f;
    private int _count = 0;
    public GameObject winTextObject;
    public TextMeshProUGUI _countText;
    private Rigidbody _rigidbody;
    private Vector2 movementVector = Vector2.zero;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _countText.text = $"Count: {_count}";
        winTextObject.SetActive(false);
    }

    void FixedUpdate()
    {
        _rigidbody.AddForce(new Vector3(movementVector.x, 0.0f, movementVector.y) * _speed);
    }

    void OnMove(InputValue movementValue)
    {
        movementVector = movementValue.Get<Vector2>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            _count++;
            _countText.text = $"Count: {_count}";
            if (_count >= 12)
                winTextObject.SetActive(true);
        }   
    }
}
