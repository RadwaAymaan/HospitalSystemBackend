"use client";

import React, { ChangeEvent, useCallback, useEffect } from "react";
import { useState } from "react";
import CompactForm, { IFieldsProps } from "components/common/compact-form/CompactForm";
import { GetByIdRoom, GetRoom, UpdateRoom } from "api/room";
import { IRoom } from "interfaces/IRoom";
import { useRouter } from 'next/navigation';
import { GetRoomType } from "api/roomType";


export default function UpdateRooms({params}: {params: {id: string}}){
    const [Room, setRoom] = useState<IRoom>({});
    const [roomTypes, setRoomTypes] = useState([]);
    const [message, setMessage] = useState<string>("");
    const router = useRouter();
    
    useEffect(() => {
        const fetchRoom = async () => {
            const room = await GetByIdRoom(params.id)
            let roomToUpdate: IRoom = {
                roomNumber: room.roomNumber,
                availability: room.availability,
                roomTypeId: room.roomType.id
            };
            setRoom(roomToUpdate);
        }
        fetchRoom();

        const fetchRoomType = async () => {
          let roomTypes = await GetRoomType();
          setRoomTypes(roomTypes);
          console.log("from page", roomTypes);
        }
        fetchRoomType();
    
    }, []);


      const handleSubmit = async (formData:any) => {
        formData.availability=true;
        setMessage(await UpdateRoom(formData,params.id));
        router.push("/admin/room");
    }
    

    let fields: IFieldsProps = {
      title: "Update Room",
      disabled: false,
      fields: [
        {label: "Room Number", name: "roomNumber", inputType: "number", placeholder: "Room Number"},
      ],
      data:Room,
      heading: "Update Room",
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
      
    )
  }
    
