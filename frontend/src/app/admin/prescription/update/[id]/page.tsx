"use client";

import { Box, Button, Flex, FormControl, FormLabel, Heading, Input, Select } from "@chakra-ui/react";
import { useColorModeValue } from "@chakra-ui/system";
import { UpdateItemCategory, getInventories, getItemCategoryById } from "api/item-category";
import { getMedicines } from "api/medicine";
import { UpdatePrescription, getPrescriptionById } from "api/prescription";
import { InsertItemCategory } from "interfaces/InsertItemCategory";
import { InsertPrescription } from "interfaces/InsertPrescription";
import React, { ChangeEvent, useEffect } from "react";
import { useState } from "react";

export default function UpdatePrescriptionC({params}: {params: {id: string}}) {
    const [medicines, setMedicines] = useState([]);
    const [formData, setFormData] = useState<InsertPrescription>({});
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
        const fetchMedicines = async () => {
            let medicines = await getMedicines();
            setMedicines(medicines);
          }
          fetchMedicines();

        const fetchPrescription = async () => {
            const prescription = await getPrescriptionById(params.id)
            let prescriptionToUpdate: InsertPrescription = {
                name: prescription.name,
                description: prescription.description,
                date: prescription.date,
                medicineId: prescription.medicines[0]?.id,
                patientId: params.id
            };
            setFormData(prescriptionToUpdate);
        }
        fetchPrescription();
    }, []);

    const handleChange = (e: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
        const { name, value } = e.target;
        setFormData(prevState => ({
          ...prevState,
          [name]: value
        }));
      };

      const handleSubmit = async () => {
        setMessage(await UpdatePrescription(params.id, formData));
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
            Update Prescription
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
              name="nam"
              placeholder="Prescription Name"
              mb="24px"
              fontWeight="500"
              size="lg"
              value={formData.name} 
              onChange={handleChange}
            />
            <FormLabel
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              color={textColor}
              display="flex"
            >
              Description
            </FormLabel>
              <Input
                isRequired={true}
                fontSize="sm"
                type="textarea"
                name="description"
                mb="24px"
                size="lg"
                variant="auth"
                value={formData.description} 
                onChange={handleChange} 
                placeholder="Description"
              />
            <FormLabel
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              color={textColor}
              display="flex"
            >
              Date
            </FormLabel>
              <Input
                isRequired={true}
                fontSize="sm"
                type="textarea"
                name="date"
                mb="24px"
                size="lg"
                variant="auth"
                value={formData.date} 
                onChange={handleChange} 
                placeholder="Date"
              />
            <FormLabel
            ms="4px"
            fontSize="sm"
            fontWeight="500"
            color={textColor}
            display="flex"
          >
            Medicines
          </FormLabel>
          <Select
            placeholder="Select Medicine"
            onChange={handleChange}
            name="medicineId"
            mb="24px"
            size="lg"
            variant="auth"
          >
            {medicines.map(medicine => (
              <option key={medicine.id} value={medicine.id}>{medicine.medicineName}</option>
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
              Update Prescription
            </Button>
          </FormControl>
        </Flex>
        <h1>{message}</h1>
      </Flex> 
      );
}