using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 0.01f; // 총알 이동 속도

    void Update()
    {
        // 총알을 앞으로 이동
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            Debug.Log("삭제");
            // 벽과 충돌 시 총알 삭제
            Destroy(gameObject);
        }
    }
}
