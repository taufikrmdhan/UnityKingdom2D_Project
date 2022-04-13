﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Origin_DamagedCreep => Resources.Load<GameObject>("Prefabs/Enemies/damagedCreep");
    public GameObject Origin_NativeCreep => Resources.Load<GameObject>("Prefabs/Enemies/nativeCreep");
    public GameObject Origin_WarriorCreep => Resources.Load<GameObject>("Prefabs/Enemies/wariorCreep");
    public GameObject Origin_WitchCreep => Resources.Load<GameObject>("Prefabs/Enemies/witchCreep");
    public GameObject Origin_SkeltCreep => Resources.Load<GameObject>("Prefabs/Enemies/skeltCreep");
    public GameObject Origin_CastLight => Resources.Load<GameObject>("Prefabs/Stuffs/CastLight");
    public GameObject Origin_Fire1 => Resources.Load<GameObject>("Prefabs/Stuffs/Fire_Style1");
    public GameObject Origin_Fire2 => Resources.Load<GameObject>("Prefabs/Stuffs/Fire_Style2");
    public GameObject Origin_Shell => Resources.Load<GameObject>("Prefabs/Stuffs/ShellEffect");
    public GameObject Origin_Damage => Resources.Load<GameObject>("Prefabs/Stuffs/DamagePop");

    public int GamePoint;
    public int KillPoint;
    public static GameManager Instance { get; private set; }
    private void Start()
    {
        Instance = this;
    }
}

public enum UnitState
{
    Idle, Move, Attack, Cast, Dead,
}

public enum DamageState
{
    Default,
    PlayerPhs, PlayerMag,
    EnemyPhs, AllyHeal,
}
public enum EnemySet
{
    Default, Damaged, Native, Warrior, Witch, Skeleton,
}

public enum SkillSet
{
    Default, SplashSwing, DemonShell,
}


