using UnityEngine;

public class Billboarding : MonoBehaviour
{
    public Transform target;

    private void Start()
    {
        if (target == null)
            target = GameObject.FindWithTag("BillboardingTarget").transform;
        
    }
    void LateUpdate()
    {
        if (target != null)
        {
            transform.LookAt(target.position);
        }
    }
}
