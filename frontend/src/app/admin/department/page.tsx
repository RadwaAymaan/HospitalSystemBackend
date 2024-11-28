'use client';

import { Box } from "@chakra-ui/react";
import DepartmentColunmTable from "./components/DepartmentColumnTable";


export default function ListDepartments() {

    return (
        <Box pt={{ base: '130px', md: '80px', xl: '80px' }}>
        <DepartmentColunmTable/>
        </Box>
      );
}