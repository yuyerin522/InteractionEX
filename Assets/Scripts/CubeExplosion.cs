using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeExplosion : MonoBehaviour
{
    public GameObject explosionEffectPrefab; // ���� ��ƼŬ ȿ�� ������
    public float explosionForce = 500f; // ���߷�
    public float explosionRadius = 5f; // ���� ����

    void OnTriggerEnter(Collider other)
    {
        // ���� �÷��̾ ť�꿡 ��Ҵٸ�
        if (other.CompareTag("Player"))
        {
            Explode(); // ť�� ���� ����
        }
    }

    void Explode()
    {
        // ���� ȿ�� ����
        GameObject explosionEffect = Instantiate(explosionEffectPrefab, transform.position, transform.rotation);

        // ��ƼŬ�� �� ������ ���� ȿ�� ������Ʈ ����
        Destroy(explosionEffect, 3f); // ��ƼŬ ������Ʈ ����

        // �ֺ� ������Ʈ�� ���߷� ����
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }

        // ť�긦 �ı�
        Destroy(gameObject);
    }
}
