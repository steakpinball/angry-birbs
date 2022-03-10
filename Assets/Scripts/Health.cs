using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float impactScale = 0.1f;
    
    [SerializeField] private float currentHealth = 1;

    public float CurrentHealth
    {
        get => currentHealth;
        set
        {
            var shouldDie = value <= 0;
            currentHealth = shouldDie ? 0 : value;
            healthChanged.Invoke(currentHealth);
            if (shouldDie) died.Invoke();
        }
    }

    public UnityEvent<float> healthChanged;

    public UnityEvent died;

    #region Unity Events

    private void OnCollisionEnter2D(Collision2D col)
    {
        CurrentHealth -= col.GetContact(0).normalImpulse * impactScale;
    }

    #endregion
}
