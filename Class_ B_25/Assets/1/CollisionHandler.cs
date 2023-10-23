using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; // 총알 프리팹
    public string targetTag = "Player"; // 총알을 발사할 대상의 태그
    public float fireRate = 1.0f; // 발사 간격 (초)
    private float nextFireTime = 0.0f;

    private void Update()
    {
        if (Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            FireBullet();
        }
    }

    private void FireBullet()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);

        if (targets.Length > 0)
        {
            // 대상이 있는 경우
            Vector3 targetPosition = targets[Random.Range(0, targets.Length)].transform.position;
            Quaternion spawnRotation = Quaternion.LookRotation(targetPosition - transform.position);
            Instantiate(bulletPrefab, transform.position, spawnRotation);
        }
    }
}
