using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagManager : SingletonMonoBehaviour<FlagManager>
{
    Dictionary<string, bool> flagDict;
    // Start is called before the first frame update
    void Start()
    {
        flagDict = new Dictionary<string, bool>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
