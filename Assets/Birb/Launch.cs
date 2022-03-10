using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Launch : MonoBehaviour
{
    public Dragging slingshot;

    private SpringJoint2D _spring;
    private Rigidbody2D _rigidbody2d;
    private Vector2 _previousVelocity;

    private void Awake()
    {
        _spring = GetComponent<SpringJoint2D>();
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var v = _rigidbody2d.velocity;
        if (v.sqrMagnitude < _previousVelocity.sqrMagnitude)
        {
            Destroy(_spring);
            _rigidbody2d.velocity = _previousVelocity;
            slingshot.enabled = false;
            Destroy(this);
        }
        _previousVelocity = v;
    }
}
