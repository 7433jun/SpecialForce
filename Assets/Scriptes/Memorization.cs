using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memorization : MonoBehaviour
{
    #region 동적 계획법
    // 특정 범위까지의 값을 구하기 위해서 그것과
    // 다른 범위까지의 값을 이용하여 효율적으로 값을 
    // 구하는 알고리즘입니다.

    public int number;
    int[] numbers;

    public int Fibonacci(int n, int[] array)
    {
        array[0] = 0;
        array[1] = 1;

        for (int i = 2;i <= n; i++)
        {
            array[i] = array[i - 1] + array[i - 2];
        }

        return array[n];
    }

    #endregion

    #region 메모리제이션
    // 프로그램이 동일한 계산을 반복해야 할 때, 이전에
    // 계산한 값을 메모리에 저장함으로써 동일한 계산을
    // 반복 수행하는 작업을 제거하여 프로그램의 실행 속도를 향상시키는 기술입니다.
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        numbers = new int[number + 1];

        Debug.Log(Fibonacci(number, numbers));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
