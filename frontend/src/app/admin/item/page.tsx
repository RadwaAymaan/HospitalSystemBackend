'use client';

import { Box } from "@chakra-ui/react";
import ItemColumnTable from "./_component/ItemColumnsTable";


export default function ListItems() {
    return (
        <Box pt={{ base: '130px', md: '80px', xl: '80px' }}>
            <ItemColumnTable />
        </Box>
      );
}