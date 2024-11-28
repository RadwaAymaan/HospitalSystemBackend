"use client";

import { Box, Button, Flex, FormControl, FormLabel, Heading, Input, Select } from "@chakra-ui/react";
import { useColorModeValue } from "@chakra-ui/system";
import { UpdateMedicalTestResult, getMedicalTestResultById } from "api/MedicalTestResult";
import { getLaboratoriests } from "api/laboratoriest";
import { getMedicalTestOrders } from "api/medicalTestOrder";
import { ILaboratoriest } from "interfaces/ILaboratiest";
import { IMedicalTestOrder } from "interfaces/IMedicalTestOrder";
import { IInsertMedicalTestResult, IMedicalTestResult } from "interfaces/IMedicalTestResult";
import React, { ChangeEvent, useEffect } from "react";
import { useState } from "react";

export default function DoctorUpdate({params}: {params: {id: number}}) {
  const [laboratorist, setlaboratorist] = useState([]);
  const [medicalTestOrders, setMedicalTestOrder] = useState<IMedicalTestOrder[]>([]);
  const [laboratorists, setLaboratorists] = useState<ILaboratoriest[]>([]);
    const [formData, setFormData] = useState<IInsertMedicalTestResult>({});
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
      const fetchLaboratoriests = async () => {
        let Laboratoriests:ILaboratoriest[] = await getLaboratoriests();
        setLaboratorists(Laboratoriests);
        console.log("from page", Laboratoriests);
      }
      fetchLaboratoriests();
    },[]);
    useEffect(() => {
      const fetchMedicalTestOrders = async () => {
        let medicalTestOrders:IMedicalTestOrder[] = await getMedicalTestOrders();
        setMedicalTestOrder(medicalTestOrders);
        console.log("from page", medicalTestOrders);
      }
      fetchMedicalTestOrders();
    },[]);
    useEffect(() => {
      const fetchlaboratorists = async () => {
        let laboratorists = await getLaboratoriests();
        setlaboratorist(laboratorists);
        console.log("from page", laboratorist);
      }
      fetchlaboratorists();

        const fetchMedicalTestResult = async () => {
            const result = await getMedicalTestResultById(params.id)
            let medicalTestREsultToUpdate: IInsertMedicalTestResult = {
              resultDescription:result.resultDescription,
              medicalTestOrderId:result.medicalTestOrder.id,
              laboratoristId:null
            };
            setFormData(medicalTestREsultToUpdate);
        }
        fetchMedicalTestResult();
        
        
    }, []);

    const handleChange = (e: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
      console.log(formData);
        const { name, value } = e.target;
        setFormData(prevState => ({
          ...prevState,
          [name]: value
        }));
      };

      const handleSubmit = async () => {
        setMessage(await UpdateMedicalTestResult(params.id, formData));
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
            Update Medical Test Result 
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
              Description
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
              onChange={handleChange}
            />
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
            placeholder="Select Labortoriest"
            onChange={handleChange}
            name="laboratoristId"
            mb="24px"
            size="lg"
            variant="auth"
          >
            {laboratorists.map(laboratorist => (
              <option key={laboratorist.id} value={laboratorist.id}>{laboratorist.laboratoriestEmail}</option>
            ))}
          </Select>
          <FormLabel
            ms="4px"
            fontSize="sm"
            fontWeight="500"
            color={textColor}
            display="flex"
          >
            Medical Test Order
          </FormLabel>
          <Select
            placeholder="Select Medical Test Order"
            onChange={handleChange}
            name="medicalTestOrderId"
            mb="24px"
            size="lg"
            variant="auth"
          >
            {medicalTestOrders.map(medicalTestOrder => (
              <option key={medicalTestOrder.id} value={medicalTestOrder.id}>{medicalTestOrder.medicalTestName}</option>
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
              Update Medical Test Result
            </Button>
          </FormControl>
        </Flex>
        <h1>{message}</h1>
      </Flex> 
      );
}