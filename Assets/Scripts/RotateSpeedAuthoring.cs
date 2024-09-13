using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;


//This is a MonoBehaviour used in the Unity Editor to author data for entities. It allows you to set values in the Unity Inspector that will be applied to entities in the ECS world.
public class RotateSpeedAuthoring : MonoBehaviour
{
    public float value;

    private class Baker : Baker<RotateSpeedAuthoring>
    {
        public override void Bake(RotateSpeedAuthoring authoring) //The Bake method is called when baking the RotateSpeedAuthoring component into an entity. This method is used to convert the MonoBehaviour data into ECS component data.
        {
            //creates an entity from the RotateSpeedAuthoring MonoBehaviour.
            //The TransformUsageFlags.Dynamic flag indicates that the entity's transform can be dynamically modified.
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);  //get the entity that baker is currently being run on
            AddComponent(entity, new RotateSpeed
            {
                value = authoring.value
            }); //adds the RotateSpeed component to the entity with the value set from the MonoBehaviour.
        }
    }
}


public struct RotateSpeed : IComponentData //means it represents a component that can be attached to entities in ECS.
{
    public float value;
}