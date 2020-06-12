using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Characteristics")]
    [SerializeField] float health = 100;
    [SerializeField] int scoreValue = 50;

    [Header("Enemy Shot Parameters")]
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject laserProjectile;
    [SerializeField] float projectileSpeed = 20f;
    [SerializeField] int numberOfProjectiles;

    [Header("Enemy death Animation")]
    [SerializeField] GameObject explosionVFX;
    [SerializeField] float explosionTime = 1f;

    [Header("Audio")]
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip enemyShootSound;
    [SerializeField] [Range(0,1)] float deathSoundVolume = 0.75f;
    [SerializeField] [Range(0,1)] float enemyShootVolume = 0.50f;

    GameSession gameSession;
    private const float radius = 1f;
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }
    
    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if(shotCounter <=0)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        float angleStep = 360f / numberOfProjectiles;
        float angle = 0f;

        for (int i = 0; i <= numberOfProjectiles - 1; i++)
        {
            float projectileDirXPositon = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYPositon = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector3 projectileVector = new Vector3(projectileDirXPositon, projectileDirYPositon, 0);
            Vector3 projectileMoveDirection = (projectileVector - transform.position).normalized * projectileSpeed;

            GameObject enemyLaser = Instantiate(laserProjectile, transform.position, Quaternion.identity) as GameObject;
            enemyLaser.GetComponent<Rigidbody2D>().velocity = new Vector3(projectileMoveDirection.x, -projectileMoveDirection.y, 0);

            angle += angleStep;
        }
        //AudioSource.PlayClipAtPoint(enemyShootSound, Camera.main.transform.position, enemyShootVolume);
    }
    public void OnTriggerEnter2D(Collider2D otherObject)
    {
        DamageDealer damageDealer = otherObject.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health = health - damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        GameObject explodey = Instantiate(explosionVFX, transform.position, Quaternion.identity) as GameObject;
        Destroy(explodey, explosionTime);
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
        gameSession.AddToScore(scoreValue);
    }
}
