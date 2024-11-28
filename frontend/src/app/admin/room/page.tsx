'use client';

import { Box } from "@chakra-ui/react";
import RoomColumnsTable from "./components/RoomColumnsTable";
import { GetRoom } from "api/room";

const fetchRoom = async () => {
  return await GetRoom();
}

export default function ListRoom() {  
    
    return (
        <Box pt={{ base: '130px', md: '80px', xl: '80px' }}>
         <RoomColumnsTable />
        </Box>
      );
}