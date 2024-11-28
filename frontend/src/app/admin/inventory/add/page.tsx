"use client";

import React, { useEffect } from "react";
import { useState } from "react";
import CompactForm, { IFieldsProps } from "components/common/compact-form/CompactForm";
import { addInventory, getInventory } from "api/inventory";
import { useRouter } from 'next/navigation';

export default function AddInventory(){
    const [inventories, setInventories] = useState([]);
    const router = useRouter();

    useEffect(() => {
      const fetchInventories = async () => {
        let inventories = await getInventory();
        setInventories(inventories);
        console.log("from page", inventories);
      }
      fetchInventories();
    },[]);

      const handleSubmit = async (formData: any) => {
        await addInventory(formData);
        router.push("/admin/inventory");

    }

    let fields: IFieldsProps = {
      title: "Add Inventory",
      disabled: false,
      fields: [
        {label: "Inventory Name", name: "inventoryName", inputType: "text", placeholder: "Name"},
        {label: "Inventory Location", name: "inventoryLocation", inputType: "text", placeholder: "Inventory Location"},
        {label: "Inventory Capacity", name: "inventorycapacity", inputType: "Number", placeholder: "Inventory Capacity"},
      ],
      heading: "Create Inventory",
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
      
    )}
