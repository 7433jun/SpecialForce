using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    private Monster unit;

    [SerializeField] Transform[] spawnPointList;

    public Monster CreateUnit(Monster unitType)
    {
        // ���� ������Ʈ ����
        unit = Instantiate(unitType);

        // ���� ������Ʈ ��ġ ����
        unit.transform.position = spawnPointList[Random.Range(0, spawnPointList.Length)].position;

        // ���� ������Ʈ ��ȯ
        return unit;
    }
}
