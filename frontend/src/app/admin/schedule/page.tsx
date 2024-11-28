'use client';

import { Box } from "@chakra-ui/react";
import { getSchedule } from "api/schedule";
import { ISchedule } from "interfaces/ISchedule";
import { useEffect, useState } from "react";
import ScheduleColumnTable from "./_component/scheduleColumnsTable";



export default function ListSchedules() 
{
    const [schedules, setSchedules] = useState<ISchedule[]>([]);

    useEffect(() => {
        const fetchSchedule = async () => {
            setSchedules(await getSchedule());
        }
        fetchSchedule();
    }, []);
    console.log(schedules);
    return (
        <Box pt={{ base: '130px', md: '80px', xl: '80px' }}>
            <ScheduleColumnTable />
        </Box>
      );
}