"use client";

import { Flex, Box, Table, Tbody, Td, Text, Th, Thead, Tr, useColorModeValue } from '@chakra-ui/react';
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
import { useEffect, useState } from 'react';
import Link from 'next/link';
import { IPatientList } from 'interfaces/IPatient';
import { deletePatient, getPatient } from 'api/patient';
 
const columnHelper = createColumnHelper<IPatientList>();

// const columns = columnsDataCheck;
export default function PatientColumnTable() {
	const [tableData, setTableData] = useState<IPatientList[]>([]);
	const [ sorting, setSorting ] = useState<SortingState>([]);
	const textColor = useColorModeValue('secondaryGray.900', 'white');
	const borderColor = useColorModeValue('gray.200', 'whiteAlpha.100');
	
    const fetchPatients = async () => {
        setTableData(await getPatient());
    }

    useEffect(() => {
        fetchPatients();
    }, []);

    const handleDelete = async (id: string) => {
        await deletePatient(id);
        fetchPatients();
    }

	const columns = [
			columnHelper.accessor('id', {
				id: 'id',
				header: () => (
					<Text
						justifyContent='space-between'
						align='center'
						fontSize={{ sm: '10px', lg: '12px' }}
						color='gray.400'>
						Id
					</Text>
				),
				cell: (info) => (
					<Text color={textColor} fontSize='sm' fontWeight='700'>
						{info.getValue()}
					</Text>
				)
			}),
		columnHelper.accessor('patientEmail', {
			id: 'patientEmail',
			header: () => (
				<Text
					justifyContent='space-between'
					align='center'
					fontSize={{ sm: '10px', lg: '12px' }}
					color='gray.400'>
					Email
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
		columnHelper.accessor('patientFirstName', {
			id: 'patientFirstName',
			header: () => (
				<Text
					justifyContent='space-between'
					align='center'
					fontSize={{ sm: '10px', lg: '12px' }}
					color='gray.400'>
					First Name
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
		columnHelper.accessor('patientLastName', {
			id: 'patientLastName',
			header: () => (
				<Text
					justifyContent='space-between'
					align='center'
					fontSize={{ sm: '10px', lg: '12px' }}
					color='gray.400'>
					Last Name
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
		columnHelper.accessor('patientPhoneNumber', {
			id: 'patientPhoneNumber',
			header: () => (
				<Text
					justifyContent='space-between'
					align='center'
					fontSize={{ sm: '10px', lg: '12px' }}
					color='gray.400'>
					Phone Number
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
						<Link href={`/admin/patient/${info.getValue()}`}>
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
					Update
				</Text>
			),
			cell: (info) => (
				<Text color={textColor} fontSize='sm' fontWeight='700'>
						<Link href={`/admin/patient/update/${info.getValue()}`}>
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
		}),

		columnHelper.accessor('id', {
			id: 'id',
			header: () => (
				<Text
					justifyContent='space-between'
					align='center'
					fontSize={{ sm: '10px', lg: '12px' }}
					color='gray.400'>
					Prescription
				</Text>
			),
			cell: (info) => (
				<Text color={textColor} fontSize='sm' fontWeight='700'>
						<Link href={`/admin/prescription/add/${info.getValue()}`}>
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
                                Add Prescription
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
					Patients
				</Text>
				<Menu />
			</Flex>
			<Box>
                <Link href="patient/add">
				<div style={{ textAlign: 'end', margin: '1px 20px' }}>
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
                                Add new Patient <span style={{fontSize: '20px', fontWeight: "bold"}}>+</span>
                            </button>
							</div>
							</Link>
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