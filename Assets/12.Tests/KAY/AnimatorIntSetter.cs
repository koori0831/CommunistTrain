using UnityEngine;

public class AnimatorIntSetter : MonoBehaviour
{
    private Animator animator;
    private System.Action<string, int> setAnimatorInt;

    void Start()
    {
        animator = GetComponent<Animator>();
        setAnimatorInt = (paramName, value) =>
        {
            try { animator.SetInteger(paramName, value); }
            catch (System.Exception e) { Debug.LogError($"Failed to set Animator parameter: {e.Message}"); }
        }; 
    }

    void Update()
    {
    }
}
