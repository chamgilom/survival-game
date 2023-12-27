using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public interface IDamagable
{
    void TakePhysicalDamage(int damageAmount);
}

[System.Serializable]
public class Condition
{
    [HideInInspector]
    public float curValue;
    public float maxValue;
    public float startValue;
    public float regenRate;
    public Image uiBar;

    public void Add(float amount)
    {
        curValue = Mathf.Min(curValue + amount, maxValue);
    }

    public void Subtract(float amount)
    {
        curValue = Mathf.Max(curValue - amount, 0.0f);
    }

    public float GetPercentage()
    {
        return curValue / maxValue;
    }

}


public class PlayerConditions : MonoBehaviour, IDamagable
{
    public Condition health;




    public UnityEvent onTakeDamage;

    void Start()
    {
        health.curValue = health.startValue;

    }

    // Update is called once per frame
    void Update()
    {


        if (health.curValue == 0.0f)
            Die();

        health.uiBar.fillAmount = health.GetPercentage();

    }

    public void Heal(float amount)
    {
        health.Add(amount);
    }





    public void Die()
    {
        

        SceneManager.LoadScene("YouloseScene");
    }

    public void TakePhysicalDamage(int damageAmount)
    {
        health.Subtract(damageAmount);
        onTakeDamage?.Invoke();
    }
}