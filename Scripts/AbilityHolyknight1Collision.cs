using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// 스킬 충돌 처리
public class AbilityHolyknight1Collision : MonoBehaviour
{
    // 스킬 기본 데미지
    private float damage = 100f;

    // 플레이어
    private Player player;

    // 오브젝트 풀링
    private PoolingManager poolingManager;

    // 파티클 시스템
    private ParticleSystem particleSystem;

    // 충돌 이벤트를 저장 할 리스트
    List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();

    // 충돌시 생성할 이펙트
    public GameObject instantHit;

    void Start()
    {
        // 파티클 시스템
        particleSystem = GetComponent<ParticleSystem>();

        // Player 스크립트
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        // PoolingManager 스크립트
        poolingManager = GameObject.FindGameObjectWithTag("PoolManager").GetComponent<PoolingManager>();
    }

    void OnParticleCollision(GameObject other)
    {
        // 파티클 충돌
        // 파티클 충돌 이벤트의 수
        int events = particleSystem.GetCollisionEvents(other, collisionEvents);

        for (int i = 0; i < events; i++)
        {
            // 충돌 이벤트 수에따라 충돌시 생성할 이펙트
            instantHit = poolingManager.GetObj("AbilityHolyknight1Hit");
            instantHit.transform.position = collisionEvents[i].intersection;
            instantHit.transform.rotation = Quaternion.LookRotation(collisionEvents[i].normal);

            // 스킬 사운드
            SoundManager.instance.SFXPlay("HolyknightSkill1Sound");
        }

        if (other.TryGetComponent(out Enemy enemy))
        {
            // 스킬 충돌 공통 로직
            player.AbilityCollisionLogic(damage, enemy, transform);
        }
    }
}
