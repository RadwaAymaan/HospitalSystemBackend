"use client";

import React, { ChangeEvent, useCallback, useEffect } from "react";
import { useState } from "react";
import CompactForm, { IFieldsProps } from "components/common/compact-form/CompactForm";
import { getByIdInventory, getInventory, updateInventory } from "api/inventory";
import { IInventory } from "interfaces/Inventory";
import { useRouter } from 'next/navigation';


export default function UpdateInventory({params}: {params: {id: string}}){
    const [Inventory, setInventory] = useState<IInventory>({});
    const [message, setMessage] = useState<string>("");
    const router = useRouter();
    
    useEffect(() => {
        const fetchInventory = async () => {
            const inventory = await getByIdInventory(params.id)
          
            setInventory(inventory);
        }
        fetchInventory();
    
    }, []);


      const handleSubmit = async (formData:any) => {
        setMessage(await updateInventory(formData,params.id));
        router.push("/admin/inventory");
    }
    

    let fields: IFieldsProps = {
      title:"Update Inventory",
      disabled: false,
      fields: [
        {label: "Inventory Name", name: "inventoryName", inputType: "text", placeholder: "Name"  },
        {label: "Inventory Location", name: "inventoryLocation", inputType: "text", placeholder: "Inventory Location"},
        {label: "Inventory Capacity", name: "inventoryCapacity", inputType: "Number", placeholder: "Inventory Capacity"},
      ],
      data:Inventory,
      heading: "Update Inventory",
      onSubmit: handleSubmit,
    }
  
      return (
        <CompactForm
        title={fields.title}
        disabled={fields.disabled}
        fields={fields.fields} 
        heading={fields.heading}
        data={fields.data}
        dropDownList={fields.dropDownList}
        onSubmit={handleSubmit}>
        </CompactForm>
      )
  }
    
