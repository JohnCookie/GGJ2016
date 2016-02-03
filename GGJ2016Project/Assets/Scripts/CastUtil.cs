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
		castNameDict.Add("AA", new MagicData(MagicType.Shoot, "Fire Ball", "AA", 25, 1, 5)); //105
		castNameDict.Add("BB", new MagicData(MagicType.Shoot, "Ice Ball", "BB", 25, 2, 5));
		castNameDict.Add("CC",  new MagicData(MagicType.Shoot, "Thunder Ball", "CC", 25, 3, 5));
		castNameDict.Add("ADA",  new MagicData(MagicType.Summon, "Fire Monster", "ADA", 60, 1, 2)); // 200
		castNameDict.Add("BDB",  new MagicData(MagicType.Summon, "Ice Monster", "BDB", 60, 2, 2));
		castNameDict.Add("CDC",  new MagicData(MagicType.Summon, "Thunder Monster", "CDC", 60, 3, 2));
		castNameDict.Add("DA", new MagicData(MagicType.Guard, "Fire Shield", "DA", 10, 1, 0)); // 90
		castNameDict.Add("DB", new MagicData(MagicType.Guard, "Ice Shield", "DB", 10, 2, 0));
		castNameDict.Add("DC", new MagicData(MagicType.Guard, "Thunder Shield", "DC", 10, 3, 0));
		castNameDict.Add ("AADAA", new MagicData (MagicType.Shoot, "Large Fire Ball", "AADAA", 30, 1, 20)); // 280
		castNameDict.Add ("BBDBB", new MagicData (MagicType.Shoot, "Large Ice Ball", "BBDBB", 30, 2, 20));
		castNameDict.Add ("CCDCC", new MagicData (MagicType.Shoot, "Large Thunder Ball", "CCDCC", 30, 3, 20));
		castNameDict.Add("DDD", new MagicData(MagicType.CancelMagic, "Remove Buff!", "DDD", 10, 2, 0)); // 130
		castNameDict.Add("ABCD", new MagicData(MagicType.AntiMagic, "Anti Next Magic", "ABCD", 20, 3, 0)); // 180
	}
}

