export interface INurseList {
  id: string;
  nurseEmail: string;
  nurseFirstName: string;
  nurseLastName: string;
  nursePhoneNumber: string;
  userName:string;
  specializationName:string;
  specialization:{
      id:number;
      specializationName:string;
  }
  
}

export interface INurse {
  nurseEmail: string;
  nurseFirstName: string;
  nurseLastName: string;
  nursePhoneNumber: string;
  userName: string;
  password:string;
  gender:string;
  dateOfBirth:Date
  specializationId: number;
}




