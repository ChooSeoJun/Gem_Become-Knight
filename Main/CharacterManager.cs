using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : ScriptableObject
{
    public static CharacterManager instance;

    public int Ch_Hp = 3;
    public int Ch_Power = 2;
    public float Ch_Speed = 5f;
    public int wave = 1;
    public int money = 0;
    public int liveMon = 20;

    public static CharacterManager Get_instance()
    {
        if (instance == null)
        {
            instance = CreateInstance<CharacterManager>();
        }

        return instance;
    }
}
