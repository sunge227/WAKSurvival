using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWeapon : MonoBehaviour
{
    public string closeWeaponName; // ex) 근접 무기 이름


    //근접 무기 유형
    public bool isHand; //손
    public bool isAxe; // 도끼
    public bool isPickaxe; // 곡괭이

    public float range; // 공격 범위
    public int damage; // 공격력
    public float workSpeed; // 작업 속도
    public float attackDelay; // 공격 딜레이
    public float attackDelayA; // 공격 활성화 시점 딜레이
    public float attackDelayB; // 공격 비활성화 시점 딜레이

    public Animator anim; // 애니메이션
    public BoxCollider boxCollider;
}
