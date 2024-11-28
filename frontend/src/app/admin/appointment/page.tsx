'use client';

import { Box } from "@chakra-ui/react";
import { GetAppointment } from "api/appointment";
import { IAppointment } from "interfaces/IAppointment";
import { useEffect, useState } from "react";
import AppointmentColumnTable from "./_component/appointmentColumnsTable";

export default function ListAppointments() 
{
    const [Appointments, setAppointments] = useState<IAppointment[]>([]);

    useEffect(() => {
        const fetchAppointment = async () => {
            setAppointments(await GetAppointment());
        }
        fetchAppointment();
    }, []);
    console.log(Appointments);
    return (
        <Box pt={{ base: '130px', md: '80px', xl: '80px' }}>
            <AppointmentColumnTable />
        </Box>
      );
}