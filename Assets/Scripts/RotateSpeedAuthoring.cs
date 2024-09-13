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



//An entity is similar to an unmanaged lightweight GameObject, which represents specific elements of your program. However, an entity acts as an ID which associates individual unique components together, rather than containing any code or serving as a container for its associated components.
public struct RotateSpeed : IComponentData //means it represents a component that can be attached to entities in ECS.
//Use the IComponentData interface, which has no methods, to mark a struct as a component type. 
//This component type can only contain unmanaged data, and they can contain methods, but it's best practice for them to just be pure data.
{
    public float value;
}


//Authoring Data: This is the data and configurations you set up in the Unity Editor using MonoBehaviours and other components.
//Baker: In ECS, a baker is a class responsible for converting the authoring data into ECS components. The baker class implements the Baker<T> interface where T is the type of authoring script. The baker converts data from the authoring script into the appropriate ECS data format.
//Bake Process: During the baking process, the authoring data is processed and converted into ECS components, which are then added to entities. This is done when the scene is loaded or when the entities are created at runtime. The resulting ECS data is used for processing by systems.