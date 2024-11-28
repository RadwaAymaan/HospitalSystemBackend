export interface IAppointment
{  
		id: number;
		startTime: string;
		endTime: string;
        date:Date;
        patientName:string;
        doctorName:string
	
}
export interface IInsertAppointment
{ 
		startTime: string;
		endTime: string;
        date:Date;
        patientId:string;
        doctorId:string
}
