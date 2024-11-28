"use client";

import { Box, Button, Flex, FormControl, FormLabel, Heading, Input, useColorModeValue } from "@chakra-ui/react";
import { getMedicalTestResultById } from "api/MedicalTestResult";
import { IMedicalTestResult } from "interfaces/IMedicalTestResult";
import Link from "next/link";
import React from "react";
import { useEffect, useState } from "react";
export default function MedicalTestResultDetails({params}: {params: {id: number}}) {
    const [formData, setFormData] = useState<IMedicalTestResult>({});
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
        const fetchItem = async () => {
            setFormData(await getMedicalTestResultById(params.id))
        }
        fetchItem();
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
          Medical Test Result Details
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
              Result Description
            </FormLabel>
            <Input
              isRequired={true}
              variant="auth"
              fontSize="sm"
              ms={{ base: '0px', md: '0px' }}
              type="text"
              name="resultDescription"
              placeholder="Result Description"
              mb="24px"
              fontWeight="500"
              size="lg"
              value={formData.resultDescription}
              disabled
            />
            <FormLabel
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              color={textColor}
              display="flex"
            >
              Result Date
            </FormLabel>
              <Input
                isRequired={true}
                fontSize="sm"
                type="textarea"
                name="resultDate"
                mb="24px"
                size="lg"
                variant="auth"
                value={formData.resultDate}
                placeholder="Result Date"
                disabled
              />
            <FormLabel
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              color={textColor}
              display="flex"
            >
              Medical Test Order Id
            </FormLabel>
              <Input
                isRequired={true}
                fontSize="sm"
                type="number"
                name="id"
                mb="24px"
                size="lg"
                variant="auth"
                value={formData.medicalTestOrder?.id}
                placeholder="Medical Test Order Id"
                disabled
              />
            <FormLabel
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              display="flex"
            >
              Medical Test Order Name
            </FormLabel>
              <Input
                isRequired={true}
                fontSize="sm"
                type="textarea"
                name="medicalTestName"
                mb="24px"
                size="lg"
                variant="auth"
                value={formData.medicalTestOrder?.medicalTestName}
                placeholder="Medical Test Order Name"
                disabled
              />
              <FormLabel
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              color={textColor}
              display="flex"
            >
              Medical Test Order Status
            </FormLabel>
              <Input
                isRequired={true}
                fontSize="sm"
                type="textarea"
                name="orderStatus"
                mb="24px"
                size="lg"
                variant="auth"
                value={formData.medicalTestOrder?.orderStatus}
                placeholder="Medical Test Order Status"
                disabled
              />
            <FormLabel
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              color={textColor}
              display="flex"
            >
              Patient Name
            </FormLabel>
              <Input
                isRequired={true}
                fontSize="sm"
                type="textarea"
                name="patientName"
                mb="24px"
                size="lg"
                variant="auth"
                value={formData.medicalTestOrder?.patientName}
                placeholder="Patient Name"
                disabled
              />
            <FormLabel
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              color={textColor}
              display="flex"
            >
              Doctor Name
            </FormLabel>
              <Input
                isRequired={true}
                fontSize="sm"
                type="textarea"
                name="doctorName"
                mb="24px"
                size="lg"
                variant="auth"
                value={formData.medicalTestOrder?.doctorName}
                placeholder="Doctor Name"
                disabled
              />
              <FormLabel
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              color={textColor}
              display="flex"
            >
              Laboratorist Name
            </FormLabel>
              <Input
                isRequired={true}
                fontSize="sm"
                type="textarea"
                name="laboratoristName"
                mb="24px"
                size="lg"
                variant="auth"
                value={formData.medicalTestOrder?.laboratoristName}
                placeholder="Laboratorist Name"
                disabled
              />
              <Link href="/admin/medicalTestResult">
            <Button
              fontSize="sm"
              variant="brand"
              fontWeight="500"
              w="100%"
              h="50"
              mb="24px"
            >
              Back to Medical Test Results
            </Button>
            </Link>
          </FormControl>
        </Flex>
      </Flex>  
    )
}