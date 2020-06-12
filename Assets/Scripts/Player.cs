using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] public float health = 1000f;

    [Header("Explosion")]
    [SerializeField] GameObject explosionVFX;
    [SerializeField] float explosionTime = 1f;

    [Header("Death_Audio")]
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.75f;

    [Header("Shooting_Audio")]
    [SerializeField] AudioClip playerShootSound;
    [SerializeField] [Range(0, 1)] float playerShootVolume = 0.05f;
 
    [Header("Projectile")]
    [SerializeField] GameObject myLaser;
    [SerializeField] float projectileSpeed = 20f;
    [SerializeField] float projectileFiringPeriod = 0.1f;

    float minX;
    float maxX;
    float minY;
    float maxY;
    [Header("Movement Restrictions")]
    [SerializeField] public float spaceCraftAdjustmentY = 0.74f;
    [SerializeField] public float spaceCraftAdjustmentX = 0.86f;
    Coroutine firingCoroutine;
    LevelController level;

    void Start()
    {
        SetUpWorldBoundaries();
        level = FindObjectOfType<LevelController>();
    }

    void Update()
    {
        Move();
        Fire();
    }

    private void SetUpWorldBoundaries()
    {
        Camera gameCamera = Camera.main;
        minX = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        maxX = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        minY = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        maxY = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newPosX = Mathf.Clamp(transform.position.x + deltaX,minX + spaceCraftAdjustmentX, maxX - spaceCraftAdjustmentX);
        var newPosY = Mathf.Clamp(transform.position.y + deltaY,minY + spaceCraftAdjustmentY, maxY - spaceCraftAdjustmentY);
        transform.position = new Vector2(newPosX, newPosY);
    }

    private void Fire()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireContinously());
        }
        if(Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }

    IEnumerator FireContinously()
    {
        while (true)
        {
            GameObject Laser = Instantiate(myLaser, transform.position, Quaternion.identity) as GameObject;
            Laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            AudioSource.PlayClipAtPoint(playerShootSound, Camera.main.transform.position, playerShootVolume);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        DamageDealer damageDealer = otherObject.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessPlayerHit(damageDealer);
    }

    private void ProcessPlayerHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            health = 0;
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        GameObject explodey = Instantiate(explosionVFX, transform.position, Quaternion.identity) as GameObject;
        Destroy(explodey, explosionTime);
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
        FindObjectOfType<LevelController>().LoadGameOverScene();
    }
}
