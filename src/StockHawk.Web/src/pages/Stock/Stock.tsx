import { SyntheticEvent, useState } from 'react';
import Tabs from '@mui/material/Tabs';
import Tab from '@mui/material/Tab';
import { SuppliersTab } from './SuppliersTab/SuppliersTab.tsx';
import { CategoriesTab } from './CategoriesTab/CategoriesTab.tsx';
import { OrderTypesTab } from "./OrderTypesTab/OrderTypesTab.tsx";
import { OrderStatusTab } from './OrderStatusTab/OrderStatusTab.tsx';

export const Stock = () => {
    const [tabIndex, setTabIndex] = useState(0);

    const handleChange = (_event: SyntheticEvent, newValue: number) => {
        setTabIndex(newValue);
    };

    return (
        <div className="flex flex-col flex-1 gap-3 p-2 h-screen overflow-hidden">
            <span>
                <p className="text-lg">Stock</p>
            </span>
            <Tabs value={tabIndex} onChange={handleChange} variant="scrollable"
                scrollButtons="auto" allowScrollButtonsMobile>
                <Tab label="Suppliers" id="suppliers-tab" />
                <Tab label="Categories" id="categories-tab" />
                <Tab label="Order Status" id="order-status-tab" />
                <Tab label="Order Types" id="order-types-tab" />
            </Tabs>
            <div className="flex flex-col w-full flex-1 overflow-auto">
                {tabIndex === 0 && <SuppliersTab />}
                {tabIndex === 1 && <CategoriesTab />}
                {tabIndex === 2 && <OrderStatusTab />}
                {tabIndex === 3 && <OrderTypesTab />}
            </div>
        </div>
    );
};
