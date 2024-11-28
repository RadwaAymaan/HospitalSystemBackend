'use client';

import { Box } from "@chakra-ui/react";
import { getScanTests } from "api/scanTest";
import { IScanTest } from "interfaces/IScanTest";
import { useEffect, useState } from "react";
import ScanTestColumnTable from "./_component/ScanTestColumnsTable";



export default function ListScanTest() {

    const [scanTests, setScanTests] = useState<IScanTest[]>([]);

    useEffect(() => {
        const fetchScanTest = async () => {
            setScanTests(await getScanTests());
        }
        fetchScanTest();
    }, []);
    console.log(scanTests);
    return (
        <Box pt={{ base: '130px', md: '80px', xl: '80px' }}>
            <ScanTestColumnTable />
        </Box>
      );
}