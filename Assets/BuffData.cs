using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuffData", menuName = "Practice/Standalone Data/Buff Data",order = 1)]
public class BuffData : ScriptableObject {

	public enum BuffType
	{
		BUFF_POSITIVE,
		BUFF_NEGATIVE
	}

	public Sprite Icon;
	public BuffType Type;
	public bool Stackable;
	public float Duration;
	[Header("Direct Stat Modifier")]
	public BaseStats StatEffect;

	[Header("Heal/Damage HP or SP")]
	public int HPHeal;
	public float HPHealPercent;
	public int SPHeal;
	public float SPHealPercent;


}
