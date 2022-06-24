using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItemControl : MonoBehaviour
{
    [SerializeField] int Healing = 10;

    public int HealAmount()
    {
        return Healing;
    }
}
