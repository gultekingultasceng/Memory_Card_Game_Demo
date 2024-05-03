using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFactory : Factory<CardScript,GameObject,Transform>
{
    public override CardScript Create(GameObject param1, Transform param2)
    {
        return Instantiate(param1,param2).GetComponent<CardScript>();
    }
}
