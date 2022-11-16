using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandIK : MonoBehaviour
{
    
    [SerializeField,Header("右手を置く場所")] Transform _rightTarget;
    [SerializeField,Header("左手を置く場所")] Transform _leftTarget;
    /// <summary>右手の Position に対するウェイト</summary>
    [SerializeField, Range(0f, 1f)] float _rightPosWeight = 0;
    /// <summary>右手の Rotation に対するウェイト</summary>
    [SerializeField, Range(0f, 1f)] float _rightRotWeight = 0;
    /// <summary>左手の Position に対するウェイト</summary>
    [SerializeField, Range(0f, 1f)] float _leftPosWeight = 0;
    /// <summary>左手の Rotation に対するウェイト</summary>
    [SerializeField, Range(0f, 1f)] float _leftRotWeight = 0;
    Animator _anim;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    void OnAnimatorIK(int layerIndex)
    {
        // 右手
        _anim.SetIKPositionWeight(AvatarIKGoal.RightHand, _rightPosWeight);
        _anim.SetIKRotationWeight(AvatarIKGoal.RightHand, _rightRotWeight);
        _anim.SetIKPosition(AvatarIKGoal.RightHand, _rightTarget.position);
        _anim.SetIKRotation(AvatarIKGoal.RightHand, _rightTarget.rotation);
        // 左手
        _anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, _leftPosWeight);
        _anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, _leftRotWeight);
        _anim.SetIKPosition(AvatarIKGoal.LeftHand, _leftTarget.position);
        _anim.SetIKRotation(AvatarIKGoal.LeftHand, _leftTarget.rotation);
    }
}
