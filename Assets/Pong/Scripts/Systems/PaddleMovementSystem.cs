﻿using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;


public class PaddleMovementSystem : JobComponentSystem
{

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        float deltaTime = Time.DeltaTime;
        float yBound = PongManager.main.yBound;

        Entities.ForEach((ref Translation trans, in PaddleMovementData data) =>
        {

            trans.Value.y = math.clamp(trans.Value.y + (data.speed * data.direction * deltaTime), -yBound, yBound);

        }).Run();

        return default;

    }

}