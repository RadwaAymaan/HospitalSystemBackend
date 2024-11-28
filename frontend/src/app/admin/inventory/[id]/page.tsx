"use client";

import { GetDepartment } from "api/department";
import { GetByIdEmployee, GetEmployee, UpdateEmployee } from "api/employee";
import { getByIdInventory, getInventory, updateInventory } from "api/inventory";
import CompactForm, { IFieldsProps } from "components/common/compact-form/CompactForm";
import { IDepartmentList } from "interfaces/IDepartment";
import { IEmployee, IEmployeeList, IUpdateEmployee } from "interfaces/IEmployee";
import { IInventory, IInventoryList } from "interfaces/Inventory";
import React, { ChangeEvent, useEffect } from "react";
import { useState } from "react";
import { useRouter } from 'next/navigation';
export default function UpdateEmployeeT({ params }: { params: { id: string } }) {
    const [employee, setEmployee] = useState<IInventoryList>({});
    const router = useRouter();

    const fetchEmployee = async () => {
        setEmployee(await getByIdInventory(params.id));
    }

    useEffect(() => {
        fetchEmployee();
    }, [])

    const handleSubmit = async (formData: IInventory) => {
      router.push("/admin/inventory");
    }

    let fields: IFieldsProps = {
      title:"Inventory Details",
        disabled: true,
      fields: [
        {label: "Id ", name: "id", inputType: "text", placeholder: "id"},
        {label: "Inventory Name", name: "inventoryName", inputType: "text", placeholder: "Name"},
        {label: "Inventory Location", name: "inventoryLocation", inputType: "text", placeholder: "Inventory Location"},
        {label: "Inventory Capacity", name: "inventoryCapacity", inputType: "Number", placeholder: "Inventory Capacity"},
      ],
      heading: "Back to Inventories",
      data:employee,
      onSubmit: handleSubmit,
      
    }

    return (
      <CompactForm
      title={fields.title}
      disabled={fields.disabled}
      fields={fields.fields} 
      heading={fields.heading}
      data={fields.data}
      onSubmit={handleSubmit}>
      </CompactForm>
    )
}