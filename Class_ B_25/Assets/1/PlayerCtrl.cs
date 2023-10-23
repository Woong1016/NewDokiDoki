using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCtrl : MonoBehaviour
{
    private Animator anim;
    private new Transform transform;
    private Vector3 moveDir;
    private GameManager gameManager; // GameManager 스크립트 참조

    void Start()
    {
        transform = GetComponent<Transform>();
        gameManager = FindObjectOfType<GameManager>(); // GameManager 스크립트 참조 얻기
    }

    void Update()
    {
        if (moveDir != Vector3.zero)
        {
            // 진행 방향으로 회전
            transform.rotation = Quaternion.LookRotation(moveDir);
            // 회전한 후 전진 방향으로 이동
            transform.Translate(Vector3.forward * Time.deltaTime * 13.0f);
        }
    }

    void OnMove(InputValue value)
    {
        Vector2 dir = value.Get<Vector2>();
        // 2차원 좌표를 3차원 좌표로 변환
        moveDir = new Vector3(dir.x, 0, dir.y);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            // 게임 오버 조건
            gameManager.EndGame();
        }
    }
}
