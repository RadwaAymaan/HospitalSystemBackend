"use client";

import { GetDepartment } from "api/department";
import { GetByIdEmployee, GetEmployee, UpdateEmployee } from "api/employee";
import { getByIdInventory } from "api/inventory";
import CompactForm, { IFieldsProps } from "components/common/compact-form/CompactForm";
import { IDepartmentList } from "interfaces/IDepartment";
import { IEmployee, IEmployeeList, IUpdateEmployee } from "interfaces/IEmployee";
import { IInventoryList } from "interfaces/Inventory";
import React, { ChangeEvent, useEffect } from "react";
import { useState } from "react";

export default function UpdateEmployeeT({ params }: { params: { id: string } }) {
    const [employee, setEmployee] = useState<IInventoryList>({});


    const fetchEmployee = async () => {
        setEmployee(await getByIdInventory(params.id));
    }

    useEffect(() => {
        fetchEmployee();
    }, [])

    const handleSubmit = async (formData: IUpdateEmployee) => {
        await UpdateEmployee(formData, params.id);
    }

    let fields: IFieldsProps = {
        disabled: true,
      fields: [
        {label: "Employee Email", name: "employeeEmail", inputType: "text", placeholder: "Name"},
        {label: "Employee First Name", name: "employeeFirstName", inputType: "text", placeholder: "First Name"},
        {label: "Employee Last Name", name: "employeeLastName", inputType: "text", placeholder: "Last Name"},
        {label: "Employee Phone Number", name: "employeePhoneNumber", inputType: "text", placeholder: "Phone Number"},
        {label: "Employee UserName", name: "userName", inputType: "text", placeholder: "UserName"},
        {label: "Employee Date of Birth", name: "dateOfBirth", inputType: "date", placeholder: "Date of Birth"},
        {label: "Employee Gender", name: "gender", inputType: "text", placeholder: "Gender"}
      ],
      heading: "Update Employee",
      data:employee,
      onSubmit: handleSubmit,
      dropDownList: {label: "Departments", name: "departmentId", placeholder: "Departments", value: "id", displayName:"departmentName", data: departments}
    }

    return (
      <CompactForm
      disabled={fields.disabled}
      fields={fields.fields} 
      heading={fields.heading}
      data={employee}
      dropDownList={fields.dropDownList}
      onSubmit={handleSubmit}>
      </CompactForm>
    )
}