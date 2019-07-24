using UnityEngine;

public class BirbInput : MonoBehaviour
{
    public Dragging slingshot;

    private SpringJoint2D spring;
    private Rigidbody2D rigidbody2d;
    private Camera mainCamera;
    private Transform t;
    private CircleCollider2D circleCollider;

    private bool dragging;

    private void Awake()
    {
        t = transform;
        spring = GetComponent<SpringJoint2D>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void Start()
    {
        slingshot.UpdateRubber(circleCollider);
    }

    private void OnMouseDown()
    {
        spring.enabled = false;
        rigidbody2d.bodyType = RigidbodyType2D.Kinematic;
        dragging = true;
    }

    public void OnMouseUp()
    {
        spring.enabled = true;
        rigidbody2d.bodyType = RigidbodyType2D.Dynamic;
        dragging = false;
        Destroy(this);
        GetComponent<Launch>().enabled = true;
    }

    private void Update()
    {
        if (dragging)
        {
            var mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPosition.z = 0;
            t.position = slingshot.StretchTo(mouseWorldPosition);
            slingshot.UpdateRubber(circleCollider);
        }
    }
}
