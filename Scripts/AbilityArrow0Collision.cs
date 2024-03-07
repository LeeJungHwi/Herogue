using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// 스킬 충돌 처리
public class AbilityArrow0Collision : MonoBehaviour
{
    // 스킬 데미지
    private float damage = 500f;

    // 플레이어
    private Player player;

    // 오브젝트 풀
    private PoolingManager poolingManager;

    // 충돌 이펙트
    public GameObject instantHit;

    void Start()
    {
        // 플레이어
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        // 오브젝트 풀
        poolingManager = GameObject.FindGameObjectWithTag("PoolManager").GetComponent<PoolingManager>();
    }

    void OnParticleCollision(GameObject other)
    {
        // 파티클 충돌
        if(other.TryGetComponent(out Enemy enemy))
        {
            // 스킬 충돌 공통 로직
            player.AbilityCollisionLogic(damage, enemy, transform);

            // 충돌 이펙트 활성화
            instantHit = poolingManager.GetObj("AbilityArrow0Hit");
            instantHit.transform.position = enemy.transform.position + enemy.transform.up * 10f;
            instantHit.transform.rotation = poolingManager.AbilityArrow0HitPrefab.transform.rotation;

            // 스킬 충돌 사운드
            SoundManager.instance.SFXPlay("ArrowSkill0HitSound");
        }
    }
}
