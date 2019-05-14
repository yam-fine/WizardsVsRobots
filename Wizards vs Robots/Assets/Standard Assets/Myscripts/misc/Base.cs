﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Base : Characters
{

    [SerializeField] Stat healthBar;
    [SerializeField] float lerpTime;
    [SerializeField] CanvasGroup cg;
    Fade fade;
    Coroutine routine = null;
    public override bool IsDead => healthBar.CurrentValue <= 0;

    private void Start()
    {
        healthBar.Initialize();

        fade = cg.GetComponent<Fade>();
        cg.alpha = 0;
    }

    IEnumerator hidebarTimer()
    {
        yield return new WaitForSeconds(lerpTime);

        fade.FadeOut(lerpTime);
    }

    public override void TakeDamage(Collider source)
    {
        if (takeDamageSourcesTags.Contains(source.tag))
        {
            healthBar.CurrentValue -= source.GetComponent<SwordCollider>().Damage;

            if (routine != null)
                StopCoroutine(routine);
            cg.alpha = 1;
            routine = StartCoroutine(hidebarTimer());
            Debug.Log("base under fire ");
        }
    }    
}