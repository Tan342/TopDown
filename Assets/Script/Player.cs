using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] UpgradeManager upgradeManager;
    [SerializeField] ParticleSystem levelupEffect;
    float currentHp = 10;
    float maxHp = 10;
    float atk = 1;
    float speed = 5;
    int level = 1;
    float currentExp = 0;
    float maxExp = 10;

    PlayerSound playerSound;
    PlayerHealth playerHealth;

    private void Start()
    {
        playerSound = GetComponent<PlayerSound>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    void ResetPlayer()
    {
        currentHp = 10;
        maxHp = 10;
        atk = 1;
        speed = 5;
        level = 1;
        currentExp = 0;
        maxExp = 10;
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("currentHp", currentHp);
        PlayerPrefs.SetFloat("maxHp", maxHp);
        PlayerPrefs.SetFloat("atk", atk);
        PlayerPrefs.SetFloat("speed", speed);
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetFloat("currentExp", currentExp);
        PlayerPrefs.SetFloat("maxExp", maxExp);
    }

    public void Load()
    {
        currentHp = PlayerPrefs.GetFloat("currentHp");
        maxHp = PlayerPrefs.GetFloat("maxHp");
        atk = PlayerPrefs.GetFloat("atk");
        speed = PlayerPrefs.GetFloat("speed");
        level = PlayerPrefs.GetInt("level");
        currentExp = PlayerPrefs.GetFloat("currentExp");
        maxExp = PlayerPrefs.GetFloat("maxExp");
    }

    public float GetCurrentHp()
    {
        return currentHp;
    }

    public void DecreaseCurrentHp(float amount)
    {
        currentHp -= amount;
    }

    public float GetMaxHp()
    {
        return maxHp;
    }

    public void SetMaxHp(float amount)
    {
        maxHp = amount;
        playerHealth.displayHp();
    }

    public float GetAtk()
    {
        return atk;
    }

    public void SetAtk(float amount)
    {
        atk = amount;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void SetSpeed(float amount)
    {
        speed = amount;
    }

    public float GetCurrentExp()
    {
        return currentExp;
    }

    public float GetMaxExp()
    {
        return maxExp;
    }

    public int GetLevel()
    {
        return level;
    }

    public void addExp(float amout)
    {
        Debug.Log(amout);
        currentExp += amout;
        if (currentExp >= maxExp)
        {
            StartCoroutine("Levelup");
        }
    }

    IEnumerator Levelup()
    {
        currentExp = maxExp - currentExp;
        maxExp = maxExp * 1.5f;
        level += 1;
        currentHp += 2;
        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }
        playerHealth.displayHp();
        levelupEffect.Play();
        playerSound.PlayLevelupSound();
        yield return new WaitForSeconds(2f);
        upgradeManager.DisplayUpgrade();
    }
}
