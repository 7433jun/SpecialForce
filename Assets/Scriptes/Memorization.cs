using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memorization : MonoBehaviour
{
    #region ���� ��ȹ��
    // Ư�� ���������� ���� ���ϱ� ���ؼ� �װͰ�
    // �ٸ� ���������� ���� �̿��Ͽ� ȿ�������� ���� 
    // ���ϴ� �˰����Դϴ�.

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

    #region �޸����̼�
    // ���α׷��� ������ ����� �ݺ��ؾ� �� ��, ������
    // ����� ���� �޸𸮿� ���������ν� ������ �����
    // �ݺ� �����ϴ� �۾��� �����Ͽ� ���α׷��� ���� �ӵ��� ����Ű�� ����Դϴ�.
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
