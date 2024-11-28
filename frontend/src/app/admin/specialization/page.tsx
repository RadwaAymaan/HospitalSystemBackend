'use client';
import { Box, SimpleGrid } from '@chakra-ui/react';
import React, { useState, useEffect } from 'react';
import SpecializationColumnTable from './components/ColumnsTable';
export default function Pharmacist() {
  return (
    <Box pt={{ base: '130px', md: '80px', xl: '80px' }}>
            < SpecializationColumnTable/> 
    </Box>
  );
}
