'use client';

import { Box } from "@chakra-ui/react";
import { getMedicalTestOrders } from "api/medicalTestOrder";
import { IMedicalTestOrder } from "interfaces/IMedicalTestOrder";
import { useEffect, useState } from "react";
import MedicalTestOrderColumnsTable from "./_component/MedicalTestOrderColumnsTable";



export default function ListMedicalTestOrder() {

    const [medicalTestOrders, setMedicalTestOrders] = useState<IMedicalTestOrder[]>([]);

    useEffect(() => {
        const fetchMedicalTestOrder = async () => {
            setMedicalTestOrders(await getMedicalTestOrders());
        }
        fetchMedicalTestOrder();
    }, []);
    console.log(medicalTestOrders);
    return (
        <Box pt={{ base: '130px', md: '80px', xl: '80px' }}>
            <MedicalTestOrderColumnsTable />
        </Box>
      );
}