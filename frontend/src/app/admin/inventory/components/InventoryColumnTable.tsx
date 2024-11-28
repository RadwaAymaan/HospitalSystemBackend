'use client';

import { Flex, Box, Text, useColorModeValue } from '@chakra-ui/react';
import * as React from 'react';

import Card from 'components/card/Card';
import Menu from 'components/menu/MainMenu';
import { useEffect, useState, useCallback } from 'react';
import Link from 'next/link';
import { useRouter } from 'next/navigation';

import CompactTable from 'components/common/compact-table/CompactTable';
import { deleteInventory, getByIdInventory, getInventory } from 'api/inventory';


export default function InventoryColumnTable() {
  const [Inventorys, setInventorys] = useState<{
    headers: Array<{ title: string; field: string }>;
    data?: Array<any>;
  }>();
  const textColor = useColorModeValue('secondaryGray.900', 'white');
  const router = useRouter();
  const [selectedId, setSelectedId] = useState<string | number>(null);


  const loadData = useCallback(() => {
    getInventory().then((data: any) => {
      if (data) {
        setInventorys((prev) => ({
          headers: [
            { title: 'ID', field: 'id' },
            { title: 'Inventory Name', field: 'inventoryName' },
            { title: 'Inventory Location', field: 'inventoryLocation' },
            { title: 'Inventory Capacity', field: 'inventoryCapacity' },
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
    await deleteInventory(id);
    loadData();
    router.push("/admin/inventory");
  };
  const viewInventoryDetails = async (id: string) => {
    router.push(`/admin/inventory/${id}`);
  };

  const handleOnEdit = async (id: string) => {
    await getByIdInventory(id)
    router.push(`/admin/inventory/update/${id}`);
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
          Inventorys
        </Text>
        <Menu />
      </Flex>
      <Box>
        <Link href="inventory/add">
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
              Add new Inventory{' '}
              <span style={{ fontSize: '20px', fontWeight: 'bold' }}>+</span>
            </button>
          </div>
        </Link>

        {Inventorys && (
          <CompactTable
            headers={Inventorys.headers}
            data={Inventorys.data}
            onDelete={handleDelete}
            onClick={viewInventoryDetails}
            onUpdate={handleOnEdit}
          />
        )}
      </Box>
    </Card>
  );
}
