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
    private readonly int initHp = 1000;
    // ���� ���� ��
    public float currHp;

    public PLAYERSTATE playerState;

    public bool isAttack;
    public float attackTime;
    public float attackCheckTime;

    public GameObject attackObject;
    public Transform ObjectOffset;

    void Start()
    {
        gmr = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        // Transform ������Ʈ�� ������ ������ ����
        tr = GetComponent<Transform>();

        currHp = initHp;

        playerState = PLAYERSTATE.IDLE;

       
        isAttack = false;
    }
    // Update is called once per frame
    void Update()
    {
       

        attackCheckTime += Time.deltaTime;

        if(isAttack)
        {
            attackTime += Time.deltaTime;

            if(attackTime >= 0.2f)
            {
                isAttack = false;
                attackTime = 0.0f;
              
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if(attackCheckTime >= 0.2f)
            {
                attackCheckTime = 0.0f;
                GameObject temp = Instantiate(attackObject);
                temp.transform.parent = ObjectOffset.transform;
                temp.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                temp.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);
                temp.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                temp.transform.parent = null;

                Destroy(temp, 0.2f);
                isAttack = true;
            }

            //if(playerState == PLAYERSTATE.BATTLE)
            //{
            //    playerState = PLAYERSTATE.IDLE;
            //}
            //else
            //{
            //    playerState = PLAYERSTATE.BATTLE;
            //}

            //if (playerState == PLAYERSTATE.IDLE) spriteRenderer.sprite = playerSprite[0];
            //if (playerState == PLAYERSTATE.BATTLE) spriteRenderer.sprite = playerSprite[1];


        }



        if (Input.GetKeyDown(KeyCode.F))
        {
            gmr.LoadScene("BossScene");
        }
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal"); // -1.0f ~ 0.0f ~ +1.0f
        float v = Input.GetAxis("Vertical"); // -1.0f ~ 0.0f ~ +1.0f



        Vector3 moveDir = (new Vector3(0.0f, 1.0f, 0.0f) * v) + (new Vector3(1.0f, 0.0f, 0.0f) * h);
        // Translate(�̵� ���� * �ӷ� * Time.deltaTime)
        tr.Translate(moveDir * Time.deltaTime * moveSpeed);
    }
    void PlayerDie()
    {
        Debug.Log("Player Die !");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.tag=="Fire")
        {
            Debug.Log("dfsf");
        }
    }

}
