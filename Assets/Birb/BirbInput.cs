using UnityEngine;

[RequireComponent(typeof(Launch))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpringJoint2D))]
public class BirbInput : MonoBehaviour
{
    public float mass = 10;
    public Dragging slingshot;

    private SpringJoint2D _spring;
    private Rigidbody2D _rigidbody2d;
    private Camera _mainCamera;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        _spring = GetComponent<SpringJoint2D>();
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _mainCamera = Camera.main;
    }

    public void Launch()
    {
        _rigidbody2d.bodyType = RigidbodyType2D.Dynamic;
        _rigidbody2d.mass = mass;
        Destroy(this);
        GetComponent<Launch>().enabled = true;
    }

    private void Update()
    {
        var mouseWorldPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;
        _transform.position = slingshot.StretchTo(mouseWorldPosition);
    }
}
