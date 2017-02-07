# ikccd
IK Solver using Cyclic Coordinate Descent on Unity

Currently works perfectly on the X-Y plane. 

Run the IKSolve scene and move around the Target GameObject.


Locate the IKSolver GameObject and add new joints to the IKSolver script as necessary, with Root being the first element and End-joint being the last.


3D still needs to be fixed (some logic error where the joint angles get messed up beyond a particular range of XYZ values (I haven't narrowed down this range yet) and then they stay that way).
