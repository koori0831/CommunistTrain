using System.Collections.Generic;
using UnityEngine;

public class CheckingManager : MonoSingleton<CheckingManager>
{
    [HideInInspector]
    public List<bool> checkPaperData = new List<bool>();

    public void CompliemCheck(bool val)
    {
        print(val);
        checkPaperData.Add(val);
    }

    public void Recepted()
    {
        checkPaperData.Clear();
    }
}
