import { Component, ErrorInfo, ReactNode } from 'react';

interface Props {
    children: ReactNode;
}

interface State {
    hasError: boolean;
}

export class ErrorBoundary extends Component<Props, State> {
    constructor(props: Props) {
        super(props);
        this.state = { hasError: false };
    }

    static getDerivedStateFromError(_: Error): State {
        return { hasError: true };
    }

    componentDidCatch(error: Error, errorInfo: ErrorInfo) {
        console.error("ErrorBoundary caught an error", error, errorInfo);
    }

    render() {
        if (this.state.hasError) {
            return (
                <div className="flex flex-col items-center justify-center h-screen bg-gray-100 text-gray-800">
                    <h1 className="text-4xl font-bold mb-4">Something went wrong!</h1>
                    <p className="mb-4">We apologize for the inconvenience. Please try again later.</p>
                    <a className="text-blue-500 hover:underline" onClick={() => window.location.replace("/")}>Go to Home Page</a>
                </div>
            );
        }

        return this.props.children;
    }
}

export default ErrorBoundary;
