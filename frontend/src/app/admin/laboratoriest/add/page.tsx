"use client";

import React, { useEffect } from "react";
import { useState } from "react";
import CompactForm, { IFieldsProps } from "components/common/compact-form/CompactForm";
import { useRouter } from 'next/navigation';
import { addLaboratoriest, getLaboratoriest } from "api/laboratoriest";


export default function AddLaboratoriest(){
    const [Laboratoriests, setLaboratoriests] = useState([]);
    const router = useRouter();

    useEffect(() => {
      const fetchLaboratoriests = async () => {
        let Laboratoriests = await getLaboratoriest();
        setLaboratoriests(Laboratoriests);
       
      }
      fetchLaboratoriests();
    },[]);

      const handleSubmit = async (formData: any) => {
        await addLaboratoriest(formData);
     
        router.push("/admin/laboratoriest");

    }

    let fields: IFieldsProps = {
      title: "Add Laboratoriest",
      disabled: false,
      fields: [
        {label: "Laboratoriest First Name", name: "laboratoriestFirstName", inputType: "text", placeholder: "Laboratoriest First Name"},
        {label: "Laboratoriest last Name", name: "laboratoriestLastName", inputType: "text", placeholder: "Laboratoriest Last Name"},
        {label: "Laboratoriest Email", name: "laboratoriestEmail", inputType: "text", placeholder: "Laboratoriest Email"},
        {label: "Laboratoriest Phone Number", name: "laboratoriestPhoneNumber", inputType: "text", placeholder: "Laboratoriest Phone Number"},
        {label: "UserName", name: "userName", inputType: "text", placeholder: "UserName"},
        {label: "Laboratoriest Password", name: "password", inputType: "password", placeholder: "Password"},
        {label: "Laboratoriest Date of Birth", name: "dateOfBirth", inputType: "date", placeholder: "Date of Birth"},
        {label: "Laboratoriest Gender", name: "gender", inputType: "text", placeholder: "Gender"}
      ],
      heading: "Create Laboratoriest",
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
