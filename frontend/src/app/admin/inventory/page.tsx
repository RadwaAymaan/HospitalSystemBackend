'use client';

import { Box } from "@chakra-ui/react";
import { GetEmployee } from "api/employee";
import InventoryColumnTable from "./components/InventoryColumnTable";
import { getInventory } from "api/inventory";

const fetchInventory = async () => {
  return await getInventory();
}

export default function ListInventory() {  
    
    return (
        <Box pt={{ base: '130px', md: '80px', xl: '80px' }}>
         <InventoryColumnTable />
        </Box>
      );
}