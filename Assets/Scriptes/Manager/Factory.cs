using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    private Monster unit;

    [SerializeField] Transform[] spawnPointList;

    public Monster CreateUnit(Monster unitType)
    {
        // 게임 오브젝트 생성
        unit = Instantiate(unitType);

        // 게임 오브젝트 위치 설정
        unit.transform.position = spawnPointList[Random.Range(0, spawnPointList.Length)].position;

        // 게임 오브젝트 반환
        return unit;
    }
}
