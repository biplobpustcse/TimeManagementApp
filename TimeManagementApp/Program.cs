using TimeManagementApp;

TimeSlot givenSlot = new TimeSlot
{
    StartTime = new DateTime(2024, 8, 19, 14, 0, 0),
    EndTime = new DateTime(2024, 8, 19, 15, 0, 0)
};

TimeSlot[] existingSlots = new TimeSlot[]
{ new TimeSlot
    {
        StartTime = new DateTime(2024, 8, 19, 13, 0, 0),
        EndTime = new DateTime(2024, 8, 19, 14, 30, 0)
    },
    new TimeSlot
    {
        StartTime = new DateTime(2024, 8, 19, 15, 30, 0),
        EndTime = new DateTime(2024, 8, 19, 16, 30, 0)
    }
};


if (givenSlot.StartTime > givenSlot.EndTime)
{
    Console.WriteLine("The StartTime of any time slot will always be before the EndTime. ");
    return;
}
//confilctedSlot
List<TimeSlot> confilctedSlotList = new List<TimeSlot>();


//main section
bool result = false;
if (givenSlot.StartTime == givenSlot.EndTime)
{
    result = false;
}
else
{
    #region By using loop
    //foreach (var item in existingSlots)
    //{
    //    if (item.StartTime > item.EndTime)
    //    {
    //        Console.WriteLine("The StartTime of any time slot will always be before the EndTime. ");
    //        break;
    //    }

    //    if (
    //        (givenSlot.StartTime >= item.StartTime && givenSlot.StartTime < item.EndTime)
    //        || (givenSlot.EndTime >= item.StartTime && givenSlot.EndTime <= item.EndTime)
    //        || (givenSlot.StartTime <= item.StartTime && givenSlot.EndTime >= item.EndTime)
    //        )
    //    {
    //        result = true;
    //        //break;

    //        //confilctedSlot
    //        confilctedSlotList.Add(item);
    //    }
    //} 
    #endregion

    #region By usinglinq 
    confilctedSlotList.AddRange(existingSlots.Where(x =>
       (givenSlot.StartTime >= x.StartTime && givenSlot.StartTime < x.EndTime)
        || (givenSlot.EndTime >= x.StartTime && givenSlot.EndTime <= x.EndTime)
        || (givenSlot.StartTime <= x.StartTime && givenSlot.EndTime >= x.EndTime))
     );

    if (confilctedSlotList.Count > 0)
    {
        result = true;
    }
    #endregion



}
Console.WriteLine(result);

//confilctedSlot
foreach (var item in confilctedSlotList)
{
    Console.WriteLine(item.StartTime + " " + item.EndTime);
}

