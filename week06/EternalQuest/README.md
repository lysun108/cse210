# Eternal Quest (CSE 210 W06)
How to run:
- `dotnet run` (first run can `Save` to create `goals.txt`, later `Load`)

Meets spec:
- Base `Goal` class + derived `SimpleGoal`, `EternalGoal`, `ChecklistGoal`
- Create, record event, list with [ ]/[X] and progress (N/M)
- Show total score
- Save/Load to text file (serialization per-line)

Creativity:
- Level system (Level = 1 + totalScore/500)
- `NegativeGoal` (deduct points for bad habits)
- `ProgressGoal` (partial progress toward large goals + completion bonus)
