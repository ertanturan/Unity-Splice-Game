﻿using SliceFramework;
using UnityEngine;

public class SliceManager : SceneSingleton<SliceManager>
{

    public bool Slice(GameObject objectToSlice, Material material, Transform slicePoint)
    {
        //Transform slicePoint = ((MeshSliceShowcase)target).transform;
        SlicedHull hull = objectToSlice.Slice(slicePoint.position, slicePoint.forward, material);
        if (hull != null)
        {

            objectToSlice.SetActive(false);

            GameObject lower = hull.CreateLowerHull(objectToSlice, material);
            lower.AddComponent<MeshCollider>().convex = true;
            lower.AddComponent<Rigidbody>();

            GameObject upper = hull.CreateUpperHull(objectToSlice, material);
            upper.AddComponent<MeshCollider>().convex = true;
            upper.AddComponent<Rigidbody>();

            AudioManager.Instance.PlaySlice();
            return true;

        }

        return false;
    }

}
