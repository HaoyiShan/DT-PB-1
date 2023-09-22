using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public TMP_Text ui;
    public TMP_Text winText;
    public TMP_Text health;
    public int Coin = 0;
    public int maxHealth = 100; 
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        health.text = "Health: " + currentHealth + "%";
    }

    // 增加生命值（恢复生命）
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        // 在这里可以添加其他逻辑，比如生命值为0时玩家死亡
        Debug.Log("Player took " + damageAmount + " damage. Current health: " + currentHealth);

        // 检查生命值是否小于等于0
        if (currentHealth <= 0)
        {
            // 生命值小于等于0时，传送玩家回到起点
            Respawn();
        }
    }

    // 传送玩家回到起点
    private void Respawn()
    {
        // 恢复玩家的生命值为最大生命值
        currentHealth = maxHealth;
        // 将玩家位置设置为起点的位置
        Coin--;
        ui.text = "Coin : " + Coin;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("coin"))
        {
            Coin++;
            ui.text = "Coin : " + Coin;
            Destroy(other.gameObject);
        }

        if (other.tag.Equals("destination"))
        {
            winText.text = "Win!";
        }
    }
}
