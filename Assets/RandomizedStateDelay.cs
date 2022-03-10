using UnityEngine;

public class RandomizedStateDelay : StateMachineBehaviour
{
    public float lowerBound = 1;
    public float upperBound = 1;
    public string delayVar;

    #region Unity Events

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetFloat(delayVar, 1 / Random.Range(lowerBound, upperBound));
    }
    
    #endregion
}
