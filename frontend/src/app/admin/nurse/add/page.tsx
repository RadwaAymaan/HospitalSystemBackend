"use client";

import React, { useEffect } from "react";
import { useState } from "react";
import CompactForm, { IFieldsProps } from "components/common/compact-form/CompactForm";

import { useRouter } from 'next/navigation';
import { getSpecializations } from "api/specialization";
import { addNurse, getNurse } from "api/nurse";

export default function AddNurse(){
    const [nurses, setNurses] = useState([]);
    const [specializations, setSpecializations] = useState([]);
    const router = useRouter();

    useEffect(() => {
      const fetchNurses = async () => {
        let nurses = await getNurse();
        setNurses(nurses);
       
      }
      fetchNurses();
    },[]);
    useEffect(() => {
      const fetchSpecializations = async () => {
        let specializations = await getSpecializations();
        setSpecializations(specializations);
       
      }
      fetchSpecializations();
    },[]);

      const handleSubmit = async (formData: any) => {
        await addNurse(formData);
     
        router.push("/admin/nurse");

    }

    let fields: IFieldsProps = {
      title: "Add Nurse",
      disabled: false,
      fields: [
        {label: "Nurse First Name", name: "nurseFirstName", inputType: "text", placeholder: "Nurse First Name"},
        {label: "Nurse last Name", name: "nurseLastName", inputType: "text", placeholder: "Nurse Last Name"},
        {label: "Nurse Email", name: "nurseEmail", inputType: "text", placeholder: "Nurse Email"},
        {label: "Nurse Phone Number", name: "nursePhoneNumber", inputType: "text", placeholder: "Nurse Phone Number"},
        {label: "Nurse UserName", name: "userName", inputType: "text", placeholder: "UserName"},
        {label: "Nurse Password", name: "password", inputType: "password", placeholder: "Password"},
        {label: "Nurse Date of Birth", name: "dateOfBirth", inputType: "date", placeholder: "Date of Birth"},
        {label: "Nurse Gender", name: "gender", inputType: "text", placeholder: "Gender"}
      ],
      heading: "Create Nurse",
      onSubmit: handleSubmit,
      dropDownList: {label: "Specialzations", name: "specializationId", placeholder: "specialization", value: "id", displayName:"specializationName", data:specializations }
    }

    return (
        <CompactForm
        title={fields.title}
        disabled={fields.disabled}
        fields={fields.fields} 
        dropDownList={fields.dropDownList}
        heading={fields.heading}
        data={fields.data}
        onSubmit={handleSubmit}>
        </CompactForm>
      
    )}
