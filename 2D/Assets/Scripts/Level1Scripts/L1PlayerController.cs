using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1PlayerController : MonoBehaviour
{
    [Header("血量设置")]
    public float maxHealth = 100f;
    public float currentHealth = 100f;
    public HealthBar healthBar;

    [Header("对话相关")]
    public DialogueManager dialogueManager;

    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(10f);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            dialogueManager.StartDialogue("骷髅", new string[] { 
                "这是一只骷髅小怪，平平无奇，", "你可以尝试击败它，",
                "当然你也可以选择逃跑。"
            });
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            dialogueManager.DisplayNextSentence();
        }
    }
    void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
