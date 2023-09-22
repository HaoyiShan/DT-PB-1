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

    // ��������ֵ���ָ�������
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        // �����������������߼�����������ֵΪ0ʱ�������
        Debug.Log("Player took " + damageAmount + " damage. Current health: " + currentHealth);

        // �������ֵ�Ƿ�С�ڵ���0
        if (currentHealth <= 0)
        {
            // ����ֵС�ڵ���0ʱ��������һص����
            Respawn();
        }
    }

    // ������һص����
    private void Respawn()
    {
        // �ָ���ҵ�����ֵΪ�������ֵ
        currentHealth = maxHealth;
        // �����λ������Ϊ����λ��
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
