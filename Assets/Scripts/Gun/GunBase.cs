using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase prefabProjectile;
    public Transform positionToShoot;
    public float timeBetweenShoot = .3f;
    public Transform playerSideReference;

    private float _shootTimer = 0f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.S) && _shootTimer <= 0f)
        {
            Shoot();
            _shootTimer = timeBetweenShoot;
        }

        if (_shootTimer > 0f)
        {
            _shootTimer -= Time.deltaTime;
        }
    }

    public void Shoot()
    {
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        projectile.side = playerSideReference.transform.localScale.x;
    }
}
