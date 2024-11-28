import { Flex, Box, Table, Checkbox, Tbody, Td, Text, Th, Thead, Tr, useColorModeValue } from '@chakra-ui/react';
import * as React from 'react';

import {
	createColumnHelper,
	flexRender,
	getCoreRowModel,
	getSortedRowModel,
	SortingState,
	useReactTable
} from '@tanstack/react-table';

// Custom components
import Card from 'components/card/Card';
import Menu from 'components/menu/MainMenu';
import { useState } from 'react';
import { IItem } from 'interfaces/IItem';
import { DeleteItem, getItems } from 'api/item';
import Link from 'next/link';
 
const columnHelper = createColumnHelper<IItem>();

// const columns = columnsDataCheck;
export default function ItemColumnTable() {
	const [tableData, setTableData] = React.useState<IItem[]>([]);
	const [ sorting, setSorting ] = React.useState<SortingState>([]);
	const textColor = useColorModeValue('secondaryGray.900', 'white');
	const borderColor = useColorModeValue('gray.200', 'whiteAlpha.100');
	
    const fetchItems = async () => {
        setTableData(await getItems());
    }

    React.useEffect(() => {
        fetchItems();
    }, []);

    const handleDelete = async (id: number) => {
        await DeleteItem(id);
        fetchItems();
    }

	const columns = [
		columnHelper.accessor('name', {
			id: 'name',
			header: () => (
				<Text
					justifyContent='space-between'
					align='center'
					fontSize={{ sm: '10px', lg: '12px' }}
					color='gray.400'>
					NAME
				</Text>
			),
			cell: (info: any) => (
				<Flex align='center'> 
					<Text color={textColor} fontSize='sm' fontWeight='700'>
						{info.getValue()}
					</Text>
				</Flex>
			)
		}),
		columnHelper.accessor('description', {
			id: 'description',
			header: () => (
				<Text
					justifyContent='space-between'
					align='center'
					fontSize={{ sm: '10px', lg: '12px' }}
					color='gray.400'>
					DESCRIPTION
				</Text>
			),
			cell: (info) => (
				<Text color={textColor} fontSize='sm' fontWeight='700'>
					{info.getValue()}
				</Text>
			)
		}),
		columnHelper.accessor('stock', {
			id: 'stock',
			header: () => (
				<Text
					justifyContent='space-between'
					align='center'
					fontSize={{ sm: '10px', lg: '12px' }}
					color='gray.400'>
					STOCK
				</Text>
			),
			cell: (info) => (
				<Text color={textColor} fontSize='sm' fontWeight='700'>
					{info.getValue()}
				</Text>
			)
		}),
		columnHelper.accessor('price', {
			id: 'price',
			header: () => (
				<Text
					justifyContent='space-between'
					align='center'
					fontSize={{ sm: '10px', lg: '12px' }}
					color='gray.400'>
					PRICE
				</Text>
			),
			cell: (info) => (
				<Text color={textColor} fontSize='sm' fontWeight='700'>
					{info.getValue()}
				</Text>
			)
		}),
		columnHelper.accessor('category.categoryName', {
			id: 'categoryName',
			header: () => (
				<Text
					justifyContent='space-between'
					align='center'
					fontSize={{ sm: '10px', lg: '12px' }}
					color='gray.400'>
					CATEGORY NAME
				</Text>
			),
			cell: (info) => (
				<Text color={textColor} fontSize='sm' fontWeight='700'>
					{info.getValue()}
				</Text>
			)
		}),
		columnHelper.accessor('category.referenceNumber', {
			id: 'categoryRefrenceNumber',
			header: () => (
				<Text
					justifyContent='space-between'
					align='center'
					fontSize={{ sm: '10px', lg: '12px' }}
					color='gray.400'>
					REFERENCE NUMBER
				</Text>
			),
			cell: (info) => (
				<Text color={textColor} fontSize='sm' fontWeight='700'>
					{info.getValue()}
				</Text>
			)
		}),
		columnHelper.accessor('id', {
			id: 'id',
			header: () => (
				<Text
					justifyContent='space-between'
					align='center'
					fontSize={{ sm: '10px', lg: '12px' }}
					color='gray.400'>
					Details
				</Text>
			),
			cell: (info) => (
				<Text color={textColor} fontSize='sm' fontWeight='700'>
						<Link href={`/admin/item/details/${info.getValue()}`}>
						    <button type="button" style={{
									backgroundColor: '#4CAF50', /* Green background */
									border: 'none', 
									color: 'white',
									padding: '10px 20px', /* Some padding */
									textAlign: 'center',
									textDecoration: 'none',
									display: 'inline-block',
									fontSize: '16px',
									margin: '4px 2px',
									cursor: 'pointer',
									borderRadius: '5px' /* Rounded corners */
								}}>
                                Details
                            </button>
                        </Link>
				</Text>
			)
		}),
		columnHelper.accessor('id', {
			id: 'id',
			header: () => (
				<Text
					justifyContent='space-between'
					align='center'
					fontSize={{ sm: '10px', lg: '12px' }}
					color='gray.400'>
					Details
				</Text>
			),
			cell: (info) => (
				<Text color={textColor} fontSize='sm' fontWeight='700'>
						<Link href={`/admin/order/item/${info.getValue()}`}>
						    <button type="button" style={{
									backgroundColor: 'green', /* Green background */
									border: 'none', 
									color: 'white',
									padding: '10px 20px', /* Some padding */
									textAlign: 'center',
									textDecoration: 'none',
									display: 'inline-block',
									fontSize: '16px',
									margin: '4px 2px',
									cursor: 'pointer',
									borderRadius: '5px' /* Rounded corners */
								}}>
                                Order
                            </button>
                        </Link>
				</Text>
			)
		}),
		columnHelper.accessor('id', {
			id: 'id',
			header: () => (
				<Text
					justifyContent='space-between'
					align='center'
					fontSize={{ sm: '10px', lg: '12px' }}
					color='gray.400'>
					Update
				</Text>
			),
			cell: (info) => (
				<Text color={textColor} fontSize='sm' fontWeight='700'>
						<Link href={`/admin/item/update/${info.getValue()}`}>
						    <button type="button" style={{
									backgroundColor: 'orange', /* Green background */
									border: 'none', 
									color: 'white',
									padding: '10px 20px', /* Some padding */
									textAlign: 'center',
									textDecoration: 'none',
									display: 'inline-block',
									fontSize: '16px',
									margin: '4px 2px',
									cursor: 'pointer',
									borderRadius: '5px' /* Rounded corners */
								}}>
                                Update
                            </button>
                        </Link>
				</Text>
			)
		}),
		columnHelper.accessor('id', {
			id: 'id',
			header: () => (
				<Text
					justifyContent='space-between'
					align='center'
					fontSize={{ sm: '10px', lg: '12px' }}
					color='gray.400'>
					Delete
				</Text>
			),
			cell: (info) => (
				<Text color={textColor} fontSize='sm' fontWeight='700'>
						<Link onClick={() => handleDelete(info.getValue())} href={''}>
						    <button type="button" style={{
									backgroundColor: 'red', /* Green background */
									border: 'none', 
									color: 'white',
									padding: '10px 20px', /* Some padding */
									textAlign: 'center',
									textDecoration: 'none',
									display: 'inline-block',
									fontSize: '16px',
									margin: '4px 2px',
									cursor: 'pointer',
									borderRadius: '5px' /* Rounded corners */
								}}>
                                Delete
                            </button>
                        </Link>
				</Text>
			)
		})
	];
	const table = useReactTable({
		data: tableData,
		columns,
		state: {
			sorting
		},
		onSortingChange: setSorting,
		getCoreRowModel: getCoreRowModel(),
		getSortedRowModel: getSortedRowModel(),
		debugTable: true
	});
	return (
		<Card flexDirection='column' w='100%' px='0px' overflowX={{ sm: 'scroll', lg: 'hidden' }}>
			<Flex px='25px' mb="8px" justifyContent='space-between' align='center'>
				<Text color={textColor} fontSize='22px' mb="4px" fontWeight='700' lineHeight='100%'>
					Inventory Items
				</Text>
				<Menu />
			</Flex>
			<Box>
                <Link href="item/add">
                    <button type="button" style={{
									backgroundColor: 'blue', /* Green background */
									border: 'none', 
									color: 'white',
									padding: '10px 20px', /* Some padding */
									textAlign: 'center',
									textDecoration: 'none',
									display: 'inline-block',
									fontSize: '16px',
									margin: '4px 2px',
									cursor: 'pointer',
									borderRadius: '5px' /* Rounded corners */
								}}>
                                Add new Item <span style={{fontSize: '20px', fontWeight: "bold"}}>+</span>
                            </button></Link>
				<Table variant='simple' color='gray.500' mb='24px' mt="12px">
					<Thead>
						{table.getHeaderGroups().map((headerGroup) => (
							<Tr  key={headerGroup.id}>
								{headerGroup.headers.map((header) => {
									return (
										<Th
											key={header.id}
											colSpan={header.colSpan}
											pe='10px'
											borderColor={borderColor}
											cursor='pointer'
											onClick={header.column.getToggleSortingHandler()}>
											<Flex
												justifyContent='space-between'
												align='center'
												fontSize={{ sm: '10px', lg: '12px' }}
												color='gray.400'>
												{flexRender(header.column.columnDef.header, header.getContext())}{{
													asc: '',
													desc: '',
												}[header.column.getIsSorted() as string] ?? null}
											</Flex>
										</Th>
									);
								})}
							</Tr>
						))}
					</Thead>
					<Tbody>
						{table.getRowModel().rows.slice(0, 11).map((row) => {
							return (
								<Tr key={row.id}>
									{row.getVisibleCells().map((cell) => {
										return (
											<Td
												key={cell.id}
												fontSize={{ sm: '14px' }}
												minW={{ sm: '150px', md: '200px', lg: 'auto' }}
												borderColor='transparent'>
												{flexRender(cell.column.columnDef.cell, cell.getContext())}
											</Td>
										);
									})}
								</Tr>
							);
						})}
					</Tbody>
				</Table>
			</Box>
		</Card>
	);
} 