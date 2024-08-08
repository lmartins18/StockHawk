import { DeleteConfirmationDialog } from "../../../../components";
import { useOrderTypesContext } from "../context";
import { EditOrderTypeDialog, AddOrderTypeDialog } from ".";


export const OrderTypesDialogs = () => {

    const { openDialog, setOpenDialog, selectedOrderType, handleEditOrderTypeSuccess, handleDeleteOrderTypeSuccess } = useOrderTypesContext();

    return (
        <>
            {openDialog.addOrderType && (
                <AddOrderTypeDialog
                    open={openDialog.addOrderType}
                    onClose={() => setOpenDialog(prevState => ({ ...prevState, addOrderType: false }))}
                />
            )}
            {selectedOrderType && openDialog.deleteOrderType && (
                <DeleteConfirmationDialog
                    open={openDialog.deleteOrderType}
                    onClose={() => setOpenDialog(prevState => ({ ...prevState, deleteOrderType: false }))}
                    onDelete={handleDeleteOrderTypeSuccess}
                    title="Delete Order Type"
                    message="Are you sure you want to delete this order type?"
                />
            )}
            {selectedOrderType && openDialog.editOrderType && (
                <EditOrderTypeDialog
                    open={openDialog.editOrderType}
                    onClose={() => setOpenDialog(prevState => ({ ...prevState, editOrderType: false }))}
                    onSuccess={handleEditOrderTypeSuccess}
                    orderType={selectedOrderType}
                />
            )}
        </>
    )
}