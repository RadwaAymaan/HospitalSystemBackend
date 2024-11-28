'use client';
import { Box } from '@chakra-ui/react';
import React from 'react';
import PharmacistColumnTable from './components/ColumnsTable';
export default function Pharmacist() {
  return (
    <Box pt={{ base: '130px', md: '80px', xl: '80px' }}>
            <PharmacistColumnTable /> 
    </Box>
  );
}
