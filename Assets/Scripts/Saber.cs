//using EzySlice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Saber : MonoBehaviour
{
    public LayerMask layer;
    private Vector3 previousPos;
    public Transform start;
    public Transform end;
    /*public VelocityEstimator velocityEstimator;
    public LayerMask sliceableLayer;
    public Material material;
    public float force = 10;*/

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Linecast(start.position, end.position, out hit, layer))
        {
            if (Vector3.Angle(transform.position-previousPos,hit.transform.up)>130)
            {
                Destroy(hit.transform.parent.gameObject);
            }
        }
        previousPos = transform.position;

        /*bool hasHit= Physics.Linecast(start.position,end.position,out hit, layer);
        if (hasHit)
        {
            GameObject target = hit.transform.gameObject;
            Slice(target);
        }*/
    }

    /*void Slice(GameObject target)
    {
        Vector3 velocity = velocityEstimator.GetVelocityEstimate();
        Vector3 planeNormal = Vector3.Cross(end.position - start.position, velocity);
        //Vector3 planeNormal = Vector3.Cross(end.position - start.position, transform.position - previousPos);
        planeNormal.Normalize();
        SlicedHull hull = target.Slice(transform.position, planeNormal);
        if (hull != null )
        {
            GameObject upperHull= hull.CreateUpperHull(target,material);
            SetupSliceComponent(upperHull);
            GameObject lowerHull = hull.CreateLowerHull(target, material);
            SetupSliceComponent(lowerHull);
            Destroy(target);
            //Destroy(upperHull, 1);
            //Destroy(lowerHull, 1);
        }
    }

    void SetupSliceComponent(GameObject slicedObject)
    {
        Rigidbody body = slicedObject.AddComponent<Rigidbody>();
        MeshCollider collider = slicedObject.AddComponent<MeshCollider>();
        collider.convex = true;
        body.AddExplosionForce(force, slicedObject.transform.position, 1);
    }*/
}
