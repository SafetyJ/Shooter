using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

//this controls the players shooting as well as having a short reload
public class Shooting : MonoBehaviour
{
    //firepoint is where the bullet origin
    public Transform firePoint;
    public GameObject bulletPrefab;

    //these are the values for the reload
    public int maxAmmo = 10;
    private int CurrentAmmo = -1;
    public float reloadTime = 2.5f;
    private bool isReloading = false;


    //this controls how "fast" the bullet moves
    public float bulletForce = 20f;


    private void Start()
    {
        if (CurrentAmmo == -1)
            CurrentAmmo = maxAmmo;
    }




    void Update()
    {
        if (isReloading)
            return;


        if (CurrentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    IEnumerator Reload()
    {
        isReloading = true;

        yield return new WaitForSeconds(reloadTime);

        CurrentAmmo = maxAmmo;

        isReloading = false;
    }
    void Shoot()
    {
        CurrentAmmo--;

        //this makes the bullet come out of the fire point at the same rotation with force based on the bulletforce value
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}

