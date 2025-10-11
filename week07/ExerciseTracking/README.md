# Week07 - ExerciseTracking (Inheritance & Polymorphism)

This is the final foundation program for Week 07 (CSE 210): **Inheritance and Polymorphism**.

## How to run
1. Create a new .NET Console project or place these files in an existing one.
2. Put all `*.cs` files in the same project and build.
3. Run the app. You should see three summary lines printed.
4. Take a screenshot of the console output and replace `screenshot.png` with your real screenshot.

> Units (consistent):
> - Distance: **miles**
> - Speed: **mph**
> - Pace: **min/mi**

## Files
- `Program.cs` — Entry point printing summaries using polymorphism.
- `Activity.cs` — Abstract base class with shared data and abstract methods.
- `Running.cs` — Stores distance -> computes speed and pace.
- `Cycling.cs` — Stores speed -> computes distance and pace.
- `Swimming.cs` — Stores laps (50m each) -> converts to miles, computes speed and pace.
- `screenshot.png` — **Replace with your real run screenshot before pushing to GitHub.**

## Screenshot reminder
Replace the placeholder `screenshot.png` with an actual screenshot that shows all three activities printed in the console.
