using UnityEngine;

public class FocusOnMenu : MonoBehaviour{
    public Transform target;

    void Update(){
        transform.LookAt(target);
    }
}