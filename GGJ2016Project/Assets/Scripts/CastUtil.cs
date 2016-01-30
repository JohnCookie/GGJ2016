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

	public MagicData(MagicType mType, string mName, string mMagicStr, int mConsume, int mElement){
		type = mType;
		name = mName;
		magicStr = mMagicStr;
		consume = mConsume;
		element = mElement;
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
		castNameDict.Add("AAD", new MagicData(MagicType.Shoot, "Fire Ball", "AAD", 50, 1));
		castNameDict.Add("BBD", new MagicData(MagicType.Shoot, "Ice Ball", "BBD", 50, 2));
		castNameDict.Add("CCD",  new MagicData(MagicType.Shoot, "Thunder Ball", "CCD", 40, 3));
		castNameDict.Add("ADAA",  new MagicData(MagicType.Summon, "Fire Monster", "ADAA", 150, 1));
		castNameDict.Add("BDBB",  new MagicData(MagicType.Summon, "Ice Monster", "BDBB", 150, 2));
		castNameDict.Add("CDCC",  new MagicData(MagicType.Summon, "Thunder Monster", "CDCC", 150, 3));
		castNameDict.Add("ABCD", new MagicData(MagicType.Guard, "Guard!!!", "ABCD", 90, 1));
		castNameDict.Add("DCBA", new MagicData(MagicType.CancelMagic, "Remove Buff!", "DCBA", 120, 2));
		castNameDict.Add("AABBCC", new MagicData(MagicType.AntiMagic, "Anti Next Magic", "AABBCC", 100, 3));
	}
}

