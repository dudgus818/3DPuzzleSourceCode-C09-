using UnityEngine;

public class Objectspawner : MonoBehaviour
{
    public GameObject enemyPrefab; // 적 프리팹
    public Transform spawnLocation; // 스폰 위치 오브젝트
    public Transform player; // 플레이어 트랜스폼
    public bool shouldSpawn = false; // 적을 생성할지 여부
    private GameObject enemy; // 생성된 적
    private float initialSpeed = 1f; // 초기 적 속도
    private float speedIncreaseRate = 1.1f; // 적 속도 증가율
    private float spawnTime; // 마지막 스폰 시간

    private void Update()
    {
        if (shouldSpawn && enemy == null)
        {
            SpawnEnemy();
            spawnTime = Time.time;
        }

        if (enemy != null)
        {
            // 시간이 지남에 따라 적의 속도 증가
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
        Vector3 spawnPosition = spawnLocation.position; // 스폰 위치 설정
        enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // 적 초기화
        EnemyController enemyController = enemy.GetComponent<EnemyController>();
        if (enemyController != null)
        {
            enemyController.Initialize(player); // 플레이어 정보를 넘김
        }
    }

    // 외부에서 호출할 수 있는 메서드로 shouldSpawn 값을 설정
    public void SetShouldSpawn(bool value)
    {
        shouldSpawn = value;
    }
}