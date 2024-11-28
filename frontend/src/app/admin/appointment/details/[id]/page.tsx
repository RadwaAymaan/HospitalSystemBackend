"use client";

import { Box, Button, Flex, FormControl, FormLabel, Heading, Input, useColorModeValue } from "@chakra-ui/react";
import { GetAppointmentById } from "api/appointment";
import { IAppointment } from "interfaces/IAppointment";
import Link from "next/link";
import React from "react";
import { useEffect, useState } from "react";

export default function appointmentDetails({params}: {params: {id: string}}) {
    const [formData, setFormData] = useState<IAppointment>({});
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
        const fetchappointment = async () => {
            setFormData(await GetAppointmentById (params.id))
        }
        fetchappointment();
    }, []);

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
            Appointment Details
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
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              color={textColor}
              display="flex"
            >
              START TIME
            </FormLabel>
              <Input
                isRequired={true}
                fontSize="sm"
                type="string"
                name="startTime"
                mb="24px"
                size="lg"
                variant="auth"
                value={formData.startTime}
                placeholder="Start Time"
                disabled
              />
            <FormLabel
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              display="flex"
            >
                END TIME
            </FormLabel>
              <Input
                isRequired={true}
                fontSize="sm"
                type="text"
                name="endtime"
                mb="24px"
                size="lg"
                variant="auth"
                value={formData.endTime }
                placeholder="End Time"
                disabled
              />
            <FormLabel
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              display="flex"
            >
              DATE
            </FormLabel>
              <Input
                isRequired={true}
                fontSize="sm"
                type="text"
                name="date"
                mb="24px"
                size="lg"
                variant="auth"
                value={formData.date }
                placeholder="Date"
                disabled
              />
             <FormLabel
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              display="flex"
            >
              DOCTOR NAME
            </FormLabel>
              <Input
                isRequired={true}
                fontSize="sm"
                type="text"
                name="doctorName"
                mb="24px"
                size="lg"
                variant="auth"
                value={formData.doctorName }
                placeholder="Doctor Name"
                disabled
              /> 
              <FormLabel
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              display="flex"
            >
               PATIENT NAME
            </FormLabel>
              <Input
                isRequired={true}
                fontSize="sm"
                type="text"
                name="patientName"
                mb="24px"
                size="lg"
                variant="auth"
                value={formData.patientName }
                placeholder="Patient Name"
                disabled
              />
             
              <Link href="/admin/appointment">
            <Button
              fontSize="sm"
              variant="brand"
              fontWeight="500"
              w="100%"
              h="50"
              mb="24px"
            >
              Back to Appointments
            </Button>
            </Link>
          </FormControl>
        </Flex>
      </Flex>  
    )
}