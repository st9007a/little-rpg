using System.Collections;
using System.Collections.Generic;

public class EventStore : Dictionary<int, Dictionary<int, List<string>>> {

	private List<int> targetObjIdList = new List<int>();

	public static EventStore getDefault() {
		EventStore es = new EventStore();

		es.targetObjIdList.Add(0);
		es.targetObjIdList.Add(1);
		es.targetObjIdList.Add(2);

		Dictionary<int, List<string>> kv1 = new Dictionary<int, List<string>>();
		kv1.Add(0, new List<string>());
		kv1[0].Add("Um?");
		kv1[0].Add("What's this?");

		kv1.Add(1, new List<string>());
		kv1[1].Add("......");

		kv1.Add(2, new List<string>());
		kv1[2].Add("I can't open it ...");

		es.Add(0, kv1);

		Dictionary<int, List<string>> kv2 = new Dictionary<int, List<string>>();
		kv2.Add(0, new List<string>());
		kv2[0].Add("......");

		kv2.Add(1, new List<string>());
		kv2[1].Add("This is ... ");
		kv2[1].Add("cart ... ??");

		kv2.Add(2, new List<string>());
		kv2[2].Add("I can't open it ...");

		es.Add(1, kv2);
		
		Dictionary<int, List<string>> kv3 = new Dictionary<int, List<string>>();
		kv3.Add(0, new List<string>());
		kv3[0].Add("......");

		kv3.Add(1, new List<string>());
		kv3[1].Add("......");

		kv3.Add(2, new List<string>());
		kv3[2].Add("It is open !!");

		es.Add(2, kv3);

		return es;
	}

	public bool triggerEvent(int eid, int oid){
		if (eid >= targetObjIdList.Count) {
			return false;
		}
		return targetObjIdList[eid] == oid;
	}

	public List<string> getMessage(int eid, int oid) {

		while (!this.ContainsKey(eid) || !this[eid].ContainsKey(oid)) {
			eid--;
		}

		return this[eid][oid];

	}

}
