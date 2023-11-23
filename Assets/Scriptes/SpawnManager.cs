using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform[] spawnPointList;
    [SerializeField] Monster monsterPrefab;

    private readonly WaitForSeconds waitForSeconds = new WaitForSeconds(3f);
    
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Spawn()
    {
        while (true)
        {
            Instantiate(monsterPrefab, spawnPointList[Random.Range(0, spawnPointList.Length)].position, Quaternion.identity);

            yield return waitForSeconds;
        }
    }
}
