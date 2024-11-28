"use client";

import { GetDepartment } from "api/department";
import { AddEmployee } from "api/employee";
import CompactForm, { IFieldsProps } from "components/common/compact-form/CompactForm";
import { IDepartmentList } from "interfaces/IDepartment";
import { IEmployee } from "interfaces/IEmployee";
import { useEffect, useState } from "react";

export default function AddEmployeeC() {

    const [departments, setDepartments] = useState<IDepartmentList[]>([]);


    const fetchDepatments = async () => {
      setDepartments(await GetDepartment());
  }
    useEffect(() => {
       
        fetchDepatments();
    }, [])

    const handleSubmit = async (formData: IEmployee) => {
        await AddEmployee(formData);
    }

    let fields: IFieldsProps = {
      fields: [
        {label: "Employee Email", name: "employeeEmail", inputType: "text", placeholder: "Name"},
        {label: "Employee First Name", name: "employeeFirstName", inputType: "text", placeholder: "First Name"},
        {label: "Employee Last Name", name: "employeeLastName", inputType: "text", placeholder: "Last Name"},
        {label: "Employee Phone Number", name: "employeePhoneNumber", inputType: "text", placeholder: "Phone Number"},
        {label: "Employee UserName", name: "userName", inputType: "text", placeholder: "UserName"},
        {label: "Employee Password", name: "password", inputType: "text", placeholder: "Password"},
        {label: "Employee Date of Birth", name: "dateOfBirth", inputType: "date", placeholder: "Date of Birth"},
        {label: "Employee Gender", name: "gender", inputType: "text", placeholder: "Gender"}
      ],
      heading: "Register Employee",
      data:{},
      onSubmit: handleSubmit,
      dropDownList: {label: "Departments", name: "departmentId", placeholder: "Departments", value: "id", displayName:"departmentName", data: departments}
    }

    return (
      <CompactForm 
      fields={fields.fields} 
      heading={fields.heading} 
      dropDownList={fields.dropDownList}
      onSubmit={handleSubmit}>
      </CompactForm>
    )
}