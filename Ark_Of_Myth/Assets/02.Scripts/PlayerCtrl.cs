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

    // 컴포넌트를 처리할 변수
    public Transform tr;
    // 이동 속력 변수 (public으로 선언되어 인스펙터 뷰에 노출됨)
    public float moveSpeed = 10.0f;

    [SerializeField]
    private GameManager gmr;
    public SpriteRenderer spriteRenderer;

    public Sprite[] playerSprite = new Sprite[2];

    // 초기 생명 값
    private readonly float initHp = 10000.0f;
    // 현재 생명 값
    public float currHp;

    public PLAYERSTATE playerState;

    void Start()
    {
        gmr = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        // Transform 컴포넌트를 추출해 변수에 대입
        tr = GetComponent<Transform>();

        currHp = initHp;

        playerState = PLAYERSTATE.IDLE;
    }
    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // -1.0f ~ 0.0f ~ +1.0f
        float v = Input.GetAxis("Vertical"); // -1.0f ~ 0.0f ~ +1.0f
      
        // Transform 컴포넌트의 position 속성값을 변경
        //transform.position += new Vector3(0, 0, 1);
        // 정규화 벡터를 사용한 코드
        //transform.position += Vector3.forward * 1;
        //tr.Translate(Vector3.forward * 10);
        // Translate(이동 방향 * 속력 * Time.deltaTime)

        //tr.Translate(Vector3.forward * Time.deltaTime * v * moveSpeed);
        // 전후좌우 이동 방향 벡터 계산

        Vector3 moveDir = (new Vector3(0.0f, 1.0f, 0.0f) * v) + (new Vector3(1.0f, 0.0f, 0.0f) * h);
        // Translate(이동 방향 * 속력 * Time.deltaTime)
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
