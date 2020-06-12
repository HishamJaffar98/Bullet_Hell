using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRotation : MonoBehaviour
{
    Transform playerPosition;
    [SerializeField] Sprite flipSprite;
    [SerializeField] Sprite ogSprite;
    Player myPlayer;
    float minX;
    float maxX;
    float minY;
    float maxY;
    void Start()
    {
        playerPosition = gameObject.transform;
        myPlayer = FindObjectOfType<Player>();
        Camera gameCamera = Camera.main;
        minX = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        maxX = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        minY = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        maxY = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    }

    void Update()
    {
        if (playerPosition.position.x == maxX - myPlayer.spaceCraftAdjustmentX)
        {
            GetComponent<SpriteRenderer>().sprite = flipSprite;
        }
        else if (playerPosition.position.x == minX + myPlayer.spaceCraftAdjustmentX)
        {
            GetComponent<SpriteRenderer>().sprite = ogSprite;
        }
    }
}
