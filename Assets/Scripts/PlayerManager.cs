using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Animator m_Anim;
    public int maxHealth;
    private int currentHealth;

    ObjectiveToast toast;

    private void Start()
    {
        IceBoulders.OnPlayerHit += OnPlayerHit;
        currentHealth = maxHealth;
        StartCoroutine(FindToast());
    }

    private void OnDestroy()
    {
        IceBoulders.OnPlayerHit -= OnPlayerHit;
    }

    private void OnPlayerHit()
    {
        m_Anim.SetTrigger("Hit");
        currentHealth--;
        string message = currentHealth.ToString() + " / " +  maxHealth.ToString();
        toast.SetHealth(message);
    }

    IEnumerator FindToast()
    {
        yield return new WaitForSeconds(2);
        toast = GameObject.FindObjectOfType<ObjectiveToast>();
        string message = currentHealth.ToString() + " / " + maxHealth.ToString();
        toast.SetHealth(message);
    }
}
