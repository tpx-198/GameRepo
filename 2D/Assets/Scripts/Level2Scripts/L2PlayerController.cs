using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5f;

    [Header("场景调控")]
    public SceneChanger sceneChanger;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("当前物体未挂载Rigidbody2D组件", this);
        }
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(x * speed, y * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("碰到敌人！");
            sceneChanger.ChangeSceneByName("Level1");
        }
        if (collision.gameObject.CompareTag("Friend"))
        {
            Debug.Log("碰到伙伴！");
        }
    }
}
