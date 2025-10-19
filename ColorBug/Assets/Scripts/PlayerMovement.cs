using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    Animator anim;

    public float playerSpeed = 5f;
    [Range(1, 10)]
    public float jumpSpeed = 5f;

    public bool isGround;//�Ѿ��ڵ�����

    public Transform groundCheck;//����

    public LayerMask ground;//ͼ��

    public int jumpCount = 2;//��Ծ����

    private float moveX;

    private bool moveJump;//��Ծ����

    bool isJump;//�������ã�����Ծ״̬


    void Start()//��ʼʱ����һ��
    {
        rb = GetComponent<Rigidbody2D>();//��ʼ����ȡ���
        anim = GetComponent<Animator>();//��ʼ������
    }

    void Update()//ÿ��Ⱦһ֡�͵���һ��(input�����
    {
        moveX = Input.GetAxisRaw("Horizontal");//��ȡA D -1 1
        moveJump = Input.GetButtonDown("Jump");

        if (moveJump && jumpCount > 0)
        {
            isJump = true;

        }
    }

    private void FixedUpdate()//��������� �̶���ֵ
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.2f, ground);
        Move();
        Jump();
    }
    private void Move()
    {
        anim.SetFloat("speed", Mathf.Abs(moveX));//����ֵ ������ʱxΪ-1Ҳ��Ч

        rb.velocity = new Vector2(moveX * playerSpeed, rb.velocity.y);

        if (moveX != 0)//�ڰ���
        {
            transform.localScale = new Vector3(moveX, 1, 1);
        }
    }

    private void Jump()
    {
        if (isGround)
        {
            jumpCount = 2;
        }

        if (isJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);//��ʩ����Ծ��֮ǰ���Ȱ�Y���ٶ�����,ȷ��ÿ����Ծ�ĸ߶ȶ�һ�¶������������������
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);//����*�ٶ�
            jumpCount--;
            isJump = false;
        }

        //������
        //��Ծ�ָ��Ż����������أ����������ĸ�Զ�ȵȡ���

    }
}

