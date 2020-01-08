using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

public class PlayerInputSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        float deltaTime = Time.DeltaTime;

        Entities.ForEach((ref PlayerMovementData moveData, in PlayerInputData data) =>
        {

            //moveData.direction.x = data.move.x;
            //moveData.direction.z = data.move.y;

        }).Run();

        return default;

    }
}