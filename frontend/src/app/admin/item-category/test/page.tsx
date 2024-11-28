"use client";

import React, { useEffect } from "react";
import { useState } from "react";
import { AddItemCategory, getInventories } from "api/item-category";
import CompactForm, { IFieldsProps } from "components/common/compact-form/CompactForm";
import { getInventory } from "api/inventory";

export default function AddCategory(){
    const [inventories, setInventories] = useState([]);

    useEffect(() => {
      const fetchInventories = async () => {
        let inventories = await getInventory();
        setInventories(inventories);
        console.log("from page", inventories);
      }
      fetchInventories();
    },[]);

      const handleSubmit = async (formData: any) => {
        console.log("on submit", formData);
        await AddItemCategory(formData);
    }

    let fields: IFieldsProps = {
      disabled : false,
      title:"sbhvd",
      fields: [
        {label: "Category Name", name: "categoryName", inputType: "text", placeholder: "Name"},
        {label: "Reference Number", name: "referenceNumber", inputType: "number", placeholder: "Reference Number"}
      ],
      heading: "Create Item Category",
      onSubmit: handleSubmit,
      dropDownList: {label: "Inventories", name: "inventoryId", placeholder: "Inventory", value: "id", displayName:"inventoryName", data: inventories}
    }

    return (
      <CompactForm 
      disabled={fields.disabled}
      title={fields.title}
      fields={fields.fields} 
      heading={fields.heading} 
      dropDownList={fields.dropDownList}
      onSubmit={handleSubmit}>
      </CompactForm>
    )
}