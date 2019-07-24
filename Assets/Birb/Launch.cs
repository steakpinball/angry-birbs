using UnityEngine;

public class Launch : MonoBehaviour
{
    public Dragging slingshot;

    private SpringJoint2D spring;
    private Rigidbody2D rigidbody2d;
    private Vector2 previousVelocity;
    private CircleCollider2D circleCollider;

    private bool dragging;

    private void Awake()
    {
        spring = GetComponent<SpringJoint2D>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        var v = rigidbody2d.velocity;
        if (v.sqrMagnitude < previousVelocity.sqrMagnitude)
        {
            Destroy(spring);
            rigidbody2d.velocity = previousVelocity;
            slingshot.Disconnect();
            Destroy(this);
        }
        slingshot.UpdateRubber(circleCollider);
        previousVelocity = v;
    }
}
