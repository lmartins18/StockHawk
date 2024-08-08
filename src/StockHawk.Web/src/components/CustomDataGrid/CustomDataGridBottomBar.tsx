import { ReactNode } from "react"
export const CustomDataGridBottomBar = ({ children }: { children: ReactNode }) =>
(
    <div className="flex w-full justify-end p-2">
        {children}
    </div>
)