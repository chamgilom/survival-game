using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunController : MonoBehaviour
{
    [SerializeField] private Gun currentGun;

    private float currentFireRate;
    private PlayerController playerController;
    private AudioSource audioSource;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        GunFireRateCalc();
        TryFire();
    }


    public void TryFire()
    {
        if (playerController.firetrigger == true && currentFireRate <= 0)
        {
            Fire();
        }
    }

    private void Fire()
    {
        currentFireRate = currentGun.fireRate;
        Shoot();
    }

    private void Shoot()
    {
        PlaySE(currentGun.fire_Sound);
        currentGun.muzzleFlash.Play();
        Debug.Log("น฿ป็");
    }

    private void GunFireRateCalc()
    {
        if (currentFireRate > 0)
        {
            currentFireRate -= Time.deltaTime;
        }
    }

    private void PlaySE(AudioClip _clip)
    {
        audioSource.clip = _clip;
        audioSource.Play();
    }
}
