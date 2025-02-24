﻿using UnityEngine;

namespace Obi
{
    public class ComputeBoxQuery
    {
        private ComputeShader shader;
        private int kernel;

        public ComputeBoxQuery()
        {
            shader = GameObject.Instantiate(Resources.Load<ComputeShader>("Compute/BoxShapeQuery"));
            kernel = shader.FindKernel("GenerateResults");
        }

        public void GetResults(ComputeSolverImpl solver, SpatialQueries world, GraphicsBuffer transforms, GraphicsBuffer shapes, GraphicsBuffer results)
        {
            shader.SetInt("maxContacts", ComputeColliderWorld.maxContacts);
            shader.SetInt("pointCount", solver.simplexCounts.pointCount);
            shader.SetInt("edgeCount", solver.simplexCounts.edgeCount);
            shader.SetInt("triangleCount", solver.simplexCounts.triangleCount);
            shader.SetInt("surfaceCollisionIterations", solver.abstraction.parameters.surfaceCollisionIterations);
            shader.SetFloat("surfaceCollisionTolerance", solver.abstraction.parameters.surfaceCollisionTolerance);
            shader.SetFloat("collisionMargin", solver.abstraction.parameters.collisionMargin);

            shader.SetBuffer(kernel, "worldToSolver", solver.worldToSolverBuffer);
            shader.SetBuffer(kernel, "simplices", solver.simplices);
            shader.SetBuffer(kernel, "positions", solver.positionsBuffer);
            shader.SetBuffer(kernel, "orientations", solver.orientationsBuffer);
            shader.SetBuffer(kernel, "velocities", solver.velocitiesBuffer);
            shader.SetBuffer(kernel, "principalRadii", solver.principalRadiiBuffer);
            shader.SetBuffer(kernel, "transforms", transforms);
            shader.SetBuffer(kernel, "shapes", shapes);
            shader.SetBuffer(kernel, "contactPairs", world.contactPairs);
            shader.SetBuffer(kernel, "contactOffsetsPerType", world.contactOffsetsPerType);
            shader.SetBuffer(kernel, "results", results);
            shader.SetBuffer(kernel, "dispatchBuffer", world.dispatchBuffer);
            shader.DispatchIndirect(kernel, world.dispatchBuffer, 32 + 16 * (int)QueryShape.QueryType.Box);
        }

    }
}
