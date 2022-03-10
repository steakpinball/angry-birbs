using UnityEngine;
using UnityEngine.Events;

public class ClickDetector : MonoBehaviour
{
    public UnityEvent onMouseDown;
    public UnityEvent onMouseUp;

    #region Unity Events

    private void OnMouseDown()
    {
        onMouseDown.Invoke();
    }

    private void OnMouseUp()
    {
        onMouseUp.Invoke();
    }

    #endregion
}
