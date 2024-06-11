using UnityEngine;

public class Objectspawner : MonoBehaviour
{
    public GameObject enemyPrefab; // �� ������
    public Transform spawnLocation; // ���� ��ġ ������Ʈ
    public Transform player; // �÷��̾� Ʈ������
    public bool shouldSpawn = false; // ���� �������� ����
    private GameObject enemy; // ������ ��
    private float initialSpeed = 1f; // �ʱ� �� �ӵ�
    private float speedIncreaseRate = 1.1f; // �� �ӵ� ������
    private float spawnTime; // ������ ���� �ð�

    private void Update()
    {
        if (shouldSpawn && enemy == null)
        {
            SpawnEnemy();
            spawnTime = Time.time;
        }

        if (enemy != null)
        {
            // �ð��� ������ ���� ���� �ӵ� ����
            float timeSinceSpawn = Time.time - spawnTime;
            EnemyController enemyController = enemy.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                float newSpeed = initialSpeed * Mathf.Pow(speedIncreaseRate, timeSinceSpawn);
                enemyController.SetSpeed(newSpeed);
            }
        }
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = spawnLocation.position; // ���� ��ġ ����
        enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // �� �ʱ�ȭ
        EnemyController enemyController = enemy.GetComponent<EnemyController>();
        if (enemyController != null)
        {
            enemyController.Initialize(player); // �÷��̾� ������ �ѱ�
        }
    }

    // �ܺο��� ȣ���� �� �ִ� �޼���� shouldSpawn ���� ����
    public void SetShouldSpawn(bool value)
    {
        shouldSpawn = value;
    }
}