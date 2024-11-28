'use client';

import { Box } from "@chakra-ui/react";
import { GetEmployee } from "api/employee";
import MedicineColumnTable from "./components/MedicineColumnTable";


export default function MedcineList() {  
    
    return (
        <Box pt={{ base: '130px', md: '80px', xl: '80px' }}>
         <MedicineColumnTable />
        </Box>
      );
}