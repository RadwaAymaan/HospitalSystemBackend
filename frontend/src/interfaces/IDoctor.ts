export interface IDoctor {
    id: string;
	doctorEmail: string;
	doctorFirstName: string;
	doctorLastName: string; 
	doctorPhoneNumber:string;
	userName:string;
    specialization:{
        id:number;
        specializationName:string;
    }
}
export interface IInsertDoctor {
	doctorEmail: string;
	doctorFirstName: string;
	doctorLastName: string; 
	doctorPhoneNumber:string;
	userName:string;
    password:string;
    gender:string;
	dateOfBirth:Date
    specializationId:number;
}