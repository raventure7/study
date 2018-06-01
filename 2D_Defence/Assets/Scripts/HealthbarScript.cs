using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarScript : MonoBehaviour
{

    public int maxHealth;
    private Image fillingImage;
    private int health;
    private float percentage;
    // Use this for initialization
    void Start()
    {
        fillingImage = GetComponentInChildren<Image>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void updateHealthBar()
    {
        // 헬스량을 퍼센트지 계산
        percentage = health * 1f / maxHealth;
        fillingImage.fillAmount = percentage;
    }
    public bool ApplyDamage(int value)
    {
        // 데미지 피해
        health -= value;
        // 플레이어 체력이 0 이상이면 헬스바를 업데이트
        if(health > 0)
        {
            updateHealthBar();
            return false;
        }
        health = 0;
        updateHealthBar();
        return true;
    }
}
