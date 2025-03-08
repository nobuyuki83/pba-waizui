# Physics-based Animation 4860-1081 2025S

![teaser](doc/rep_image.png)

Lecture at graduate school of information science and technology in the university of Tokyo, spring semester, 2025

#### ITC-LMS 

For Slack and GitHub Classroom invitations

- https://utol.ecc.u-tokyo.ac.jp/lms/course?idnumber=2025_4886_4860-1081_01

#### Instructor
Dr. Nobuyuki Umetani 
- email: n.umetani@gmail.com
- url: http://www.nobuyuki-umetani.com/
- lab's website: https://cgenglab.github.io/en/

#### Time
- Monday 2rd period, 10:25pm - 12:10pm

#### Course Description

Computer-generated images are everywhere in movies, video games, and VR. This course is an introduction to the techniques to animate objects in computer graphics based on the law of physics. The aim of the course is to get familiar with applied mathematics such as linear algebra, vector analysis, partial differential equations, tensor mechanics, variational principle, optimization, and numerical analysis through the animation techniques for particle systems, rigid bodies, and elastic bodies. There are C#/Rust/Python programming assignments to acquire research-oriented graphics programming skills. The students also learn basics use of the computer graphics software Unity and Blender.

Topics:
- mass-spring simulation
- rigid body simulation
- elastic body simulation
- cloth and hair modeling & simulation
- collision-detection using spatial hashing
- finite boundary method



## Lecture Schedule

| Day | Topic | Assignment | Slide |
|:----|:---|:---|-----|
| (1)<br> Apr. 7 | **Introduction**<br> | | |
| (2)<br> Apr. 21 | **Data Structure**<br>data structure for simulation<br/>Implicit surface | | |
| (3)<br> Apr. 28 | **Time Integration**<br/> backward & forward Euler method,<br/> particle system | | |
| (4)<br> May 8 | **Newtonian Mechanics**<br/>| | |
| (5)<br> May 12 | **Collision Detection**<br/>principal component analysis<br>sort & sweep method | | |
| (6)<br> May 19 | **Optimization**<br>bounding volume hierarchy<br>Hessian & Jacobian | | |
| (7)<br> May 26 | **Simple Elastic Energy**<br/>Newton-Raphson method<br>mass-spring system | | |
| (8)<br> June 9 | **Dynamic Deformation**<br>Variational time integration<br /> | | |
| (9)<br> June 16 | **Linear System Solver**<br/>Sparse matrix data structure<br/>Conjugate gradient method | | |
| (10)<br> June 23 | **Optimization with Constraint**<br/> Lagrange multiplier method | | |
| (11)<br> June 30 | **Rotation**<br>Rotation representation | | |
| (12)<br> July 7 | **Rigid Body Dynamics** <br/>inertia tensor, <br/>angular velocity | | |
| (13)<br> July 14 | **Continuum Mechanics**<br> tensor,<br> finite element method |  | |

#### Slides

To be Added

## Grading

- 20% lecture attendance
  - Attendance is counted based on writing a secret keyword on LMS. The keyword is announced for each lecture.  
- 80% small assignments
  - see below

#### Assignments

There are many small programming assignments. To do the assignments, you need to create your own copy of this repository through **GitHub Classroom**.  These assignements needs to be submitted using **pull request** functionality of the GitHub. Look at the following document. 

[How to Submit the Assignments](doc/submit.md)

| Task ID                    | Title                        | Thumbnail                                  |
| :------------------------- | :--------------------------- | :----------------------------------------- |
| task00 | Building C++ Program with CMake | |
| task01 | Implicit Time Integration    | |
| task02 | Linear Momentum Conservation | |
| task03 | Acceleration of N-body Simulation | |
| task04 | Accelerated nearest search using Kd-Tree |  |
| task07 | Solving Laplace equation with Gauss-Seidel Method | |
| task05 | Gradient Descent for Mass-Spring Simulation | |
| task06 | Dynamic Mass-spring System using Variational Euler Time Integration | |
| task08 | Controlling Volume of a Mesh using Lagrange-Multiplier Method |  |
| task09 | Rotation and Energy Minimization | |
| task10 | Simulation of Rigid Body Precession | |


#### Policy

- Do the assignment by yourself. Don't share the assignments with others.
- Don't post the answers of the assignment on Slack 
- Late submission of an assignment is subject to grade deduction
- Score each assignment will not be open soon (instructor needs to adjust weights of the score later)



## Reading Material

- [Ten Min Physics (Youtube channel)](https://www.youtube.com/@TenMinutePhysics/videos)
- [Physically Based Modeling: Principles and Practice, Siggraph '97 Course notes by Dr. Baraff](http://www.cs.cmu.edu/~baraff/sigcourse/index.html)
- [Physics-Based Animation  by Kenny Erleben et al. (free textobook about rigid body dynamics)](https://iphys.wordpress.com/2020/01/12/free-textbook-physics-based-animation/)
- [Dynamic Deformables: Implementation and Production Practicalities, SIGGRAPH 2020 Courses](http://www.tkim.graphics/DYNAMIC_DEFORMABLES/)
- [Awesome Computer Graphics (GitHub)](https://github.com/luisnts/awesome-computer-graphics)
- [Skinning: Real-time Shape Deformation SIGGRAPH 2014 Course](https://skinning.org/)


#### My Past Lectures
- [Applied Computer Graphics 2024S](https://github.com/nobuyuki83/Applied_Computer_Graphics_2024S)
- [Physics-based Animation 2023S](https://github.com/nobuyuki83/Physics-based_Animation_2023S)
- [Applied Computer Graphics 2022S](https://github.com/nobuyuki83/Applied_Computer_Graphics_2022S)
- [Physics-based Animation 2021S](https://github.com/nobuyuki83/Physics-based_Animation_2021S)
