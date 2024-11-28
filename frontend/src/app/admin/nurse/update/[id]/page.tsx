"use client";

import React, { ChangeEvent, useCallback, useEffect } from "react";
import { useState } from "react";
import CompactForm, { IFieldsProps } from "components/common/compact-form/CompactForm";

import { INurse, INurseList } from "interfaces/Nurse";
import { useRouter } from 'next/navigation';
import { getByIdNurse, updateNurse } from "api/nurse";
import { getSpecializations } from "api/specialization";


export default function UpdateNurse({params}: {params: {id: string}}){
    const [nurse, setNurse] = useState<INurseList>({});
    const [message, setMessage] = useState<string>("");
    const [specializations, setSpecializations] = useState([]);
    const router = useRouter();
    
    useEffect(() => {
        const fetchNurse = async () => {
            const nurse = await getByIdNurse(params.id)
            setNurse(nurse);
        }
        fetchNurse();
    
    }, []);
    useEffect(() => {
      const fetchSpecializations = async () => {
        let specializations = await getSpecializations();
        setSpecializations(specializations);
       
      }
      fetchSpecializations();
    },[]);


      const handleSubmit = async (formData:any) => {
        setMessage(await updateNurse(formData,params.id));
        router.push("/admin/nurse");
    }
    

    let fields: IFieldsProps = {
      title:"Update Nurse",
      disabled: false,
      fields: [
        {label: "Nurse First Name", name: "nurseFirstName", inputType: "text", placeholder: "Nurse First Name"},
        {label: "Nurse last Name", name: "nurseLastName", inputType: "text", placeholder: "Nurse Last Name"},
        {label: "Nurse Email", name: "nurseEmail", inputType: "text", placeholder: "Nurse Email"},
        {label: "Nurse Phone Number", name: "nursePhoneNumber", inputType: "text", placeholder: "Nurse Phone Number"},
        {label: "Nurse UserName", name: "userName", inputType: "text", placeholder: "UserName"},
      ],
      data:nurse,
      heading: "Update Nurse",
      onSubmit: handleSubmit,
      dropDownList: {label: "Specialzations", name: "specialzation", placeholder: "specialization", value: "id", displayName:"specializationName", data:specializations }

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
    
