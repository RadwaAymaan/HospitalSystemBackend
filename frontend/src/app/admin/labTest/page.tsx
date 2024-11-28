'use client';

import { Box } from "@chakra-ui/react";
import { getLabTests } from "api/labTest";
import { ILabTest } from "interfaces/ILabTest";
import { useEffect, useState } from "react";
import LabTestColumnTable from "./_component/LabTestColumnsTable";



export default function ListLabTest() {

    const [labTests, setLabTests] = useState<ILabTest[]>([]);

    useEffect(() => {
        const fetchLabTest = async () => {
            setLabTests(await getLabTests());
        }
        fetchLabTest();
    }, []);
    console.log(labTests);
    return (
        <Box pt={{ base: '130px', md: '80px', xl: '80px' }}>
            <LabTestColumnTable />
        </Box>
      );
}