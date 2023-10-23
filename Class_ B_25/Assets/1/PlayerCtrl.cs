using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCtrl : MonoBehaviour
{
    private Animator anim;
    private new Transform transform;
    private Vector3 moveDir;
    private GameManager gameManager; // GameManager ��ũ��Ʈ ����

    void Start()
    {
        transform = GetComponent<Transform>();
        gameManager = FindObjectOfType<GameManager>(); // GameManager ��ũ��Ʈ ���� ���
    }

    void Update()
    {
        if (moveDir != Vector3.zero)
        {
            // ���� �������� ȸ��
            transform.rotation = Quaternion.LookRotation(moveDir);
            // ȸ���� �� ���� �������� �̵�
            transform.Translate(Vector3.forward * Time.deltaTime * 13.0f);
        }
    }

    void OnMove(InputValue value)
    {
        Vector2 dir = value.Get<Vector2>();
        // 2���� ��ǥ�� 3���� ��ǥ�� ��ȯ
        moveDir = new Vector3(dir.x, 0, dir.y);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            // ���� ���� ����
            gameManager.EndGame();
        }
    }
}
