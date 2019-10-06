using Unity.Entities;
using UnityEngine;

public struct WaterComponent : IComponentData {
	public float radius;
}

[DisallowMultipleComponent]
[RequiresEntityConversion]
public class HairAuthoring : MonoBehaviour, IConvertGameObjectToEntity {
	public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem) {
		dstManager.AddComponentData(entity, new WaterComponent()
		{
			radius = transform.localScale.x
		});
	}
}
