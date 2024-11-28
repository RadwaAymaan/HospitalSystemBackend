"use client";

import { Box, Button, Flex, FormControl, FormLabel, Heading, Input } from "@chakra-ui/react";
import { useColorModeValue } from "@chakra-ui/system";
import { UpdateSchedule, getScheduleById } from "api/schedule";
import { IInsertSchedule } from "interfaces/IInsertSchedule";
import React, { ChangeEvent, useEffect } from "react";
import { useState } from "react";

export default function updateschedule({params}: {params: {id: string}}) {
    const [formData, setFormData] = useState<IInsertSchedule>({});
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
        const fetchschedule = async () => {
            const schedule = await getScheduleById (params.id)
            let scheduleToUpdate: IInsertSchedule =
            {
                doctorId: schedule.doctorId,
                timeSlotId:schedule.timeSlot.id
            
            };
            setFormData(scheduleToUpdate);
        }
        fetchschedule();
    }, []);

    const handleChange = (e: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
        const { name, value } = e.target;
        setFormData(prevState => ({
          ...prevState,
          [name]: value
        }));
      };

      const handleSubmit = async () => {
        setMessage(await UpdateSchedule(params.id, formData));
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
            Update schedule
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
              TIMESLOT ID
            </FormLabel>
            <Input
              isRequired={true}
              variant="auth"
              fontSize="sm"
              ms={{ base: '0px', md: '0px' }}
              type="number"
              name="timeSlotId"
              placeholder="TimeSlot Id"
              mb="24px"
              fontWeight="500"
              size="lg"
              value={formData.timeSlotId} 
              onChange={handleChange}
            />
            <FormLabel
              ms="4px"
              fontSize="sm"
              fontWeight="500"
              color={textColor}
              display="flex"
            >
              DOCTOR ID
            </FormLabel>
              <Input
                isRequired={true}
                fontSize="sm"
                type="textarea"
                name="doctorId"
                mb="24px"
                size="lg"
                variant="auth"
                value={formData.doctorId} 
                onChange={handleChange} 
                placeholder="Doctor Id"
              />
            
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
              Update schedule
            </Button>
          </FormControl>
        </Flex>
        <h1>{message}</h1>
      </Flex> 
      );
}