using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleButton : MonoBehaviour
{
    ////public MovingPlatform[] platformsToControl;

    //�Ӿ�����
    public Sprite pressedSprite;
    public Sprite unpressedSprite;
    public SpriteRenderer sr;

    private bool isPressed = false;
    private float pressCooldown = 0.5f;
    private float lastPressTime = -1f;



    void Start()
    {
        sr= GetComponent<SpriteRenderer>();
        if(sr != null&&unpressedSprite!=null )
        {
            sr.sprite = unpressedSprite;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�����ȴʱ��
        if(Time.time<lastPressTime+pressCooldown)
        {
            return;
        }

        //�������Ƿ�����
        bool hit = false;
        if(collision.gameObject.CompareTag("player"))
        {
            
            //foreach(ContactPoint2D contact in collision.contacts)//�������
            //{

            //}
            hit = true;

            if(hit)
            {
                lastPressTime = Time.time;//������ȴ��ʱ
                TogglePlatforms();
            }
        }
    }

    void TogglePlatforms()
    {
        isPressed = !isPressed;//�л�״̬
        
        //�л�sprite
        if(sr!=null&&pressedSprite!=null&&unpressedSprite!=null)
        {
            sr.sprite=isPressed?pressedSprite:unpressedSprite;
        }

        //foreach(MovingPlatform platform in platformsToControl)
        //{
        //    if(platform!=null)
        //    {
        //        platform.ToggleTarget();
        //    }
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
