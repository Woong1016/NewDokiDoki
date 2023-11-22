using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Player = Photon.Realtime.Player;

public class Damage : MonoBehaviourPunCallbacks
{
    private Renderer[] renderers;

    private int initHP = 100;
    public int currHP = 100;

    private Animator animator;
    private CharacterController cc;

    private readonly int hashDie = Animator.StringToHash("Die");
    private readonly int hashRespawn = Animator.StringToHash("Respawn");

    GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
        animator = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();

        currHP = initHP;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (currHP <= 0)
        {
            // �ڽ��� PhotonView �� ���� �޽����� ���
            if (photonView.IsMine)
            {
                // �Ѿ��� ActorNumber�� ����
                var actorNo = collision.collider.GetComponent<Bullet>().actorNumber;
                // ActorNumber�� ���� �뿡 ������ �÷��̾ ����
                Player lastShootPlayer = PhotonNetwork.CurrentRoom.GetPlayer(actorNo);
                // �޽��� ����� ���� ���ڿ� ����
                string msg = string.Format("\n<color=#00ff00>{0}</color> is killed by <color=#ff0000>{1}</color>",

                photonView.Owner.NickName,
                lastShootPlayer.NickName);

                photonView.RPC(nameof(KillMessage), RpcTarget.AllBufferedViaServer, msg);

            }
            StartCoroutine(PlayerDie());
        }
    }

    private IEnumerator PlayerDie()
    {
        cc.enabled = false;
        animator.SetBool(hashRespawn, false);
        animator.SetTrigger(hashDie);

        yield return new WaitForSeconds(3f);

        animator.SetBool(hashRespawn, true);

        SetPlayerVisible(false);

        yield return new WaitForSeconds(1.5f);

        Transform[] points = GameObject.Find("SpawnPointGroup").GetComponentsInChildren<Transform>();
        int idx = Random.Range(0, points.Length);
        transform.position = points[idx].position;

        currHP = 100;
        SetPlayerVisible(true);
        cc.enabled = true;

        void SetPlayerVisible(bool isVisible)
        {
            for (int i = 0; i < renderers.Length; i++)
            {
                renderers[i].enabled = isVisible;
            }
        }
    }

    [PunRPC]
    void KillMessage(string msg)
    {
        // �޽��� ���
        gameManager.msgList.text += msg;
    }
}
