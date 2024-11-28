export interface ISchedule
{
    id: number;
	doctorId: string;
	timeSlot: 
    {
		id: number;
		startTime: string;
		endTime: string;
        day:string
	}
}