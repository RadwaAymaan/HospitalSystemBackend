"use client";

import { Box, Button, Flex, FormControl, FormLabel, Heading, Input, Select } from "@chakra-ui/react";
import { useColorModeValue } from "@chakra-ui/system";
import { getDoctors } from "api/doctor";
import { getLabTests } from "api/labTest";
import { getLaboratoriests } from "api/laboratoriest";
import { UpdateMedicalTestOrder, getPatient, getMedicalTestOrderById } from "api/medicalTestOrder";
import { getScanTests } from "api/scanTest";
import { IDoctor } from "interfaces/IDoctor";
import { IInsertMedicalTestOrder } from "interfaces/IInsertMedicalTestOrder";
import { ILabTest } from "interfaces/ILabTest";
import { ILaboratoriest } from "interfaces/ILaboratiest";
import React, { ChangeEvent, useEffect } from "react";
import { useState } from "react";

export default function UpdateMedicalTestOrders({params}: {params: {id: string}}) {
  const [medicalTests, setMedicalTest] = useState<ILabTest[]>([]);
  const [scanTests, setScanTest] = useState<ILabTest[]>([]);
  const [formData, setFormData] = useState<IInsertMedicalTestOrder>({});
  const [doctors, setDoctors] = useState<IDoctor[]>([]);
  const [patients, setPatients] = useState([]);
  const [laboratorists, setLaboratorists] = useState<ILaboratoriest[]>([]);
    const [message, setMessage] = useState<string>("");
    const [show, setShow] = React.useState(false);
    const handleClick = () => setShow(!show);
    const textColor = useColorModeValue('navy.700', 'white');
    const textColorSecondary = 'gray.400';
    const textColorDetails = useColorModeValue('navy.700', 'secondaryGray.600');
    const textColorBrand = useColorModeValue('brand.500', 'white');
    const brandStars = useColorModeValue('brand.500', 'brand.400');
    const googleBg = useColorModeValue('secondaryGray.300', 'whiteAlpha.200');
    const googleText = useColorModeValue('navy.700', 'white');
    const googleHover = useColorModeValue(
      { bg: 'gray.200' },
      { bg: 'whiteAlpha.300' },
    );
    const googleActive = useColorModeValue(
      { bg: 'secondaryGray.300' },
      { bg: 'whiteAlpha.200' },
    );

    useEffect(() => {

      },[]);

    useEffect(() => {
      const fetchLabTest = async () => {
        let medicalTests = await getLabTests();
        setMedicalTest(medicalTests);
        console.log("from page", medicalTests);
      }
      fetchLabTest();

      const fetchScanTest = async () => {
        let scanTests = await getScanTests();
        setScanTest(scanTests);
        console.log("from page", scanTests);
      }
      fetchScanTest();

      const fetchDoctor = async () => {
        let doctors = await getDoctors();
        setDoctors(doctors);
        console.log("from page", doctors);
      }
      fetchDoctor();

      const fetchPatient = async () => {
        let patients = await getPatient();
        setPatients(patients);
        console.log("from page", patients);
      }
      fetchPatient();

      const fetchLaboratorist = async () => {
        let laboratorists = await getLaboratoriests();
        setLaboratorists(laboratorists);
        console.log("from page", laboratorists);
      }
      fetchLaboratorist();

      const fetchMedicalTestOrder = async () => {
        const medicalTestOrder = await getMedicalTestOrderById(params.id)
        let medicalTestOrderToUpdate: IInsertMedicalTestOrder = {
          orderStatus: medicalTestOrder.orderStatus,
          medicalTestId: null,
          patientId: null,
          doctorId: null,
          laboratoristId: null
        };
        setFormData(medicalTestOrderToUpdate);
      }
      fetchMedicalTestOrder();
    }, []);

    const handleChange = (e: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
        const { name, value } = e.target;
        setFormData(prevState => ({
          ...prevState,
          [name]: value
        }));
      };

      const handleSubmit = async () => {
        setMessage(await UpdateMedicalTestOrder(params.id, formData));
    }

    return (
    <Flex
        maxW={{ base: '100%', md: 'max-content' }}
        w="100%"
        mx={{ base: 'auto', lg: '0px' }}
        me="auto"
        h="100%"
        alignItems="start"
        justifyContent="center"
        mb={{ base: '30px', md: '60px' }}
        px={{ base: '25px', md: '0px' }}
        mt={{ base: '40px', md: '14vh' }}
        flexDirection="column"
    >
        <Box me="auto">
          <Heading color={textColor} fontSize="36px" mb="10px">
            Update Medical Test Order
          </Heading>
        </Box>
        <Flex
          zIndex="2"
          direction="column"
          w={{ base: '100%', md: '420px' }}
          maxW="100%"
          background="transparent"
          borderRadius="15px"
          mx={{ base: 'auto', lg: 'unset' }}
          me="auto"
          mb={{ base: '20px', md: 'auto' }}
        >
          <FormControl>
            <FormLabel
              display="flex"
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              color={textColor}
              mb="8px"
            >
              Order Status
            </FormLabel>
            <Select
              isRequired={true}
              variant="auth"
              fontSize="sm"
              ms={{ base: '0px', md: '0px' }}
              type="text"
              name="orderStatus"
              placeholder="Order status"
              mb="24px"
              fontWeight="500"
              size="lg"
              value={formData.orderStatus} 
              onChange={handleChange}
            >
              <option>Pending</option>
              <option>Approved</option>
              <option>Cancelled</option>
            </Select>
          <FormLabel
            ms="4px"
            fontSize="sm"
            fontWeight="500"
            color={textColor}
            display="flex"
          >
            Medical Test
          </FormLabel>
          <Select
            placeholder="Select Medical Test"
            onChange={handleChange}
            name="medicalTestId"
            mb="24px"
            size="lg"
            variant="auth"
          >
            {medicalTests.map(medicalTest => (
              <option key={medicalTest.id} value={medicalTest.id}>{medicalTest.name}</option>
            ))}
            {scanTests.map(medicalTest => (
              <option key={medicalTest.id} value={medicalTest.id}>{medicalTest.name}</option>
            ))}
          </Select>
          <FormLabel
            ms="4px"
            fontSize="sm"
            fontWeight="500"
            color={textColor}
            display="flex"
          >
            Doctor
          </FormLabel>
          <Select
            placeholder="Select Doctor"
            onChange={handleChange}
            name="doctorId"
            mb="24px"
            size="lg"
            variant="auth"
          >
            {doctors.map(doctor => (
              <option key={doctor.id} value={doctor.id}>{doctor.doctorFirstName+" "+doctor.doctorLastName}</option>
            ))}
          </Select>
          <FormLabel
            ms="4px"
            fontSize="sm"
            fontWeight="500"
            color={textColor}
            display="flex"
          >
            Patient
          </FormLabel>
          <Select
            placeholder="Select Patient"
            onChange={handleChange}
            name="patientId"
            mb="24px"
            size="lg"
            variant="auth"
          >
            {patients.map(patient => (
              <option key={patient.id} value={patient.id}>{patient.patientFirstName+" "+patient.patientLastName}</option>
            ))}
          </Select>
          <FormLabel
            ms="4px"
            fontSize="sm"
            fontWeight="500"
            color={textColor}
            display="flex"
          >
            Laboratorist
          </FormLabel>
          <Select
            placeholder="Select Laboratorist"
            onChange={handleChange}
            name="laboratoristId"
            mb="24px"
            size="lg"
            variant="auth"
          >
            {laboratorists.map(laboratorist => (
              <option key={laboratorist.id} value={laboratorist.id}>{laboratorist.laboratoriestFirstName+" "+laboratorist.laboratoriestLastName}</option>
            ))}
            </Select>
            <Button
              fontSize="sm"
              variant="brand"
              fontWeight="500"
              w="100%"
              h="50"
              mb="24px"
              type="submit"
              onClick={handleSubmit}
            >
              Update Medical Test Order
            </Button>
          </FormControl>
        </Flex>
        <h1>{message}</h1>
      </Flex> 
      );
}