# ikccd
IK Solver using Cyclic Coordinate Descent made for Unity3D

[Now runs with animations on top as well - use iksolveranim.cs instead of the iksolver.cs script to do this]

# How to run the solver
 - Run the IKSolve scene and move around the Target GameObject.


 - Locate the IKSolver GameObject and add new joints to the IKSolver script as necessary, with Root being the first element and End-joint being the last.


 - The solver also works with 3D now, so don't be afraid (I'm not) to go beyond the safezone that is the xy Plane.

# ToDos
 
 - Adding constraint-handlers
 - ~~Testing with actual rigs and not just simple sphere+cylinder prefabs.~~
    (Works with an actual rig)
 - ~~Testing the usage of multiple IK Solvers in a scene with a fully connected rig.~~
    (Works with multiple solver script instances in the same scene with a fully rigged mesh)
 - Testing the above with Constraints once the constraint-handler is built.
