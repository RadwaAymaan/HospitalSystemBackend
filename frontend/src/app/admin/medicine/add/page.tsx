"use client";

import React, { useEffect } from "react";
import { useState } from "react";
import CompactForm, { IFieldsProps } from "components/common/compact-form/CompactForm";
import { useRouter } from 'next/navigation';
import { addMedicine, getMedicine } from "api/medicine";



export default function AddMedicine(){
    const [Medicines, setMedicines] = useState([]);
    const router = useRouter();

    useEffect(() => {
      const fetchMedicines = async () => {
        let Medicines = await getMedicine();
        setMedicines(Medicines);
       
      }
      fetchMedicines();
    },[]);

      const handleSubmit = async (formData: any) => {
        await addMedicine(formData);
     
        router.push("/admin/medicine");

    }

    let fields: IFieldsProps = {
      title: "Add Medicine",
      disabled: false,
      fields: [
        {label: "Medicine Name", name: "medicineName", inputType: "text", placeholder: "Medicine Name"},
        {label: "Medicine Description", name: "medicineDescription", inputType: "text", placeholder: "Medicine Description"},
        {label: "Medicine Dosage", name: "medicineDosage", inputType: "number", placeholder: "Medicine Dosage"},
        
      ],
      heading: "Create Medicine",
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
