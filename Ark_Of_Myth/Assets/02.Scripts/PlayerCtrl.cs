using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    // 컴포넌트를 처리할 변수
    private Transform tr;
    // 이동 속력 변수 (public으로 선언되어 인스펙터 뷰에 노출됨)
    public float moveSpeed = 10.0f;

    [SerializeField]
    private GameManager gmr;

    // 초기 생명 값
    private readonly float initHp = 10000.0f;
    // 현재 생명 값
    public float currHp;

    
    void Start()
    {
        gmr = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        // Transform 컴포넌트를 추출해 변수에 대입
        tr = GetComponent<Transform>();

        currHp = initHp;
    }
    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // -1.0f ~ 0.0f ~ +1.0f
        float v = Input.GetAxis("Vertical"); // -1.0f ~ 0.0f ~ +1.0f
        Debug.Log("h=" + h);
        Debug.Log("v=" + v);
        // Transform 컴포넌트의 position 속성값을 변경
        //transform.position += new Vector3(0, 0, 1);
        // 정규화 벡터를 사용한 코드
        //transform.position += Vector3.forward * 1;
        //tr.Translate(Vector3.forward * 10);
        // Translate(이동 방향 * 속력 * Time.deltaTime)
        tr.Translate(Vector3.forward * Time.deltaTime * v * moveSpeed);
        // 전후좌우 이동 방향 벡터 계산
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        // Translate(이동 방향 * 속력 * Time.deltaTime)
        tr.Translate(moveDir * Time.deltaTime * moveSpeed);

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
