'use client';

import { Flex, Box, Text, useColorModeValue } from '@chakra-ui/react';
import * as React from 'react';

import Card from 'components/card/Card';
import Menu from 'components/menu/MainMenu';
import { useEffect, useState, useCallback } from 'react';
import Link from 'next/link';
import { useRouter } from 'next/navigation';

import CompactTable from 'components/common/compact-table/CompactTable';
import { deleteLaboratoriest, getByIdLaboratoriest, getLaboratoriest } from 'api/Laboratoriest';



export default function LaboratoriestColumnTable() {
  const [Laboratoriests, setLaboratoriests] = useState<{
    headers: Array<{ title: string; field: string }>;
    data?: Array<any>;
  }>();
  const textColor = useColorModeValue('secondaryGray.900', 'white');
  const router = useRouter();



  const loadData = useCallback(() => {
    getLaboratoriest().then((data: any) => {
      if (data) {
        setLaboratoriests((prev) => ({
          headers: [
            { title: 'ID', field: 'id' },
            { title: 'Email', field: 'laboratoriestEmail' },
            { title: 'First Name', field: 'laboratoriestFirstName' },
            { title: 'Last Name', field: 'laboratoriestLastName' },
            { title: 'Phone Number', field: 'laboratoriestPhoneNumber' },
            { title: 'User Name', field: 'userName' },
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
    await deleteLaboratoriest(id);
    loadData();
    router.push("/admin/laboratoriest");
  };
  const viewLaboratoriestDetails = async (id: string) => {
    router.push(`/admin/laboratoriest/${id}`);
  };

  const handleOnEdit = async (id: string) => {
    await getByIdLaboratoriest(id)
    router.push(`/admin/laboratoriest/update/${id}`);
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
          Laboratoriests
        </Text>
        <Menu />
      </Flex>
      <Box>
        <Link href="laboratoriest/add">
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
              Add new Laboratoriest{' '}
              <span style={{ fontSize: '20px', fontWeight: 'bold' }}>+</span>
            </button>
          </div>
        </Link>

        {Laboratoriests && (
          <CompactTable
            headers={Laboratoriests.headers}
            data={Laboratoriests.data}
            onDelete={handleDelete}
            onClick={viewLaboratoriestDetails}
            onUpdate={handleOnEdit}
          />
        )}
      </Box>
    </Card>
  );
}
