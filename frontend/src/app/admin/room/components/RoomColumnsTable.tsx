'use client';

import { Flex, Box, Text, useColorModeValue } from '@chakra-ui/react';
import * as React from 'react';

import Card from 'components/card/Card';
import Menu from 'components/menu/MainMenu';
import { useEffect, useState, useCallback } from 'react';
import Link from 'next/link';
import { useRouter } from 'next/navigation';

import CompactTable from 'components/common/compact-table/CompactTable';
import { DeleteRoom, GetByIdRoom, GetRoom } from 'api/room';


export default function RoomColumnTable() {
  const [Rooms, setRooms] = useState<{
    headers: Array<{ title: string; field: string }>;
    data?: Array<any>;
  }>();
  const textColor = useColorModeValue('secondaryGray.900', 'white');
  const router = useRouter();


  const loadData = useCallback(() => {
    GetRoom().then((data: any) => {
      if (data) {
        setRooms((prev) => ({
          headers: [
            { title: 'ID', field: 'id' },
            { title: 'Room Number', field: 'roomNumber' },
            { title: 'Room Type', field: 'roomType.type' },,
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
    await DeleteRoom(id);
    loadData();
    router.push("/admin/room");
  };
  const viewRoomDetails = async (id: string) => {
    router.push(`/admin/room/${id}`);
  };

  const handleOnEdit = async (id: string) => {
    await GetByIdRoom(id)
    router.push(`/admin/room/update/${id}`);
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
          Rooms
        </Text>
        <Menu />
      </Flex>
      <Box>
        <Link href="room/add">
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
              Add new Room{' '}
              <span style={{ fontSize: '20px', fontWeight: 'bold' }}>+</span>
            </button>
          </div>
        </Link>

        {Rooms && (
          <CompactTable
            headers={Rooms.headers}
            data={Rooms.data}
            onDelete={handleDelete}
            onClick={viewRoomDetails}
            onUpdate={handleOnEdit}
          />
        )}
      </Box>
    </Card>
  );
}
