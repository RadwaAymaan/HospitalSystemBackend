'use client';
import { Box, SimpleGrid } from '@chakra-ui/react';
import ColumnTable from './components/ColumnsTable';
import React, { useState, useEffect } from 'react';
import MedicalTestResultColumnTable from './components/ColumnsTable';
export default function Doctor() {
  return (
    <Box pt={{ base: '130px', md: '80px', xl: '80px' }}>
            <MedicalTestResultColumnTable /> 
    </Box>
  );
}
