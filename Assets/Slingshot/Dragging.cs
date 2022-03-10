using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Dragging : MonoBehaviour
{
    [FormerlySerializedAs("strechLimit")] public float stretchLimit = 5;
    public CircleCollider2D contents;

    [SerializeField] private LineRenderer front;
    [SerializeField] private LineRenderer back;

    [SerializeField] private Transform spring;

    public Vector2 StretchTo(Vector2 position)
    {
        Vector2 p = spring.position;
        var difference = position - p;

        if (difference.sqrMagnitude > stretchLimit * stretchLimit)
        {
            return difference.normalized * stretchLimit + p;
        }

        return position;
    }

    public void UpdateRubber(CircleCollider2D c)
    {
        var t = c.transform;
        var radius = c.radius * t.localScale.x;
        var cp = t.position;
        var fOffset = cp - front.transform.position;
        front.SetPosition(1, cp + fOffset.normalized * radius);
        var bOffset = cp - back.transform.position;
        back.SetPosition(1, cp + bOffset.normalized * radius);
    }

    #region Unity Events
    
    private void Start()
    {
        front.SetPosition(0, front.transform.position);
        back.SetPosition(0, back.transform.position);
    }

    public void OnEnable()
    {
        front.enabled = true;
        back.enabled = true;
    }

    public void OnDisable()
    {
        front.enabled = false;
        back.enabled = false;
    }
    
    private void Update()
    {
        UpdateRubber(contents);
    }

    #endregion
}
