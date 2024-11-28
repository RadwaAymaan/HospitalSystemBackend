"use client";

import { Box, Button, Flex, FormControl, FormLabel, Heading, Input, useColorModeValue } from "@chakra-ui/react";
import { getItemById } from "api/item";
import { getItemCategoryById } from "api/item-category";
import { getPrescriptionById } from "api/prescription";
import { IPrescription } from "interfaces/IPrescription";
import Link from "next/link";
import React from "react";
import { useEffect, useState } from "react";

export default function PrescriptionDetails({params}: {params: {id: string}}) {
    const [formData, setFormData] = useState<IPrescription>({});
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
        const fetchPrescription = async () => {
            setFormData(await getPrescriptionById(params.id))
        }
        fetchPrescription();
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
            Prescription Details
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
              Prescription Name
            </FormLabel>
            <Input
              isRequired={true}
              variant="auth"
              fontSize="sm"
              ms={{ base: '0px', md: '0px' }}
              type="text"
              name="categoryName"
              placeholder="Prescription Name"
              mb="24px"
              fontWeight="500"
              size="lg"
              value={formData.name} 
              disabled
            />
            <FormLabel
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              color={textColor}
              display="flex"
            >
              Prescription Description
            </FormLabel>
              <Input
                isRequired={true}
                fontSize="sm"
                type="textarea"
                name="Prescription Description"
                mb="24px"
                size="lg"
                variant="auth"
                value={formData.description} 
                disabled
              />
            <FormLabel
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              color={textColor}
              display="flex"
            >
              Prescription Date
            </FormLabel>
              <Input
                isRequired={true}
                fontSize="sm"
                type="textarea"
                name="Prescription Date"
                mb="24px"
                size="lg"
                variant="auth"
                value={formData.date} 
                disabled
              />
            <FormLabel
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              color={textColor}
              display="flex"
            >
              Medicine Name
            </FormLabel>
              <Input
                isRequired={true}
                fontSize="sm"
                type="textarea"
                name="medicineName"
                mb="24px"
                size="lg"
                variant="auth"
                value={formData.medicines && formData.medicines.length > 0 ? formData.medicines[0]?.medicineName : ''}
                disabled
              />
            <FormLabel
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              color={textColor}
              display="flex"
            >
              Medicine Dosage
            </FormLabel>
              <Input
                isRequired={true}
                fontSize="sm"
                type="textarea"
                name="medicineDosage"
                mb="24px"
                size="lg"
                variant="auth"
                value={formData.medicines && formData.medicines.length > 0 ? formData.medicines[0]?.medicineDosage : ''}
                disabled
              />
            <FormLabel
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              color={textColor}
              display="flex"
            >
              Medicine Description
            </FormLabel>
              <Input
                isRequired={true}
                fontSize="sm"
                type="textarea"
                name="medicineDescription"
                mb="24px"
                size="lg"
                variant="auth"
                value={formData.medicines && formData.medicines.length > 0 ? formData.medicines[0]?.medicineDescription : ''}
                disabled
              />
              <Link href="/admin/prescription">
            <Button
              fontSize="sm"
              variant="brand"
              fontWeight="500"
              w="100%"
              h="50"
              mb="24px"
            >
              Back to Prescriptions
            </Button>
            </Link>
          </FormControl>
        </Flex>
      </Flex>  
    )
}