'use client';

import { Box } from "@chakra-ui/react";
import { GetEmployee } from "api/employee";
import InventoryColumnTable from "./components/NurseColumnTable";
import { getInventory } from "api/inventory";
import NurseColumnTable from "./components/NurseColumnTable";
import { getNurse } from "api/nurse";

const fetchInventory = async () => {
  return await getNurse();
}

export default function ListInventory() {  
    
    return (
        <Box pt={{ base: '130px', md: '80px', xl: '80px' }}>
         <NurseColumnTable />
        </Box>
      );
}