"use client";

import { GetByIdRoom } from "api/room";
import CompactForm, { IFieldsProps } from "components/common/compact-form/CompactForm";
import { IRoom, IRoomList } from "interfaces/IRoom";
import React, { useEffect } from "react";
import { useState } from "react";
import { useRouter } from 'next/navigation';
export default function RoomDetails({ params }: { params: { id: string } }) {
    const [room, setRoom] = useState<IRoomList>({});
    const router = useRouter();

    const fetchRoom = async () => {
      setRoom(await GetByIdRoom(params.id));
    }

    useEffect(() => {
        fetchRoom();
    }, [])

    const handleSubmit = async (formData: IRoom) => {
      router.push("/admin/room");
    }

    let fields: IFieldsProps = {
      title:"Room Details",
        disabled: true,
        fields: [
          {label: "Room Number", name: "roomNumber", inputType: "number", placeholder: "Room Number"},
          {label: "Room Type", name: "roomType.type", inputType: "text", placeholder: "Room Type"},
        ],
      heading: "Back to Rooms",
      data:room,
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