using UnityEngine;

public class Dragging : MonoBehaviour
{
    public float strechLimit = 5;

    [SerializeField] private LineRenderer front;
    [SerializeField] private LineRenderer back;

    [SerializeField] private Transform spring;

    private void Start()
    {
        front.SetPosition(0, front.transform.position);
        back.SetPosition(0, back.transform.position);
    }

    public Vector2 StretchTo(Vector2 position)
    {
        Vector2 p = spring.position;
        var difference = position - p;

        if (difference.sqrMagnitude > strechLimit * strechLimit)
        {
            return difference.normalized * strechLimit + p;
        }

        return position;
    }

    public void UpdateRubber(CircleCollider2D c)
    {
        var radius = c.radius * c.transform.localScale.x;
        var cp = c.transform.position;
        var fOffset = cp - front.transform.position;
        front.SetPosition(1, cp + fOffset.normalized * radius);
        var bOffset = cp - back.transform.position;
        back.SetPosition(1, cp + bOffset.normalized * radius);
    }

    public void Disconnect()
    {
        front.enabled = false;
        back.enabled = false;
    }
}
