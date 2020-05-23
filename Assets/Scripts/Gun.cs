using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public string gunName; // 총 이름
    public float range; // 사정거리
    public float accuracy; // 정확도
    public float fireRate; //연사속도
    public float reloadTime; // 재장전 속도

    public int damage;// 데미지

    public int reloadBulletCount; // 총알 재장전 개수
    public int currentBulletCount; //  현재 탄알집에 남아있는 총알 개수
    public int maxBulletCount; // 최대 소유 가능한 총알 개수
    public int carryBulletCount; // 현재 소유하고 있는 총알 개수

    public float retroActionForce; // 반동 세기
    public float retroActionFineSightForce; // 정조준시의 반동 세기

    public Vector3 fineSightOriginPos;
    public Animator anim; // 애니메이션
    public ParticleSystem muzzleFlash; // 총구 섬광

    public AudioClip fire_Sound; // 총 발사 시 소리

}
