using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ontrigger : MonoBehaviour
{
    private MeshRenderer cubeRenderer;
    private Material materialInstance;

    void Start()
    {
        cubeRenderer = GetComponent<MeshRenderer>(); // MeshRenderer ��������
        materialInstance = cubeRenderer.material; // Material �ν��Ͻ� ����
    }

    // Ʈ���ſ� ������ �� ȣ��Ǵ� �Լ�
    void OnTriggerEnter(Collider other)
    {
        // �浹�� ������Ʈ�� "Player" �±׸� ������ ���� ���
        if (other.CompareTag("Player"))
        {
            // ������ �����ϰ� ����
            materialInstance.color = new Color(Random.value, Random.value, Random.value);
        }
    }
}
