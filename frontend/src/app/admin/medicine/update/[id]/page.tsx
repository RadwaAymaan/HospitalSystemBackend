"use client";

import React, { ChangeEvent, useCallback, useEffect } from "react";
import { useState } from "react";
import CompactForm, { IFieldsProps } from "components/common/compact-form/CompactForm";
import { useRouter } from 'next/navigation';
import { IMedicineList } from "interfaces/Medicine";
import { getByIdMedicine, updateMedicine } from "api/medicine";



export default function UpdateMedicine({params}: {params: {id: string}}){
    const [Medicine, setMedicine] = useState<IMedicineList>({});
    const [message, setMessage] = useState<string>("");
    const router = useRouter();
    
    useEffect(() => {
        const fetchMedicine = async () => {
            const Medicine = await getByIdMedicine(params.id)
            setMedicine(Medicine);
        }
        fetchMedicine();
    
    }, []);



      const handleSubmit = async (formData:any) => {
        setMessage(await updateMedicine(formData,params.id));
        router.push("/admin/medicine");
    }
    

    let fields: IFieldsProps = {
      title:"Update Medicine",
      disabled: false,
      fields: [
        {label: "Medicine Name", name: "medicineName", inputType: "text", placeholder: "Medicine Name"},
        {label: "Medicine Description", name: "medicineDescription", inputType: "text", placeholder: "Medicine Description"},
        {label: "Medicine Dosage", name: "medicineDosage", inputType: "number", placeholder: "Medicine Dosage"},
      ],
      data:Medicine,
      heading: "Update Medicine",
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
    
