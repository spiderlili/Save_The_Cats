using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playedOrNot : MonoBehaviour {
    public bool played;
    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }
}
