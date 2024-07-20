import NavBar from "./NavBar";

type Props = {
    children?: React.ReactNode;
};

export const PageLayout: React.FC<Props> = ({ children }) => {
    return (
        <>
            <NavBar />
            <h5>Welcome to the Microsoft Authentication Library For React Quickstart</h5>
            <br />
            <br />
            {children}
        </>
    );
};