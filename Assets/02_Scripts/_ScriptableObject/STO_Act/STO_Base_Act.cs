using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 메뉴에 볼수 있도록 해주는것
[CreateAssetMenu(fileName = "Act_Data", menuName = "Act_Data", order = 0)]
public class STO_Base_Act : ScriptableObject
{
    [Header("STO_Base_Act")]
    // 액트 이름
    [SerializeField] string _actName;
    public string Act_Name {  get { return _actName; } set { _actName = value; } }

    // 액트 별칭
    [SerializeField] string _actNickName;
    public string Act_Nick_Name { get { return _actNickName; } set { _actNickName = value; } }

    // 상태
    [SerializeField] Animation_State _animState;
    public Animation_State Anim_State { get { return _animState; } set { _animState = value; } }

    // 액트 파워(attackPower, defensePower)
    [SerializeField] int _power;
    public int Power { get { return _power; } set { _power = value; } }

    // Projectile 여부
    [SerializeField] bool _projTrue = false;
    public bool ProjTrue { get { return _projTrue; } set { _projTrue = value; } }

    [SerializeField] Sprite _projSprite;
    public Sprite ProjSprite { get { return _projSprite; } set { _projSprite = value; } }

    [SerializeField] RuntimeAnimatorController _projController;
    public RuntimeAnimatorController ProjController { get { return _projController; } set { _projController = value; } }

}
