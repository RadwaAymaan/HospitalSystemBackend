"use client";
import CompactForm, { IFieldsProps } from "components/common/compact-form/CompactForm";
import { ILaboratoriest, ILaboratoriestList } from "interfaces/Laboratoriest";
import React, { useEffect } from "react";
import { useState } from "react";
import { useRouter } from 'next/navigation';
import { getByIdLaboratoriest } from "api/laboratoriest";
export default function LaboratoriestDetails({ params }: { params: { id: string } }) {
    const [Laboratoriest, setLaboratoriest] = useState<ILaboratoriestList>({});
    const router = useRouter();

    const fetchLaboratoriest = async () => {
        setLaboratoriest(await getByIdLaboratoriest(params.id));
    }


    useEffect(() => {
        fetchLaboratoriest();
    }, [])

    const handleSubmit = async (formData: ILaboratoriest) => {
      router.push("/admin/laboratoriest");
    }

    let fields: IFieldsProps = {
      title:"Laboratoriest Details",
        disabled: true,
      fields: [
        {label: "Id ", name: "id", inputType: "text", placeholder: "id"},
        {label: "Laboratoriest First Name", name: "laboratoriestFirstName", inputType: "text", placeholder: "Laboratoriest First Name"},
        {label: "Laboratoriest last Name", name: "laboratoriestLastName", inputType: "text", placeholder: "Laboratoriest Last Name"},
        {label: "Laboratoriest Phone Number", name: "laboratoriestPhoneNumber", inputType: "text", placeholder: "Laboratoriest Phone Number"},
        {label: "UserName", name: "userName", inputType: "text", placeholder: "UserName"},

      ],
      heading: "Back to Laboratoriests",
      data:Laboratoriest,
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