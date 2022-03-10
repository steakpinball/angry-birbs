using UnityEngine;

public class PigController : MonoBehaviour
{
    private static readonly int HealthId = Animator.StringToHash("health");

    private Animator _animator;
    private Health _health;

    public void HandleHealthChange(float value)
    {
        _animator.SetFloat(HealthId, value);
    }

    #region Unity Events

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _health = GetComponent<Health>();
    }

    private void Start()
    {
        _animator.SetFloat(HealthId, _health.CurrentHealth);
    }

    #endregion
}
