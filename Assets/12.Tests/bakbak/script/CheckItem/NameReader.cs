using System.Collections.Generic;
using UnityEngine;

public class NameReader : MonoBehaviour
{
    private List<string> nameList = new List<string>();
    private List<string> lastNameList = new List<string>();

    private void Awake()
    {
        LoadNameData();
    }
    private void LoadNameData()
    {
        string[] names = Resources.Load<TextAsset>("Data/Names").text.Split("\r\n");

        for (int i = 1; i < names.Length; i++)
        {
            string[] name = names[i].Split(',');
            nameList.Add(name[0]);
            lastNameList.Add(name[1]);
        }
    }

    public string GetRandomName()
    {
        int nameIndex = Random.Range(0, nameList.Count);
        int lastNameIndex = Random.Range(0, lastNameList.Count);

        string name = nameList[nameIndex];
        string lastName = lastNameList[lastNameIndex];
        string returnName = null;
        returnName = lastName + " " + name;
        return returnName;

    }
}

