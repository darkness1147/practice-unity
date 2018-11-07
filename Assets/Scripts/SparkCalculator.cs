using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.Events;

public class SparkCalculator : MonoBehaviour {

	public string InputTextString;

	public int TextValue;

	[ContextMenu("Test 1")]
	public void TestGetValue(){
		bool conversionSucceed;
		conversionSucceed = int.TryParse (InputTextString, out TextValue);

		Debug.Log (conversionSucceed);
	}
	
}
