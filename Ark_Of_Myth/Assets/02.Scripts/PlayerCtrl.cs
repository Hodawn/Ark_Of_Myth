using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{

    public enum PLAYERSTATE
    {
        IDLE,
        BATTLE

    }

    // ������Ʈ�� ó���� ����
    public Transform tr;
    // �̵� �ӷ� ���� (public���� ����Ǿ� �ν����� �信 �����)
    public float moveSpeed = 10.0f;

    [SerializeField]
    private GameManager gmr;
    public SpriteRenderer spriteRenderer;

    public Sprite[] playerSprite = new Sprite[2];

    // �ʱ� ���� ��
    private readonly float initHp = 10000.0f;
    // ���� ���� ��
    public float currHp;

    public PLAYERSTATE playerState;

    void Start()
    {
        gmr = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        // Transform ������Ʈ�� ������ ������ ����
        tr = GetComponent<Transform>();

        currHp = initHp;

        playerState = PLAYERSTATE.IDLE;
    }
    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // -1.0f ~ 0.0f ~ +1.0f
        float v = Input.GetAxis("Vertical"); // -1.0f ~ 0.0f ~ +1.0f
      
        // Transform ������Ʈ�� position �Ӽ����� ����
        //transform.position += new Vector3(0, 0, 1);
        // ����ȭ ���͸� ����� �ڵ�
        //transform.position += Vector3.forward * 1;
        //tr.Translate(Vector3.forward * 10);
        // Translate(�̵� ���� * �ӷ� * Time.deltaTime)

        //tr.Translate(Vector3.forward * Time.deltaTime * v * moveSpeed);
        // �����¿� �̵� ���� ���� ���

        Vector3 moveDir = (new Vector3(0.0f, 1.0f, 0.0f) * v) + (new Vector3(1.0f, 0.0f, 0.0f) * h);
        // Translate(�̵� ���� * �ӷ� * Time.deltaTime)
        tr.Translate(moveDir * Time.deltaTime * moveSpeed);

        if(Input.GetKeyDown(KeyCode.E))
        {
            if(playerState == PLAYERSTATE.BATTLE)
            {
                playerState = PLAYERSTATE.IDLE;
            }
            else
            {
                playerState = PLAYERSTATE.BATTLE;
            }

            if (playerState == PLAYERSTATE.IDLE) spriteRenderer.sprite = playerSprite[0];
            if (playerState == PLAYERSTATE.BATTLE) spriteRenderer.sprite = playerSprite[1];


        }



        if (Input.GetKeyDown(KeyCode.F))
        {
            gmr.LoadScene("BossScene");
        }
    }
    void PlayerDie()
    {
        Debug.Log("Player Die !");
    }
   
}
