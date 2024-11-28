'use client';

import { Box } from "@chakra-ui/react";

import EmployeeColumnTable from "./components/EmployeeColumnTable";
import { GetEmployee } from "api/employee";

const fetchEmployees = async () => {
  return await GetEmployee();
}

export default function ListEmployees() {  
    
    return (
        <Box pt={{ base: '130px', md: '80px', xl: '80px' }}>
         <EmployeeColumnTable />
        </Box>
      );
}