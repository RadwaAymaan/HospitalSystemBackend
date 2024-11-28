'use client';
import { Box, SimpleGrid } from '@chakra-ui/react';
import ColumnTable from './components/ColumnsTable';
import React, { useState, useEffect } from 'react';
import { BrowserRouter as Router } from 'react-router-dom';
export default function Doctor() {
//   const [apiData, setApiData] = useState(null);

//   useEffect(() => {
//       const fetchData = async () => {
//           try {
//               const response = await fetch('http://localhost:5024/api/Doctor', {
//                   method: 'GET',
//                   headers: {
//                       'Content-Type': 'application/json',
//                       'Authorization': 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImVlMzZhODYxLTFmMGQtNGI3ZS04Nzk0LWNhMDgwMjViMDM1OSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJBZG1pbkZpcnN0TmFtZSBBZG1pbkxhc3ROYW1lIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZW1haWxhZGRyZXNzIjoiYWRtaW4xMjNAZ21haWwuY29tIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiQWRtaW4iLCJleHAiOjE3MTEzNjk3ODAsImlzcyI6IlRPVFBsYXRmb3JtIiwiYXVkIjoiUGxhdGZvcm1Vc2VycyJ9.qoRzZ-jGjXdcbIgwWhFZSLB_m7KeU9-BHJJSDT1HgjM'
//                   }
//               });
//               if (!response.ok) {
//                   throw new Error('Failed to fetch data');
//               }
//               const data = await response.json();
//               setApiData(data.value);
//               console.log(data.value);
              
//           } catch (error) {
//               console.error('Error fetching data:', error);
//           }
//       };

//       fetchData();
//   }, []);
  return (
    <Box pt={{ base: '130px', md: '80px', xl: '80px' }}>
            <ColumnTable /> 
    </Box>
  );
}
