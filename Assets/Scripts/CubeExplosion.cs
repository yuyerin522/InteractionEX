using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeExplosion : MonoBehaviour
{
    public GameObject explosionEffectPrefab; // 폭발 파티클 효과 프리팹
    public float explosionForce = 500f; // 폭발력
    public float explosionRadius = 5f; // 폭발 범위

    void OnTriggerEnter(Collider other)
    {
        // 만약 플레이어가 큐브에 닿았다면
        if (other.CompareTag("Player"))
        {
            Explode(); // 큐브 폭발 실행
        }
    }

    void Explode()
    {
        // 폭발 효과 생성
        GameObject explosionEffect = Instantiate(explosionEffectPrefab, transform.position, transform.rotation);

        // 파티클이 다 끝나면 폭발 효과 오브젝트 삭제
        Destroy(explosionEffect, 3f); // 파티클 오브젝트 삭제

        // 주변 오브젝트에 폭발력 전달
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }

        // 큐브를 파괴
        Destroy(gameObject);
    }
}
