using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Action Data", menuName = "Scriptable Object/Action Data", order = int.MaxValue)]
public class ActionSO : ScriptableObject
{
    public ActionType action;
    public int damage;
    public int energy;
    public Vector3[] attackPoint;
    public Vector3 moveDir;
}
