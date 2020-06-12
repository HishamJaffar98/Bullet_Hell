using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    WaveConfig waveConfig;
    List<Transform> wayPoints;
    int wayPointIndex = 0;

    [Header("Boss Sprites")]
    [SerializeField] Sprite skeletonSprite;
    [SerializeField] Sprite angelOfDeathSprite;

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }
    void Start()
    {
        wayPoints = waveConfig.GetWayPoints();
        if(waveConfig.GetPathReverseState() == true)
        {
            wayPoints.Reverse();
        }
        transform.position = wayPoints[wayPointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(wayPointIndex<=wayPoints.Count - 1)
        {
            var newPosition = wayPoints[wayPointIndex].transform.position;
            var movementSpeed = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, newPosition, movementSpeed);
            if(transform.position == newPosition)
            {
                wayPointIndex++;
            }
        }
        else if(wayPointIndex > wayPoints.Count - 1 && GetComponent<SpriteRenderer>().sprite!=skeletonSprite && GetComponent<SpriteRenderer>().sprite != angelOfDeathSprite)
        {
            Destroy(gameObject);
        }
    }
}
