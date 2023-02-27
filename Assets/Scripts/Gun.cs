using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GunData gunData;

    float timeSinceLastShot;
public object OnGunShoot { get; private set; }

    public void Start()
    {
        PlayerShoot.shootInput += Shoot;
    }

    public void Update()
    {
        timeSinceLastShot += Time.deltaTime;
    }

    private bool CanShoot() => !gunData.reloading && timeSinceLastShot > 1f / (gunData.fireRate / 60f);
    public void Shoot()
    {
        if(gunData.currentAmmo > 0)
        {
            if(CanShoot())
            {
                if(Physics.Raycast(transform.position, gameObject.transform.forward, out RaycastHit hitInfo, gunData.maxDistance))
                {
                    Debug.Log(hitInfo.transform.name);
                }
                gunData.currentAmmo--;
                timeSinceLastShot = 0f;
                OnGunShot();
            }
        }
    }
    private void OnGunShot()
    {

    }
}
