using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;  // �÷��̾��� Transform
    public float speed = 1.0f;  // ���� �ӵ�

    void Update()
    {
        if (player != null)
        {
            // �÷��̾� �������� �̵�
            Vector3 direction = player.position - transform.position;
            direction.Normalize();
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
