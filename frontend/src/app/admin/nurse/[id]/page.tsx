"use client";
import CompactForm, { IFieldsProps } from "components/common/compact-form/CompactForm";
import { INurse, INurseList } from "interfaces/Nurse";
import React, { useEffect } from "react";
import { useState } from "react";
import { useRouter } from 'next/navigation';
import { getByIdNurse } from "api/nurse";
import { getSpecializations } from "api/specialization";
export default function NurseDetails({ params }: { params: { id: string } }) {
    const [nurse, setnurse] = useState<INurseList>({});
    const [specializations, setSpecialization] = useState([]);
    const router = useRouter();

    const fetchnurse = async () => {
        setnurse(await getByIdNurse(params.id));
    }


    useEffect(() => {
      const fetchSpecializations = async () => {
        let specialization = await getSpecializations();
        setSpecialization(specialization);
      }
      fetchSpecializations();
      fetchnurse();
    },[]);


    const handleSubmit = async (formData: INurse) => {
      router.push("/admin/nurse");
    }

    let fields: IFieldsProps = {
      title:"Nurse Details",
        disabled: true,
      fields: [
        {label: "Id ", name: "id", inputType: "text", placeholder: "id"},
        {label: "Nurse First Name", name: "nurseFirstName", inputType: "text", placeholder: "Nurse First Name"},
        {label: "Nurse last Name", name: "nurseLastName", inputType: "text", placeholder: "Nurse Last Name"},
        {label: "Nurse Phone Number", name: "nursePhoneNumber", inputType: "text", placeholder: "Nurse Phone Number"},
        {label: "Spacialization Name", name: " specialization.name", inputType: "text", placeholder: "Specialization Name"},

      ],
      heading: "Back to Nurses",
      data:nurse,
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