﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PandaScript : MonoBehaviour {

    public float speed;
    public float health;

    private Animator animator;
    private int AnimDieTriggerHash = Animator.StringToHash("DieTrigger");
    private int AnimHitTriggerHash = Animator.StringToHash("HitTrigger");
    private int AnimEatTriggerHash = Animator.StringToHash("EatTrigger");

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void MoveTowards(Vector3 destination)
    {
        // step 을 만든다음, 판단를 그 만큼 목표 지점으로 이동 시킨다.
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, destination, step);
    }
    private void Hit(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            animator.SetTrigger(AnimDieTriggerHash);

        }
        else
        {
            animator.SetTrigger(AnimHitTriggerHash);
        }
    }
    private void Eat()
    {
        animator.SetTrigger(AnimEatTriggerHash);
    }
}