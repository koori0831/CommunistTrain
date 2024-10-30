using System;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    private Animator _anim;
    private ClickToMove _clickToMove;
    private int _runHesh, _idleHesh;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _clickToMove = GetComponentInParent<ClickToMove>();
        _runHesh = Animator.StringToHash("IsRun");
        _idleHesh = Animator.StringToHash("IsIdle");
    }

    private void OnEnable()
    {
        _clickToMove.OnMoveStart += SetMoveAnim;
        _clickToMove.OnArrive += SetIdleAnim;
    }

    private void SetIdleAnim()
    {
        _anim.SetBool("IsIdle", true);
        _anim.SetBool("IsRun", false);
    }

    private void OnDisable()
    {
        _clickToMove.OnMoveStart -= SetMoveAnim;
        _clickToMove.OnArrive -= SetIdleAnim;
    }

    private void SetMoveAnim()
    {
        _anim.SetBool("IsRun", true);
        _anim.SetBool("IsIdle", false);
    }
}
