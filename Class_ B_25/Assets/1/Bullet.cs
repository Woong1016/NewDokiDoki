using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 0.01f; // �Ѿ� �̵� �ӵ�

    void Update()
    {
        // �Ѿ��� ������ �̵�
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            Debug.Log("����");
            // ���� �浹 �� �Ѿ� ����
            Destroy(gameObject);
        }
    }
}
