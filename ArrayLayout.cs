using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ArrayLayout {
	[System.Serializable]
	public struct RowData{
		public Transform[] column;
	}

	public RowData[] rows = new RowData[4];
}
