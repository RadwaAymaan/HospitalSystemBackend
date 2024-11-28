'use client';

import { Box } from "@chakra-ui/react";
import PatientColumnTable from "./components/PatientColumnTable";


export default function ListPatients()  {
    
    return <>
        <Box pt={{ base: '130px', md: '80px', xl: '80px' }}>
         <PatientColumnTable/>
        </Box>
        </>
}