using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; // �Ѿ� ������
    public string targetTag = "Player"; // �Ѿ��� �߻��� ����� �±�
    public float fireRate = 1.0f; // �߻� ���� (��)
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
            // ����� �ִ� ���
            Vector3 targetPosition = targets[Random.Range(0, targets.Length)].transform.position;
            Quaternion spawnRotation = Quaternion.LookRotation(targetPosition - transform.position);
            Instantiate(bulletPrefab, transform.position, spawnRotation);
        }
    }
}
