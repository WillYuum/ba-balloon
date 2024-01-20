using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PrefabManagerTool;

public class InterestArea : MonoBehaviour
{
    private GameObject _spawnedButterflies;
    private List<GameObject> _allSpawnedWind;
    private float interestRadius = 15f;


    public void StartInterestArea(Vector2 spawnPosition)
    {
        _allSpawnedWind = new List<GameObject>();

        transform.position = spawnPosition;

        Vector2 butterflyPos = (Vector2)transform.position;
        _spawnedButterflies = PrefabManager.instance.ButterfliesPrefab.CreateGameObject(butterflyPos, Quaternion.identity);

        _spawnedButterflies.transform.parent = transform;


        float repeatTime = 4.45f;
        float startDelay = 1.35f;
        InvokeRepeating(nameof(SpawnWind), startDelay, repeatTime);
    }

    private void SpawnWind()
    {
        Vector2 windPos = Random.Range(0f, interestRadius) * Random.insideUnitCircle + (Vector2)transform.position;
        Vector2 windDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;

        GameObject spawnedWind = PrefabManager.instance.WindPrefab.CreateGameObject(windPos, Quaternion.identity);

        spawnedWind.GetComponent<WindVisuals>().SetWindDirection(windDirection);

        _allSpawnedWind.Add(spawnedWind);
    }


    public void EndInterestArea()
    {

        CancelInvoke(nameof(SpawnWind));

        if (_allSpawnedWind != null && _allSpawnedWind.Count > 0)
        {
            foreach (var wind in _allSpawnedWind)
            {
                if (wind != null)
                {
                    Destroy(wind);
                }
            }
        }


        if (_spawnedButterflies != null)
        {
            Destroy(_spawnedButterflies);
        }
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, interestRadius);

        Gizmos.DrawIcon(transform.position, gameObject.name, true);
    }
}
