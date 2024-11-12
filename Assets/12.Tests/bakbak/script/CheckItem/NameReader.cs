using System.Collections.Generic;
using UnityEngine;

public class NameReader : MonoBehaviour
{
    private List<string> nameList = new List<string>();

    private void Awake()
    {
        LoadNameData();
    }
    private void LoadNameData()
    {
        string[] names = Resources.Load<TextAsset>("Data/Name")?.text.Split("\n");

        for (int i = 1; i < names.Length; i++)
        {
            nameList.Add(names[i]);
        }
    }

    public string GetRandomName()
    {
        int nameIndex = Random.Range(0, nameList.Count);
        return nameList[nameIndex];
    }
}

