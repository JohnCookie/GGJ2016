using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum MagicType{
	Shoot,
	Summon,
	Guard,
	AntiMagic,
	CancelMagic
}

public class MagicData{
	public MagicType type;
	public string name;
	public string magicStr;
	public int consume;
	public int element;
	public int damage;

	public MagicData(MagicType mType, string mName, string mMagicStr, int mConsume, int mElement, int mDamage){
		type = mType;
		name = mName;
		magicStr = mMagicStr;
		consume = mConsume;
		element = mElement;
		damage = mDamage;
	}
}

public class CastUtil
{
	private static CastUtil _instance;
	private CastUtil(){
		Init();
	}
	public static CastUtil getInstance(){
		if(_instance==null){
			_instance = new CastUtil();
		}
		return _instance;
	}
	public Dictionary<string, MagicData> castNameDict = new Dictionary<string, MagicData>();

	public void Init(){
		castNameDict.Clear();
		castNameDict.Add("AA", new MagicData(MagicType.Shoot, "Fire Ball", "AA", 10, 1, 5));
		castNameDict.Add("BB", new MagicData(MagicType.Shoot, "Ice Ball", "BB", 10, 2, 5));
		castNameDict.Add("CC",  new MagicData(MagicType.Shoot, "Thunder Ball", "CC", 10, 3, 5));
		castNameDict.Add("ADA",  new MagicData(MagicType.Summon, "Fire Monster", "ADA", 75, 1, 2));
		castNameDict.Add("BDB",  new MagicData(MagicType.Summon, "Ice Monster", "BDB", 75, 2, 2));
		castNameDict.Add("CDC",  new MagicData(MagicType.Summon, "Thunder Monster", "CDC", 75, 3, 2));
		castNameDict.Add("DDA", new MagicData(MagicType.Guard, "Fire Shield", "DDA", 50, 1, 0));
		castNameDict.Add("DDB", new MagicData(MagicType.Guard, "Ice Shield", "DDB", 50, 2, 0));
		castNameDict.Add("DDC", new MagicData(MagicType.Guard, "Thunder Shield", "DDC", 50, 3, 0));
		castNameDict.Add ("AABCA", new MagicData (MagicType.Shoot, "Large Fire Ball", "AABCA", 50, 1, 25));
		castNameDict.Add ("BBCAB", new MagicData (MagicType.Shoot, "Large Ice Ball", "BBCAB", 50, 2, 25));
		castNameDict.Add ("CCABC", new MagicData (MagicType.Shoot, "Large Thunder Ball", "CCABC", 50, 3, 25));
		castNameDict.Add("DCBA", new MagicData(MagicType.CancelMagic, "Remove Buff!", "DCBA", 120, 2, 0));
		castNameDict.Add("BDACD", new MagicData(MagicType.AntiMagic, "Anti Next Magic", "BDACD", 100, 3, 0));
	}
}

