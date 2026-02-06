using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5f;
    public float jumpForce = 15f;

    [Header("地面检测设置")]
    public Transform groundCheck;
    public float checkRadius = 0.1f;
    public LayerMask groundLayer;
    private bool isGrounded;

    [Header("血量设置")]
    public float maxHealth = 100f;
    public float currentHealth = 100f;
    public HealthBar healthBar;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // check if null
        if (rb == null)
        {
            Debug.LogError("当前物体未挂载Rigidbody2D组件", this);
        }
    }
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(x * speed, rb.velocity.y);
    }
    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
        }
    }
    void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
