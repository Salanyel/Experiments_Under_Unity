# Experiments_Under_Unity
This repository contains a lot of scene based on different experiments under Unity. 3D, logic, algorithmic, etc.

Current scene and content:
01_Clock ==> Contains a clock (with hands) that can be analog
02_ConstructingFractal ==> Create a rotating fractal
03_FramesPerSecond ==> Create a FPS counter by launching spheres against themselves
04_ObjectsPool ==> Create a fountain of stuff. Each stuff are stored in a pool when no more needed. Instead of instantiate new gameobjects, the object from the pool are used again.
05_CurvesAndSplines ==> Create a tool inside the editor to manipulate Bezier Splines
06_ProceduralGrid ==> Create a simple mesh by first creating its vertices, then the trianges, then its uv
07_RoundedCube ==> Create rounded cube by creating and manipulating vertices
08 CubeSphere ==> Generate a sphere by creating each vertices of a cube then replacing them correctly

NextStep:
02_ConstructingFractal: 
	- Add a regenerate function
	- Add a configuration panel
	- Make each branch grows instead of just spawning

05_CurvesAndSplines:
	- Enforced constraints just finished.
	- Continue the constraints
	- Add some volumes inside the scene
