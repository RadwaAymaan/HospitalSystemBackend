"use client";
import CompactForm, { IFieldsProps } from "components/common/compact-form/CompactForm";
import { IMedicine, IMedicineList } from "interfaces/Medicine";
import React, { useEffect } from "react";
import { useState } from "react";
import { useRouter } from 'next/navigation';
import { getByIdMedicine } from "api/medicine";


export default function MedicineDetails({ params }: { params: { id: string } }) {
    const [Medicine, setMedicine] = useState<IMedicineList>({});
    const router = useRouter();

    const fetchMedicine = async () => {
        setMedicine(await getByIdMedicine(params.id));
    }


    useEffect(() => {
        fetchMedicine();
    }, [])

    const handleSubmit = async (formData: IMedicine) => {
      router.push("/admin/medicine");
    }

    let fields: IFieldsProps = {
      title:"Medicine Details",
        disabled: true,
      fields: [
        {label: "Medicine Name", name: "medicineName", inputType: "text", placeholder: "Medicine Name"},
        {label: "Medicine Description", name: "medicineDescription", inputType: "text", placeholder: "Medicine Description"},
        {label: "Medicine Dosage", name: "medicineDosage", inputType: "number", placeholder: "Medicine Dosage"},
      ],
      heading: "Back to Medicines",
      data:Medicine,
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