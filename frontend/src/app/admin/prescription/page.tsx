"use client";

import { Box } from "@chakra-ui/react";
import PrescriptionColumnTable from "./_components/PrescriptionColumnsTable";
import { IPrescription } from "interfaces/IPrescription";
import { useEffect, useState } from "react";
import { getPrescriptions } from "api/prescription";

export default function ListPrescriptions() {

    const [prescriptions, setPrescriptions] = useState<IPrescription[]>();

	useEffect(() => {
        const fetchPrescriptions = async () => {
            setPrescriptions(await getPrescriptions());
        }
		fetchPrescriptions();
	}, []);
    return (
        <Box pt={{ base: '130px', md: '80px', xl: '80px' }}>
            <PrescriptionColumnTable prescriptions={prescriptions && prescriptions.length > 0 ? prescriptions : ""} />
        </Box>
      );
}