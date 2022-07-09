using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private float randomRangeYMinimum = 0.3f;
    [SerializeField] private float randomRangeYMaximum = 3;
    private Vector3 platformPosition;
    private void Start()
    {
        platformPosition = transform.position;
        for (int i = 0; i < 20; i++)
            Spawn();
    }

    private void Spawn()
    {
        GameObject platform = Instantiate(platformPrefab);
        platform.transform.position = SetPLatfromPosition(platform);
        platform.transform.SetParent(transform);

    }
    
    public void MovePlatform(Transform platform)
    {
        platform.position = SetPLatfromPosition(platform.gameObject);
    }

    private Vector3 SetPLatfromPosition(GameObject platform)
    {
        if (platform.TryGetComponent<PlatformMove>(out PlatformMove platformMove))
        {
            if (platformMove.isUpDown == false)
            {
                float newWayPoint = Random.Range(1.8f, 3.4f);
                platformMove.wayPointDestiantion = newWayPoint;
                platformPosition.x = Random.Range((transform.position.x - 2) + newWayPoint, transform.position.x + 2);
                platformPosition.y += Random.Range(randomRangeYMinimum, randomRangeYMaximum);
            }
            else
            {
                platformPosition.x = Random.Range(transform.position.x - 2, transform.position.x + 2);
                platformPosition.y += Random.Range(randomRangeYMinimum, randomRangeYMaximum);
            }
        }
        else
        {
            platformPosition.x = Random.Range(transform.position.x - 2, transform.position.x + 2);
            platformPosition.y += Random.Range(randomRangeYMinimum, randomRangeYMaximum);
        }
        
        return platformPosition;
    }
}
