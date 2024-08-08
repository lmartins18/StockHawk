import React from "react";
import { NavBar } from "./NavBar";

type Props = {
    children?: React.ReactNode;
};

export const PageLayout: React.FC<Props> = ({ children }) => {
    return (
        <div className="h-screen w-screen bg-white dark:bg-neutral-900 text-black dark:text-white flex flex-col">
            <NavBar />
            <div className="flex flex-col w-full h-full grow overflow-auto">
                {children}
            </div>
        </div>
    );
};
