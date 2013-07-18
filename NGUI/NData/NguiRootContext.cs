using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
[AddComponentMenu("NGUI/NData/Root Context")]
public class NguiRootContext : NguiDataContext
{
	public void SetContext(EZData.Context context)
	{
		_context = context;
	}
}
