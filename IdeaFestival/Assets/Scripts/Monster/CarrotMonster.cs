using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotMonster : Monster
{
    private void Start()
    {
        Init(new Vector2(7, 3), new Vector2(3, 3),100, true, false);
        Think();
    }
}
