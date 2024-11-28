'use client';

import { Box } from "@chakra-ui/react";
import ItemCategoryColumnTable from "./_component/ItemCategoryColumnsTable";
import { useEffect, useState } from "react";
import { IItemCategory } from "interfaces/IItemCategory";
import { getItemCategories } from "api/item-category";


export default function ListItems() {

    const [categories, setCategories] = useState<IItemCategory[]>([]);

    useEffect(() => {
        const fetchItemCategories = async () => {
            setCategories(await getItemCategories());
        }
        fetchItemCategories();
    }, [])
    return (
        <Box pt={{ base: '130px', md: '80px', xl: '80px' }}>
            <ItemCategoryColumnTable categories={categories}/>
        </Box>
      );
}