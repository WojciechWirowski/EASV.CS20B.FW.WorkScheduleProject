| Working Schedule |  WeekDay   | StartTime | EndTime | Hours |employId|
| ---------------- |--------- | --------- | ------- | ----- |-----|
| 1                | Monday | 5pm       | 9pm     | 4     |
| 2                | 2  | 3pm       | 8pm     | 5     |
| 3                | Wednesday  | 7pm       | 8pm     | 1     |
|4|                 4|3|5|8|4|




Fei : 1 12-20 2 5-7

Admin do: 

- Click Fei ID:
- Input year, mouth, day, start time, end time.
- Otherwise:  Weekday- Monday 12-5pm 
- 1.2022 - Monday 5- 12  Date : 2021.5.12 - 19 - 26 - 

```c#
public void insertTime(yearsNo yearNo, WeekDay weekDay, StartTime startTime, EndTime endTime){
    WorkingSchedule workingSchedule = new WorkingSchedule(){
        WeekDay = weekDay,
        StartTime = startTime,
        EndTime = endTime,
        hour = endTime - startTime
    };
    workingSchedule.Date = getDate(weekNo,weekDay);
    
    
}
```

