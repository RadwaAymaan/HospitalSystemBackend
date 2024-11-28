'use client';

import { Box } from "@chakra-ui/react";
import { ITimeSlot } from "interfaces/ITimeSlot";
import { useEffect, useState } from "react";
import { GetTimeSlot } from "api/timeslot";
import TimeSlotColumnTable from "./_component/timeSlotColumnsTable";



export default function ListTimeSlots() 
{
    const [TimeSlots, setTimeSlots] = useState<ITimeSlot[]>([]);

    useEffect(() => {
        const fetchTimeSlot = async () => {
            setTimeSlots(await GetTimeSlot());
        }
        fetchTimeSlot();
    }, []);
    console.log(TimeSlots);
    return (
        <Box pt={{ base: '130px', md: '80px', xl: '80px' }}>
            <TimeSlotColumnTable />
        </Box>
      );
}