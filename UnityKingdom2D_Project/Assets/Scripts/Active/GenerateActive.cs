using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GenerateActive : MonoBehaviour
{
    public GameObject[] Creeps;
    public float DelayTime;
    
    public Action<string> GenerateAction { get; set; }

    public bool IsReadySpawn
    {
        set
        {
            if (value)
            {
                if (spawntime > 0)
                {
                    spawntime -= Time.deltaTime;
                }
                if (spawntime < 0)
                {
                    spawntime = 1f;
                    GenerateAction?.Invoke(transform.tag);
                }
            }
        }
    }

    public int Stock
    {
        get
        {
            return stock;
        }
        set
        {
            stock = value;
            Creeps = new GameObject[stock];
        }
    }

    private int stock;
    private float castime;
    private float spawntime;

    private void GenerateTier_1(string tag)
    {
        for (int i = 0; i < Creeps.Length; i++)
        {
            if (Creeps[i] == null)
            {
                var gm = GameManager.Instance;
                GameObject creep = null;
                if (tag == "Nest")
                {
                     creep = gm.Origin_NativeCreep;
                }
                else if (tag == "Hole")
                {
                     creep = gm.Origin_DamagedCreep;
                }
                creep.GetComponent<EnemyActive>().Spawner = gameObject;
                creep.GetComponent<EnemyActive>().SlotNum = i;
                var generator = GetComponent<GenerateActive>();
                generator.Creeps[i] = Instantiate(gm.Origin_DamagedCreep, transform.position, Quaternion.identity, transform);
                break;
            }
        }
    }

    private void GenerateTier_2(string tag)
    {
        for (int i = 0; i < Creeps.Length; i++)
        {
            if (Creeps[i] == null)
            {
                var gm = GameManager.Instance;
                GameObject creep = null;
                if (tag == "Nest")
                {
                    creep = (i < 4) ? gm.Origin_NativeCreep : gm.Origin_WarriorCreep;
                }
                else if (tag == "Hole")
                {
                    creep = (i < 3) ? gm.Origin_DamagedCreep : gm.Origin_WitchCreep;
                }
                creep.GetComponent<EnemyActive>().Spawner = gameObject;
                creep.GetComponent<EnemyActive>().SlotNum = i;
                var generator = GetComponent<GenerateActive>();
                generator.Creeps[i] = Instantiate(gm.Origin_DamagedCreep, transform.position, Quaternion.identity, transform);
                break;
            }
        }
    }

    private void GenerateTier_3(string tag)
    {
        for (int i = 0; i < Creeps.Length; i++)
        {
            if (Creeps[i] == null)
            {
                var gm = GameManager.Instance;
                GameObject creep = null;
                if (tag == "Nest")
                {
                    creep = (i < 5) ? gm.Origin_NativeCreep : gm.Origin_WarriorCreep;
                }
                else if (tag == "Hole")
                {
                    creep = (i < 3) ? gm.Origin_NativeCreep : gm.Origin_WitchCreep;
                }
                creep.GetComponent<EnemyActive>().Spawner = gameObject;
                creep.GetComponent<EnemyActive>().SlotNum = i;
                var generator = GetComponent<GenerateActive>();
                generator.Creeps[i] = Instantiate(gm.Origin_DamagedCreep, transform.position, Quaternion.identity, transform);
                break;
            }
        }
    }

    public void Start()
    {
        castime = DelayTime;
        Stock = 5;
        GenerateAction = GenerateTier_2;
    }
    private void Update()
    {
        if (castime > 0)
        {
            castime -= Time.deltaTime;
        }
        if (castime < 0)
        {
            castime = 0;
            spawntime = 1f;
        }
        IsReadySpawn = transform.childCount < Stock;
    }
}
