using Unity.Entities;
using Unity.Jobs;
using Unity.Collections;
using Unity.Burst;
using Unity.Transforms;

public class WaterJobSystem : JobComponentSystem {

	[BurstCompile]
	private struct WaterJob : IJobForEach<WaterComponent, Translation> {
		[ReadOnly] public ComponentDataFromEntity<Translation> translationArray;
		[ReadOnly] public ComponentDataFromEntity<CanInWaterComponent> canInWaterComponentArray;

		public void Execute([ReadOnly] ref WaterComponent waterComponent, [ReadOnly] ref Translation translation) {

		}
	}

	protected override JobHandle OnUpdate(JobHandle inputDeps) {
		var job = new WaterJob {
			translationArray = GetComponentDataFromEntity<Translation>(true),
			canInWaterComponentArray = GetComponentDataFromEntity<CanInWaterComponent>(true)
		};
		var jobHandle = job.Schedule(this, inputDeps);
		return jobHandle;
	}
}