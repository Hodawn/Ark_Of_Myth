using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    // ������Ʈ�� ó���� ����
    private Transform tr;
    // �̵� �ӷ� ���� (public���� ����Ǿ� �ν����� �信 �����)
    public float moveSpeed = 10.0f;

    [SerializeField]
    private GameManager gmr;

    // �ʱ� ���� ��
    private readonly float initHp = 10000.0f;
    // ���� ���� ��
    public float currHp;

    
    void Start()
    {
        gmr = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        // Transform ������Ʈ�� ������ ������ ����
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
        // Transform ������Ʈ�� position �Ӽ����� ����
        //transform.position += new Vector3(0, 0, 1);
        // ����ȭ ���͸� ����� �ڵ�
        //transform.position += Vector3.forward * 1;
        //tr.Translate(Vector3.forward * 10);
        // Translate(�̵� ���� * �ӷ� * Time.deltaTime)
        tr.Translate(Vector3.forward * Time.deltaTime * v * moveSpeed);
        // �����¿� �̵� ���� ���� ���
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        // Translate(�̵� ���� * �ӷ� * Time.deltaTime)
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
