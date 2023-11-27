using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] int rand;

    [SerializeField] List<Monster> monsterList;

    [SerializeField] Factory factory;

    private readonly WaitForSeconds waitForSeconds = new WaitForSeconds(3f);
    
    void Start()
    {
        monsterList.Capacity = 10;

        StartCoroutine(Spawn());
    }

    public IEnumerator Spawn()
    {
        while (true)
        {
            rand = Random.Range(0, monsterList.Count);

            factory.CreateUnit(monsterList[rand]);

            yield return waitForSeconds;
        }
    }
}
