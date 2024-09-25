using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ontrigger : MonoBehaviour
{
    private MeshRenderer cubeRenderer;
    private Material materialInstance;

    void Start()
    {
        cubeRenderer = GetComponent<MeshRenderer>(); // MeshRenderer 가져오기
        materialInstance = cubeRenderer.material; // Material 인스턴스 생성
    }

    // 트리거에 들어왔을 때 호출되는 함수
    void OnTriggerEnter(Collider other)
    {
        // 충돌한 오브젝트가 "Player" 태그를 가지고 있을 경우
        if (other.CompareTag("Player"))
        {
            // 색상을 랜덤하게 변경
            materialInstance.color = new Color(Random.value, Random.value, Random.value);
        }
    }
}
