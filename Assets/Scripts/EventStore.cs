using System.Collections;
using System.Collections.Generic;

public class EventStore : Dictionary<int, Dictionary<int, string>> {

	private List<int> targetObjIdList = new List<int>();

	public static EventStore getDefault() {
		EventStore es = new EventStore();

		es.targetObjIdList.Add(0);
		es.targetObjIdList.Add(1);
		es.targetObjIdList.Add(2);

		Dictionary<int, string> kv1 = new Dictionary<int, string>();
		kv1.Add(0, "疑?這裡怎麼有個棺材??");
		kv1.Add(1, "......");
		kv1.Add(2, "打不開...");

		es.Add(0, kv1);

		Dictionary<int, string> kv2 = new Dictionary<int, string>();
		kv2.Add(0, "......");
		kv2.Add(1, "這是...馬車??");
		kv2.Add(2, "打不開...");

		es.Add(1, kv2);
		
		Dictionary<int, string> kv3 = new Dictionary<int, string>();
		kv3.Add(0, "......");
		kv3.Add(1, "......");
		kv3.Add(2, "打開了!!");

		es.Add(2, kv3);

		return es;
	}

	public bool triggerEvent(int eid, int oid){
		if (eid >= targetObjIdList.Count) {
			return false;
		}
		return targetObjIdList[eid] == oid;
	}

	public string getMessage(int eid, int oid) {
		string msg;

		while (!this.ContainsKey(eid) || !this[eid].ContainsKey(oid)) {
			eid--;
		}

		msg = this[eid][oid];

		return msg;

	}

}
