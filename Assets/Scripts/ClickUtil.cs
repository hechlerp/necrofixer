using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickUtil : MonoBehaviour
{
    Ray ray;
    RaycastHit2D hit;
    float maxRaycastDist;
    CustomerManager cm;
    // Start is called before the first frame update
    void Start()
    {
        cm = GameObject.Find("GlobalScripts").GetComponent<CustomerManager>();
        maxRaycastDist = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0)) {
            Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit;
            int lm = 1 << 8;

            hit = Physics2D.Raycast(point, Vector2.zero, maxRaycastDist, lm);
            if (hit.collider != null && !cm.isPrompting) {
                hit.collider.gameObject.GetComponent<BodyPartController>().onClick();
            }
        }
    }
}
