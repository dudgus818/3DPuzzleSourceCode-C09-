using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;  // 플레이어의 Transform
    public float speed = 1.0f;  // 추적 속도

    void Update()
    {
        if (player != null)
        {
            // 플레이어 방향으로 이동
            Vector3 direction = player.position - transform.position;
            direction.Normalize();
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
