using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour {
    public static MainMenuManager _MainMenuManager;
	// Use this for initialization
	private void Awake()
	{
        if(_MainMenuManager==null){
            _MainMenuManager = this;
        }
        Time.timeScale = 1;
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
