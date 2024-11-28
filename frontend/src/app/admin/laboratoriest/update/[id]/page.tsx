"use client";

import React, { ChangeEvent, useCallback, useEffect } from "react";
import { useState } from "react";
import CompactForm, { IFieldsProps } from "components/common/compact-form/CompactForm";
import { useRouter } from 'next/navigation';
import { getByIdLaboratoriest, updateLaboratoriest } from "api/laboratoriest";
import { ILaboratoriestList } from "interfaces/Laboratoriest";



export default function UpdateLaboratoriest({params}: {params: {id: string}}){
    const [Laboratoriest, setLaboratoriest] = useState<ILaboratoriestList>({});
    const [message, setMessage] = useState<string>("");
    const router = useRouter();
    
    useEffect(() => {
        const fetchLaboratoriest = async () => {
            const Laboratoriest = await getByIdLaboratoriest(params.id)
            setLaboratoriest(Laboratoriest);
        }
        fetchLaboratoriest();
    
    }, []);



      const handleSubmit = async (formData:any) => {
        setMessage(await updateLaboratoriest(formData,params.id));
        router.push("/admin/laboratoriest");
    }
    

    let fields: IFieldsProps = {
      title:"Update Laboratoriest",
      disabled: false,
      fields: [
        {label: "Laboratoriest First Name", name: "laboratoriestFirstName", inputType: "text", placeholder: "Laboratoriest First Name"},
        {label: "Laboratoriest last Name", name: "laboratoriestLastName", inputType: "text", placeholder: "Laboratoriest Last Name"},
        {label: "Laboratoriest Email", name: "laboratoriestEmail", inputType: "text", placeholder: "Laboratoriest Email"},
        {label: "Laboratoriest Phone Number", name: "laboratoriestPhoneNumber", inputType: "text", placeholder: "Laboratoriest Phone Number"},
        {label: "UserName", name: "userName", inputType: "text", placeholder: "UserName"},
      ],
      data:Laboratoriest,
      heading: "Update Laboratoriest",
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
    
