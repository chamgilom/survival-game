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

    private bool isReload = false;

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
        if (playerController.firetrigger == true && currentFireRate <= 0 && !isReload)
        {
            Fire();
        }
    }

    private void Fire()
    {
        if (!isReload)
        {
        if(currentGun.currentBulletCount > 0)
        {
            Shoot();
        }
        else
        {
            StartCoroutine(ReloadCoroutine());
        }
        }


    }

    private void Shoot()
    {
        currentFireRate = currentGun.fireRate;
        currentGun.currentBulletCount--;
        PlaySE(currentGun.fire_Sound);
        currentGun.muzzleFlash.Play();
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

    public IEnumerator ReloadCoroutine()
    {
        if(currentGun.carryBulletCount > 0)
        {
            isReload = true;
            yield return new WaitForSeconds(currentGun.reloadTime);
            currentGun.carryBulletCount += currentGun.currentBulletCount;
            currentGun.currentBulletCount = 0;
            if(currentGun.carryBulletCount >= currentGun.reloadBulletCount)
            {
                currentGun.currentBulletCount = currentGun.reloadBulletCount;
                currentGun.carryBulletCount -= currentGun.reloadBulletCount;
            }
            else
            {
                currentGun.currentBulletCount = currentGun.carryBulletCount;
                currentGun.carryBulletCount = 0;
            }
        }
        isReload = false;
    }
    
    public void TryReload()
    {
        if(!isReload && currentGun.currentBulletCount < currentGun.reloadBulletCount)
        {
            StartCoroutine(ReloadCoroutine());
        }
    }
}
