using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms; //Includes classes related to entity transformations, such as LocalTransform.


//Value types are often preferred in ECS for their performance characteristics. They are typically used for small, immutable data structures that benefit from stack allocation and reduced garbage collection overhead

//Structs: Are often immutable or used for data that doesn't change frequently. They can be more predictable in terms of memory usage and performance.
public partial struct RotatingCubeSystem : ISystem //ISystem interface, which is used for Unity's ECS systems.

{
    public void OnUpdate(ref SystemState state) 
    //the method that is called every frame to update the system
    //ref indicates that state is passed by reference, allowing modifications to the SystemState within the method.
    {
        foreach ((RefRW<LocalTransform> localTransform, RefRO<RotateSpeed> rotateSpeed) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<RotateSpeed>>())
        //SystemAPI.Query<T1, T2>(): This method is used to create a query that retrieves entities that have both the specified components. RefRW and RefRO specify the type of access (read-write or read-only).
        //(RefRW<LocalTransform> localTransform, RefRO<RotateSpeed> rotateSpeed): A tuple that deconstructs the query result into two components:
        //RefRW<LocalTransform>: A reference to a read-write LocalTransform component. This allows you to both read and modify the LocalTransform data.
        //RefRO<RotateSpeed>: A reference to a read-only RotateSpeed component. This allows you to read the RotateSpeed data but not modify it.
        //An entity doesn't have a type, but you can categorize entities by the types of components associated with them. The EntityManager keeps track of the unique combinations of components on existing entities. 
        {
            localTransform.ValueRW = localTransform.ValueRO.RotateZ(rotateSpeed.ValueRO.value * SystemAPI.Time.DeltaTime);
            //Accesses the rotation speed value from the RotateSpeed component.
        }
    }
}
