'use client';

import { Box } from "@chakra-ui/react";
import { useEffect, useState } from "react";
import { GetRoomType } from "api/roomType";
import { IRoomType } from "interfaces/IRoomType";
import RoomTypeColumnTable from "./_component/roomTypeColumnsTable";



export default function ListroomTypes() 
{
    const [roomTypes, setroomTypes] = useState<IRoomType[]>([]);

    useEffect(() => {
        const fetchroomType = async () => {
            setroomTypes(await GetRoomType());
        }
        fetchroomType();
    }, []);
    console.log(roomTypes);
    return (
        <Box pt={{ base: '130px', md: '80px', xl: '80px' }}>
            <RoomTypeColumnTable />
        </Box>
      );
}