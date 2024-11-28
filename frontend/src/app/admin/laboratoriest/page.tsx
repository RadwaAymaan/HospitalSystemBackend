'use client';

import { Box } from "@chakra-ui/react";
import { GetEmployee } from "api/employee";
import InventoryColumnTable from "./components/LaboratoriestColumnTable";
import { getInventory } from "api/inventory";
import LaboratoriestColumnTable from "./components/LaboratoriestColumnTable";
import { getLaboratoriest } from "api/laboratoriest";


const fetchInventory = async () => {
  return await getLaboratoriest();
}

export default function ListInventory() {  
    
    return (
        <Box pt={{ base: '130px', md: '80px', xl: '80px' }}>
         <LaboratoriestColumnTable />
        </Box>
      );
}