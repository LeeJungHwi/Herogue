using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// 스킬 충돌 처리
public class AbilityBlacksmith1Collision : MonoBehaviour
{
    // 스킬 기본 데미지
    private float damage = 200f;

    // 플레이어
    private Player player;

    void Start()
    {
        // Player 스크립트
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void OnParticleCollision(GameObject other)
    {
        // 파티클 충돌
        if (other.TryGetComponent(out Enemy enemy))
        {
            // 스킬 충돌 공통 로직
            player.AbilityCollisionLogic(damage, enemy, transform);

            // 스킬 사운드
            SoundManager.instance.SFXPlay(ObjType.블랙스미스스킬2충돌소리);
        }
    }
}
