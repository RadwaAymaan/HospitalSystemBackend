import { IDepartmentList } from "./IDepartment";

export interface IEmployee{
    employeeEmail: string,
    employeeFirstName: string,
    employeeLastName: string,
    employeePhoneNumber:string,
    userName: string,
    password: string,
    dateOfBirth: Date,
    gender: string,
    departmentId: number,
        
}
export interface IUpdateEmployee{
    employeeEmail: string,
    employeeFirstName: string,
    employeeLastName: string,
    employeePhoneNumber:string,
    userName: string,
    dateOfBirth: Date,
    gender: string,
    departmentId: number,
        
}
export interface IEmployeeList {
    [x: string]: IEmployeeList[] | PromiseLike<IEmployeeList[]>;
    id: string,
    employeeEmail: string,
    employeeFirstName: string,
    employeeLastName: string,
    employeePhoneNumber:string,
    userName: string,
    dateOfBirth: Date,
    gender: string,
    department:IDepartmentList

}

