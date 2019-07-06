using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMScript : MonoBehaviour {
    public static BGMScript bgmInstance;
    public static BGMScript Instance
    {
        get { return bgmInstance; }
    }
	// Use this for initialization

	private void Awake()
	{
        if (bgmInstance != null) {
            Destroy(this.gameObject);
            return;
        } else {
            bgmInstance = this;
        }
        DontDestroyOnLoad(this.gameObject);
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
