using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : MonoBehaviour 
{
	//base stats
	[SerializeField]
	private float maxHP;
	[SerializeField]
	private float maxSP;
	[SerializeField]
	private float curHP;
	[SerializeField]
	private float curSP;

	public List<BuffData> AppliedBuffs;
	public List<BuffData> AppliedDebuffs;

	// Use this for initialization
	void Start () {
		
	}
	
	public void ChangeHP(float value)
	{
		curHP = curHP + value;
		if (curHP < 0) 
		{
			curHP = 0;
			//trigger 0 hp methods
		}
		if (curHP > maxHP) 
		{
			curHP = maxHP;
		}
	}

	public void ChangeSP(float value)
	{
		curSP = curSP + value;
		if (curSP < 0) 
		{
			curSP = 0;
		}
		if (curSP > maxSP) 
		{
			curSP = maxSP;
		}
	}

	public void ApplyBuff(BuffData buff){
		
	}
}

[System.Serializable]
public class BaseStats
{
	public int STR;
	public int AGI;
	public int CON;
	public int INT;
	public int DEX;
	public int LUK;
	[Space(10)]
	//counted by above stats, excluding buffs and equip effects
	public int HP;
	public int SP;
	public int ATK;
	public int DEF;
//	public float ACC;
	public float SPD;
	public float CRI;
	public float MOV;

	public void UpdateBaseStats()
	{
		
	}
}
