"use client";

import React, { useEffect } from "react";
import { useState } from "react";
import CompactForm, { IFieldsProps } from "components/common/compact-form/CompactForm";
import { AddRoom, GetRoom } from "api/room";
import { useRouter } from 'next/navigation';
import { GetRoomType } from "api/roomType";

export default function AddRooms(){
    const [roomTypes, setRoomTypes] = useState([]);
    const router = useRouter();

    useEffect(() => {
      const fetchRoomType = async () => {
        let roomTypes = await GetRoomType();
        setRoomTypes(roomTypes);
        console.log("from page", roomTypes);
      }
      fetchRoomType();
    },[]);

      const handleSubmit = async (formData: any) => {
        formData.availability=true;
        await AddRoom(formData);
        router.push("/admin/room");

    }

    let fields: IFieldsProps = {
      title: "Add Room",
      disabled: false,
      fields: [
        {label: "Room Number", name: "roomNumber", inputType: "number", placeholder: "Name"},
      ],
      heading: "Create Room",
      dropDownList: {label: "Room Type", name: "roomTypeId", placeholder: "Room Type", value: "id", displayName:"type", data: roomTypes},
      onSubmit: handleSubmit,
      
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
      
    )}
