using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript2D : MonoBehaviour {

    public float fireRate = 0;

    public float Damage = 10;

    public LayerMask whatToHit;
    public LayerMask notToHit;
    private float timeToFire = 0f;
    Transform firePoint;
    public GameObject projectileToFire;
    [SerializeField]
    private float projectileSpeed = 30f;

	// Use this for initialization
	void Awake () {
        firePoint = transform.Find("FirePoint");
        if (firePoint == null) {
            Debug.LogError("No Fire Point");
        }
        
	}

    void Update()
    {
        if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
            else
            {
                if (Input.GetButton("Fire1") && Time.time > timeToFire)
                {
                    timeToFire = Time.time + 1 / fireRate;
                    Shoot();
                }
            }
        }
    }
    void Shoot()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        Vector2 aim = firePointPosition + mousePosition;
        
        GameObject bullet = Instantiate(projectileToFire, firePointPosition, Quaternion.identity);
        
    }
}
