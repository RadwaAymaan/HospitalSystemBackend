'use client';

import { Flex, Box, Text, useColorModeValue } from '@chakra-ui/react';
import * as React from 'react';

import Card from 'components/card/Card';
import Menu from 'components/menu/MainMenu';
import { useEffect, useState, useCallback } from 'react';
import Link from 'next/link';
import { useRouter } from 'next/navigation';

import CompactTable from 'components/common/compact-table/CompactTable';
import { deleteNurse, getByIdNurse, getNurse } from 'api/nurse';



export default function NurseColumnTable() {
  const [Nurses, setNurses] = useState<{
    headers: Array<{ title: string; field: string }>;
    data?: Array<any>;
  }>();
  const textColor = useColorModeValue('secondaryGray.900', 'white');
  const router = useRouter();



  const loadData = useCallback(() => {
    getNurse().then((data: any) => {
      if (data) {
        setNurses((prev) => ({
          headers: [
            { title: 'ID', field: 'id' },
            { title: 'Email', field: 'nurseEmail' },
            { title: 'First Name', field: 'nurseFirstName' },
            { title: 'Last Name', field: 'nurseLastName' },
            { title: 'Phone Number', field: 'nursePhoneNumber' },
            { title: 'Specialization Name', field: 'specializationName' },
          ],
          data: data,
        }));
      } 
    });
  }, []);

  useEffect(() => {
    loadData();
  }, [loadData]);

  const handleDelete = async (id: string) => {
    await deleteNurse(id);
    loadData();
    router.push("/admin/nurse");
  };
  const viewNurseDetails = async (id: string) => {
    router.push(`/admin/nurse/${id}`);
  };

  const handleOnEdit = async (id: string) => {
    await getByIdNurse(id)
    router.push(`/admin/nurse/update/${id}`);
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
          Nurses
        </Text>
        <Menu />
      </Flex>
      <Box>
        <Link href="nurse/add">
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
              Add new Nurse{' '}
              <span style={{ fontSize: '20px', fontWeight: 'bold' }}>+</span>
            </button>
          </div>
        </Link>

        {Nurses && (
          <CompactTable
            headers={Nurses.headers}
            data={Nurses.data}
            onDelete={handleDelete}
            onClick={viewNurseDetails}
            onUpdate={handleOnEdit}
          />
        )}
      </Box>
    </Card>
  );
}
