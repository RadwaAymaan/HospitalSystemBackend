'use client';

import { Flex, Box, Text, useColorModeValue } from '@chakra-ui/react';
import * as React from 'react';

import Card from 'components/card/Card';
import Menu from 'components/menu/MainMenu';
import { useEffect, useState, useCallback } from 'react';
import Link from 'next/link';
import { useRouter } from 'next/navigation';

import CompactTable from 'components/common/compact-table/CompactTable';
import {
  DeleteEmployee,
  GetByIdEmployee,
  GetEmployee,
  UpdateEmployee,
} from 'api/employee';

export default function EmployeeColumnTable() {
  const [employees, setEmployees] = useState<{
    headers: Array<{ title: string; field: string }>;
    data?: Array<any>;
  }>();
  const textColor = useColorModeValue('secondaryGray.900', 'white');
  const router = useRouter();
  const [selectedId, setSelectedId] = useState<string | number>(null);


  const loadData = useCallback(() => {
    GetEmployee().then((data: any) => {
      if (data) {
        setEmployees((prev) => ({
          headers: [
            { title: 'ID', field: 'id' },
            { title: 'Email', field: 'employeeEmail' },
            { title: 'First Name', field: 'employeeFirstName' },
            { title: 'Last Name', field: 'employeeLastName' },
            { title: 'Phone Number', field: 'employeePhoneNumber' },
          ],
          data: data,
        }));
      } else {
        console.log('data not found');
      }
    });
  }, []);

  useEffect(() => {
    loadData();
  }, [loadData]);

  const handleDelete = async (id: string) => {
    await DeleteEmployee(id);
    loadData();
    router.push("/admin/employee");
  };
  const viewEmployeeDetails = async (id: string) => {
    router.push(`/admin/employee/${id}`);
  };

  const handleOnEdit = async (id: string) => {
    await GetByIdEmployee(id)
    router.push(`/admin/employee/update/${id}`);
  };
  return (
    <Card
      flexDirection="column"
      w="100%"
      px="0px"
      overflowX={{ sm: 'scroll', lg: 'hidden' }}
    >
      <Flex px="25px" mb="8px" justifyContent="space-between" align="center">
        <Text
          color={textColor}
          fontSize="22px"
          mb="4px"
          fontWeight="700"
          lineHeight="100%"
        >
          Employees
        </Text>
        <Menu />
      </Flex>
      <Box>
        <Link href="employee/add">
          <div style={{ textAlign: 'end', margin: '1px 20px' }}>
            <button
              type="button"
              style={{
                backgroundColor: 'blue' /* Green background */,
                border: 'none',
                color: 'white',
                padding: '10px 20px' /* Some padding */,
                textAlign: 'center',
                textDecoration: 'none',
                display: 'inline-block',
                fontSize: '16px',
                margin: '4px 2px',
                cursor: 'pointer',
                borderRadius: '5px' /* Rounded corners */,
              }}
            >
              Add new Employee{' '}
              <span style={{ fontSize: '20px', fontWeight: 'bold' }}>+</span>
            </button>
          </div>
        </Link>

        {employees && (
          <CompactTable
            headers={employees.headers}
            data={employees.data}
            onDelete={handleDelete}
            onClick={viewEmployeeDetails}
            onUpdate={handleOnEdit}
          />
        )}
      </Box>
    </Card>
  );
}
