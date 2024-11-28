'use client';

import { Flex, Box, Text, useColorModeValue } from '@chakra-ui/react';
import * as React from 'react';

import Card from 'components/card/Card';
import Menu from 'components/menu/MainMenu';
import { useEffect, useState, useCallback } from 'react';
import Link from 'next/link';
import { useRouter } from 'next/navigation';

import CompactTable from 'components/common/compact-table/CompactTable';
import { deleteMedicine, getByIdMedicine, getMedicine } from 'api/medicine';




export default function MedicineColumnTable() {
  const [Medicines, setMedicines] = useState<{
    headers: Array<{ title: string; field: string }>;
    data?: Array<any>;
  }>();
  const textColor = useColorModeValue('secondaryGray.900', 'white');
  const router = useRouter();



  const loadData = useCallback(() => {
    getMedicine().then((data: any) => {
      if (data) {
        setMedicines((prev) => ({
          headers: [
            { title: 'ID', field: 'id' },
            { title: 'Medcine Name', field: 'medicineName' },
            { title: 'Medicine Description', field: 'medicineDescription' },
            { title: 'Medicine Dosage', field: 'medicineDosage' },
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
    await deleteMedicine(id);
    loadData();
    router.push("/admin/medicine");
  };
  const viewMedicineDetails = async (id: string) => {
    router.push(`/admin/medicine/${id}`);
  };

  const handleOnEdit = async (id: string) => {
    await getByIdMedicine(id)
    router.push(`/admin/medicine/update/${id}`);
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
          Medicines
        </Text>
        <Menu />
      </Flex>
      <Box>
        <Link href="medicine/add">
          <div style={{ textAlign: 'end', margin: '1px 20px' }}>
            <button
              type="button"
              style={{
                backgroundColor: 'blue',
                border: 'none',
                color: 'white',
                padding: '10px 20px',
                textAlign: 'center',
                textDecoration: 'none',
                display: 'inline-block',
                fontSize: '16px',
                margin: '4px 2px',
                cursor: 'pointer',
                borderRadius: '5px',
              }}
            >
              Add new Medicine{' '}
              <span style={{ fontSize: '20px', fontWeight: 'bold' }}>+</span>
            </button>
          </div>
        </Link>

        {Medicines && (
          <CompactTable
            headers={Medicines.headers}
            data={Medicines.data}
            onDelete={handleDelete}
            onClick={viewMedicineDetails}
            onUpdate={handleOnEdit}
          />
        )}
      </Box>
    </Card>
  );
}
