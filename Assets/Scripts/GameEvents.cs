using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IntEvent : UnityEvent<int> {}
public class FloatEvent : UnityEvent<float> {}
public class StringEvent : UnityEvent<string>{}

public class GameEvents
{
    static public UnityEvent<int> OnLevelUp = new UnityEvent<int>();
    static public UnityEvent<float> OnTakeDamage = new UnityEvent<float>();
    static public UnityEvent<int> UpdateGold = new UnityEvent<int>();
    static public UnityEvent<int> UpdateXp = new UnityEvent<int>();
    static public UnityEvent<float> UpdateStamina = new UnityEvent<float>();
}
