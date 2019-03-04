﻿using System.Collections;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    public int sizeField;

    [SerializeField]
    private GameObject _prefabGarbage = null;

    public GameObject[] InitialGarbage(int sizeField, Transform parent)
    {
        if (_prefabGarbage == null)
        {
            Debug.LogError("Prefab Garbage equals null");
            return new GameObject[0];
        }

        var parentGarbage = new GameObject { name = "Field" };
        var garbage = new GameObject[(sizeField * sizeField) / 4];
        int randomX = 0, randomZ = 0;

        for (int i = 0; i < (sizeField * sizeField) / 4; i++)
        {
            randomX = Random.Range(0, sizeField);
            randomZ = Random.Range(0, sizeField);
            bool isRepeat = false;

            if(i > 0)
            {
                for(int j = 0; j < i; j++)
                {
                    if(randomX == garbage[j].transform.position.x && randomZ == garbage[j].transform.position.z)
                    {
                        i = i - 1;
                        isRepeat = true;
                        break;
                    }
                }
            }
            if (!isRepeat)
            {
                garbage[i] = Instantiate(_prefabGarbage, new Vector3(randomX, _prefabGarbage.transform.position.y + 0.5f, randomZ), Quaternion.identity);
                garbage[i].transform.SetParent(parentGarbage.transform);
            }
        }
        parentGarbage.transform.SetParent(parent);
        return garbage;
    }
}