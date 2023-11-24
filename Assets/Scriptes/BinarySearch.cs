using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinarySearch : MonoBehaviour
{
    [SerializeField] List<int> array;
    [SerializeField] int N;

    private int left;
    private int right;
    private int pivot;

    private void Start()
    {
        Find(array, N);
    }

    void Find(List<int> array, int target)
    {
        array.Sort();

        left = 0;
        right = array.Count - 1;

        while (left <= right)
        {
            pivot = (left + right) / 2;

            if (array[pivot] > target)
            {
                left = pivot + 1;
            }
            else if (array[pivot] < target)
            {
                right = pivot - 1;
            }
            else if (array[pivot] == target)
            {
                Debug.Log($"찾음 pivot = {pivot}");
                return;
            }
        }

        Debug.Log("못찾음");
    }
}
