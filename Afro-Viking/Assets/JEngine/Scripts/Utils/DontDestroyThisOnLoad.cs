﻿using UnityEngine;
using System.Collections;

public class DontDestroyThisOnLoad : MonoBehaviour
{
	// Use this for initialization
	void Awake () {
        DontDestroyOnLoad(this);
	}
}
