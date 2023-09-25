using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] HpUI hpUI;
    [SerializeField] ExpUI expUI;
    [SerializeField] DeadCanvasHandle deadCanvasHandle;
    Animator animator;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        animator = GetComponent<Animator>();
        displayHp();
        displayExp();
    }

    public void displayHp()
    {
        hpUI.displayHp(player.GetCurrentHp(), player.GetMaxHp());
    }

    void displayExp()
    {
        expUI.displayExp(player.GetCurrentExp(), player.GetMaxExp(), player.GetLevel());
    }

    public void addExp(float amount)
    {
        player.addExp(amount);
        displayExp();
    }

    public void TakeDamage(float damage)
    {
        player.DecreaseCurrentHp(damage);
        animator.SetTrigger("Hit");
        displayHp();
        if (player.GetCurrentHp() <= 0)
        {
            StartCoroutine("DeadHandler");
        }
    }

    IEnumerator DeadHandler()
    {
        Time.timeScale = 0;
        yield return new WaitForSeconds(1.5f);
        PlayerPrefs.SetInt("save",0);
        deadCanvasHandle.display();
    }
}
